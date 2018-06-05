using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace AriaLogger
{
    public class AriaLogger : ILogger
    {
        private string _tenantToken;
        private string _tableName;
        public AriaLogger(IConfigReader configReader, string tableName)
        {
            _tenantToken = configReader.GetValue("TenantToken");
            _tableName = tableName;
        }
        public void Write(string content)
        {
            Console.WriteLine($"AriaLogger - {_tenantToken}/{_tableName}: {content}");
        }
    }
}
