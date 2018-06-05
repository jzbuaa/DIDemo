using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace LoggerFramework
{
    public class AppConfigReader : IConfigReader
    {
        public string GetValue(string key)
        {
            var reader = new AppSettingsReader();
            return reader.GetValue(key, typeof(string)).ToString();
        }
    }
}
