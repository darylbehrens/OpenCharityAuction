using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models
{
    public class Configuration
    {
        public string AppName { get; }

        public Configuration(string _appName)
        {
            AppName = _appName;
        }
    }
}
