using EcommercePatterns.core;
using EcommercePatterns.Notification.Interfaces;
using EcommercePatterns.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Notification
{
    public class EmailNotifier : IObserver
    {
        private readonly EmailService _emailService; 

        public EmailNotifier(EmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }


        public async void Update(Order order)
        {
            try
            {
                await _emailService.SendOrderStatusEmail(order);
                Console.WriteLine($"Email envoyé à {order.Client.Email} - Statut: {order.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'envoi de l'email: {ex.Message}");
            }
        }
    }
}

