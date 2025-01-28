using EcommercePatterns.Models;
using EcommercePatterns.Notification.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.core
{
    // Pattern Observer - Sujet
    public class Order : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private List<Product> products = new List<Product>();
        private OrderStatus status;

        public List<Product>  Products  => products;
        public OrderStatus Status => status;
        public decimal TotalAmount => products.Sum(p => p.Price);
        public double TotalWeight => products.Sum(p => p.Weight);

        public Client Client { get; set; }
        public string OrderNumber { get; private set; }

        public Order(Client client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            OrderNumber = GenerateOrderNumber();
            status = OrderStatus.Created;
        }

        private string GenerateOrderNumber()
        {
            return $"Order-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Implémentation de ISubject
        public void AddObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
              observer.Update(this);
            }
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            if (status != newStatus)
            {
                status = newStatus;
                // Notifie tous les observateurs du changement de statut
                NotifyObservers();
            }
        }

    }
}

