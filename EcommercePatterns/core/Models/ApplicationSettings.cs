using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.core.Models
{
    public class ApplicationSettings
    {
        public string CompanyName { get; set; }
        public string SupportEmail { get; set; }
        public string BaseUrl { get; set; }
        public string OrderPrefix { get; set; }
    }
}
