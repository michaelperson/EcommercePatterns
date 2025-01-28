using EcommercePatterns.Payment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Payment.Specialized
{
    public class BankTransfertPayment : IPaymentMethod
    {
        public bool ProcessPayment(decimal amount)
        {
            return false;
        }
    }
}
