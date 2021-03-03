using ConnectedLabLesson.Data;
using ConnectedLabLesson.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedLabLesson.Service
{
    public class SaveProfileService
    {
        public Profile SaveToProfile(Account account)
        {
            var profileDataAccess = new ProfileDataAccess();

            var profile = new Profile();
            profile.Login = account.Login;
            Console.Write("Напишите Имя: ");
            profile.FirstName = Console.ReadLine();
            Console.Write("Напишите Фамилию: ");
            profile.LastName = Console.ReadLine();
            Console.Write("Напишите Email: ");
            profile.Email = Console.ReadLine();
            Console.Write("Напишите путь к картинке: ");
            profile.PathToImage = Console.ReadLine();

            profileDataAccess.Insert(profile);
            return profile;
        }
    }
}
