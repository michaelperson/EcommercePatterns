using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.core.Interfaces
{
    public interface IConfiguration
    {
        T GetSection<T>(string sectionName) where T : class, new();
        string GetValue(string key);
        void LoadConfiguration();
    }
}
