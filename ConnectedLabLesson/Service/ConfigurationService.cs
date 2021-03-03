using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ConnectedLabLesson.Service
{
    public static class ConfigurationService
    {
        public static IConfiguration Configuration { get; private set; }
        public static void Init()
        {
            if (DbProviderFactories.GetFactory("ConnectedProvider") == null)
            {
                DbProviderFactories.RegisterFactory("ConnectedProvider", SqlClientFactory.Instance);
            }
            if (Configuration == null)
            {
                var configuratonBuilder = new ConfigurationBuilder();
                var configuration = configuratonBuilder.AddJsonFile("appSetting.json").Build();
            }
        }
    }
}
