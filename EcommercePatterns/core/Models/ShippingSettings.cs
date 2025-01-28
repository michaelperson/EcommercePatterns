using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.core.Models
{
    public class ShippingSettings
    {
        public string DefaultStrategy { get; set; }
        public decimal BaseRate { get; set; }
        public decimal WeightMultiplier { get; set; }
    }
}
