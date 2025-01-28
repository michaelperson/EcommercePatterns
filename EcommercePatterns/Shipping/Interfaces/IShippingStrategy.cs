using EcommercePatterns.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Shipping.Interfaces
{
    public interface IShippingStrategy
    {
        decimal CalculateShipping(Order order);
    }
}
