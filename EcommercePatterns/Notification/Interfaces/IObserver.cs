using EcommercePatterns.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Notification.Interfaces
{
    // Pattern Observer - Interface observateur
    public interface IObserver
    {
        void Update(Order order);
    }
}
