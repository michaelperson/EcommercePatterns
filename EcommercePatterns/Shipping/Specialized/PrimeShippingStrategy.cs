using EcommercePatterns.core;
using EcommercePatterns.Shipping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Shipping.Specialized
{
    public class PrimeShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShipping(Order order)
        {
            return 0;
        }
    }
}
