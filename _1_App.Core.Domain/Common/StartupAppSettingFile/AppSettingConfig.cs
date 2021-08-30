using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_App.Core.Domain.Common.StartupAppSettingFile
{
    public class CNNSTR
    {
        public string CnnName { get; set; }
        public string CnnValue { get; set; }
    }
    public class AppSettingConfig
    {
        private static IConfigurationRoot GetConfigs()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();
            return builder.Build();
        }

        private static IConfigurationRoot _rootConfig { get; set; }
        public static IConfigurationRoot RootConfig
        {
            get
            {
                if (_rootConfig == null) _rootConfig = GetConfigs();
                return _rootConfig;
            }
        }

        public static List<CNNSTR> GetListConnectionStrings(string sectionName = "ConnectionStrings")
        {
            var connStrings = RootConfig.GetSection(sectionName).GetChildren().Select(s => new CNNSTR
            {
                CnnName = s.Key,
                CnnValue = s.Value
            }).ToList();
            return connStrings;
        }
    }



    /*
    public class ConfigHelper
    {

        private static ConfigHelper _appSettings;
        public string appSettingValue { get; set; }
        public static string AppSetting(string Key)
        {
            _appSettings = GetCurrentSettings(Key);
            return _appSettings.appSettingValue;
        }

        public ConfigHelper(IConfiguration config, string Key)
        {
            this.appSettingValue = config.GetValue<string>(Key);
        }

        public static ConfigHelper GetCurrentSettings(string Key)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();            
            var settings = new ConfigHelper(configuration.GetSection("ConnectionStrings"), Key);
            return settings;
        }
    }
    */
}
