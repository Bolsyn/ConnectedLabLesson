using ConnectedLabLesson.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedLabLesson.Service
{
    public class AuthService
    {
        public Account ChooseMenu()
        {
            Console.WriteLine("Регистрация? Нажмите 1");
            Console.WriteLine("Вход? Нажмите 2");
            Console.WriteLine("Выход? Нажмите 0");
            int signUp = Console.Read() - 48;

            if (signUp == 1)
            {
                var account = new Account();
                Console.Write("Напишите Логин: ");
                account.Login = Console.ReadLine();
                Console.Write("Напишите Пароль: ");
                account.Password = Console.ReadLine();
            }
            else if (signUp == 2)
            {
                Console.Write("Логин: ");
                var loginOfEnter = Console.ReadLine();
                Console.Write("Пароль: ");
                var passwordOfEnter = Console.ReadLine();
            }
            else if (signUp == 0)
            {
                Console.WriteLine("Пока");
                return null;
            }
            else 
            { 
                return null; 
            }
            return null;
        }
    }
}
