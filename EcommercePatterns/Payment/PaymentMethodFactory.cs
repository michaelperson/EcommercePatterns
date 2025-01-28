using EcommercePatterns.Models;
using EcommercePatterns.Payment.Interfaces;
using EcommercePatterns.Payment.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Payment
{
    // Pattern Factory Method - Créateur
    public class PaymentMethodFactory
    {
        public IPaymentMethod CreatePaymentMethod(PaymentType type)
        {
            return type switch
            {
                PaymentType.CreditCard => new CreditCardPayment(),
                PaymentType.PayPal => new PayPalPayment(),
                _ => throw new ArgumentException("Type de paiement non supporté")
            };
        }
    }
}
