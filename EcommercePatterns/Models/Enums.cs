using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Models
{
    public enum PaymentType
    {
        CreditCard,
        PayPal,
        BankTransfer
    }

    public enum OrderStatus
    {
        Created,
        Confirmed,
        Paid,
        Shipped,
        Delivered
    }
}
