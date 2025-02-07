using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelModel
{
    public class Configuration : IConfiguration
    {
        ConcurrentDictionary<string, string> _configuration=new ConcurrentDictionary<string, string>();

        public Configuration()
        {
            _configuration.TryAdd("Jwt:Key", "your-256-bit-secret");
            _configuration.TryAdd("Jwt:Issuer", "shitao.geng");
            _configuration.TryAdd("Jwt:Audience", "TravelClient");
        }
        public string? this[string key]
        {
            get
            {
                string outValue;
                _configuration.TryGetValue(key,out outValue);
                return outValue;
            }
            set
            {
                _configuration[key] = value;
            }
        }


        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
