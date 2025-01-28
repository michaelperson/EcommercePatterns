using EcommercePatterns.core;
using EcommercePatterns.Shipping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Shipping.Specialized
{
    public class LocalShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShipping(Order order)
        {
            return (decimal)(order.TotalWeight * 5.0);
        }
    }
}
