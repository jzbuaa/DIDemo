using Autofac;
using Autofac.Configuration;
using Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerFramework
{
    public class CLog
    {
        static Lazy<ILogger> logger = new Lazy<ILogger>(() =>
        {
            var config = new ConfigurationBuilder();
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            config.AddJsonFile("autofac.json");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            var container = builder.Build();
            return container.Resolve<ILogger>();
        });

        public static void Info(string content)
        {
            logger.Value.Write(content);
        }
    }
}
