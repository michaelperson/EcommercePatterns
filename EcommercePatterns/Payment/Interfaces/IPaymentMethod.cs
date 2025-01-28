using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Payment.Interfaces
{
    public interface IPaymentMethod
    {
        bool ProcessPayment(decimal amount);
    }
}
