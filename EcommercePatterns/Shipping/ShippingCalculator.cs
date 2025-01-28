using EcommercePatterns.core;
using EcommercePatterns.Shipping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Shipping
{
    // Pattern Strategy - Contexte
    public class ShippingCalculator
    {
        private readonly IShippingStrategy _strategy;

        public ShippingCalculator(IShippingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal CalculateShipping(Order order)
        {
            return _strategy.CalculateShipping(order);
        }
    }
}
