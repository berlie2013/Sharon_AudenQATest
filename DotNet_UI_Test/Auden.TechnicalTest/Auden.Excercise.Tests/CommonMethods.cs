using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common
{
    public class CommonMethods
    {
        public string GetAppConfigKeyValue(string keyName)
        {
            if (!string.IsNullOrEmpty(keyName))
            {
                var reader = new AppSettingsReader();
                return (string)reader.GetValue(keyName, typeof(string));
            }

            return string.Empty;
        }

    }
}
