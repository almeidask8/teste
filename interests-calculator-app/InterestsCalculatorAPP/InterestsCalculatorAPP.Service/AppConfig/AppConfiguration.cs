using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InterestsCalculatorAPP.Service.AppConfig
{
    public class AppConfiguration : IAppConfiguration
    {
        public readonly string _endpoint_production = string.Empty;
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _endpoint_production = root.GetSection("Url").Value;
        }
        public string EndPoint_Production
        {
            get => _endpoint_production;
        }

    }
}
