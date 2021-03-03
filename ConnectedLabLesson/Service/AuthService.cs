using ConnectedLabLesson.Data;
using ConnectedLabLesson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConnectedLabLesson.Service
{
    public class AuthService
    {
        ushort secretKey = 0x0088;

        public Account ChooseMenu()
        {
            Console.WriteLine("Регистрация? Нажмите 1");
            Console.WriteLine("Вход? Нажмите 2");
            Console.WriteLine("Выход? Нажмите 0");
            int signUp = Console.Read() - 48;

            if (signUp == 1)
            {
                var accountDataAccess = new AccountDataAccess();
                var accounts = accountDataAccess.Select();

                bool IsUnUsed = true;
                
                var account = new Account();
                Console.Write("Напишите Логин: ");
                account.Login = Console.ReadLine();
                foreach (var acc in accounts)
                {
                    if (acc.Login == account.Login)
                    {
                        IsUnUsed = false;
                    }
                }
                if (!IsUnUsed)
                {
                    Console.WriteLine( "Такой Логин существует!");
                    return null;
                }
                Console.Write("Напишите Пароль: ");
                string clearPass = Console.ReadLine();
                account.Password = EncodeDecrypt(clearPass, secretKey);

                accountDataAccess.Insert(account);
            }
            else if (signUp == 2)
            {
                var accountDataAccess = new AccountDataAccess();
                var accounts = accountDataAccess.Select();
                
                Console.Write("Логин: ");
                var loginOfEnter = Console.ReadLine();
                Console.Write("Пароль: ");
                var passwordOfEnter = Console.ReadLine();
                foreach (var acc in accounts)
                {
                    if (acc.Login == loginOfEnter)
                    {
                        if (EncodeDecrypt(acc.Password, secretKey) == passwordOfEnter)
                        {
                            return acc;
                        }
                        else
                        {
                            Console.WriteLine("Неправльиный пароль");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправльиный логин");
                    }
                }
            }
            else if (signUp == 0)
            {
                Console.WriteLine("До свидания!");
                return null;
            }
            else 
            {
                Console.WriteLine("Нет такого пункта меню");
                return null; 
            }
            return null;
        }

        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray(); 
            string newStr = "";      
            foreach (var c in ch)  
                newStr += TopSecret(c, secretKey);  
            return newStr;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); 
            return character;
        }
    }
}
