using ConnectedLabLesson.Model;
using ConnectedLabLesson.Service;
using System;

namespace ConnectedLabLesson.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConfiguration();

            var accService = new AuthService();
            var saveService = new SaveProfileService();
            var account = accService.ChooseMenu();

            if (account != null)
            {
                saveService.SaveToProfile(account);
            }
        }

        private static void InitConfiguration()
        {
            ConfigurationService.Init();
        }
    }
}
