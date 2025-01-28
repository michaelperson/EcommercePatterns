using EcommercePatterns.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EcommercePatterns.core.Models;
using EcommercePatterns.Services.Exceptions;

namespace EcommercePatterns.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly EmailSettings _emailSettings;

        public EmailService()
        {
            _emailSettings = Configuration.Instance.GetSection<EmailSettings>("EmailSettings");
            _smtpClient = ConfigureSmtpClient();
        }

        private SmtpClient ConfigureSmtpClient()
        {
            return new SmtpClient
            {
                Host = _emailSettings.SmtpServer,
                Port = _emailSettings.SmtpPort,
                EnableSsl = _emailSettings.EnableSsl,
                Credentials = new NetworkCredential(
                   _emailSettings.Username,
                   _emailSettings.Password
               )
            };
        }

        public async Task SendOrderStatusEmail(Order order)
        {
            using var mailMessage = new MailMessage
            {
                From = new MailAddress(
                    _emailSettings.SenderEmail,
                    _emailSettings.SenderName
                ),
                Subject = $"Mise à jour de votre commande {order.OrderNumber}",
                Body = GenerateEmailBody(order),
                IsBodyHtml = true
            };

            mailMessage.To.Add(order.Client.Email);

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new EmailServiceException("Erreur lors de l'envoi de l'email", ex);
            }
        }
        private string GenerateEmailBody(Order order)
        {
            return $@"
                <html>
                <body>
                    <h2>Mise à jour de votre commande</h2>
                    <p>Cher(e) {order.Client.Name},</p>
                    <p>Votre commande {order.OrderNumber} a été mise à jour.</p>
                    <p>Nouveau statut : <strong>{order.Status}</strong></p>
                    <h3>Détails de la commande :</h3>
                    <ul>
                        {GenerateOrderItemsList(order)}
                    </ul>
                    <p>Montant total : {order.TotalAmount:C}</p>
                    <p>Pour toute question, n'hésitez pas à nous contacter.</p>
                    <p>Cordialement,<br>L'équipe E-commerce</p>
                </body>
                </html>";
        }

        private string GenerateOrderItemsList(Order order)
        {
            var items = new StringBuilder();
            foreach (var product in order.Products)
            {
                items.AppendLine($"<li>{product.Name} - {product.Price:C}</li>");
            }
            return items.ToString();
        }
    }
}

