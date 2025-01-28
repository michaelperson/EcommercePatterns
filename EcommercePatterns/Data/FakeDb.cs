using EcommercePatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Data
{
    public class InMemoryRepository
    {
        private readonly List<Client> _clients = new();
        private readonly List<Product> _products = new();

        public InMemoryRepository()
        {
            // Initialisation avec des données de base
            _clients.AddRange(new[]
            {
            new Client { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St" },
            new Client { Id = 5, Name = "Emily Dupont", Email = "emily.dupont@exemple.com", PhoneNumber = "555-1212", Address = "789 Rue des Lilas" },
            new Client { Id = 6, Name = "Thomas Martin", Email = "thomas.martin@exemple.com", PhoneNumber = "555-3434", Address = "123 Avenue des Champs" },
            new Client { Id = 7, Name = "Léa Durand", Email = "lea.durand@exemple.com", PhoneNumber = "555-5656", Address = "456 Chemin des Roses" },
            new Client { Id = 8, Name = "Lucas Bernard", Email = "lucas.bernard@exemple.com", PhoneNumber = "555-7878", Address = "987 Rue des Érables" },
        });

            _products.AddRange(new[]
        {
            new Product { Name = "Laptop", Price = 999.99M, Weight = 2.5 },
            new Product { Name = "Phone", Price = 599.99M, Weight = 0.2 },
            new Product { Name = "Tablet", Price = 399.99M, Weight = 0.5 },
            new Product { Name = "T-shirt", Price = 19.99M, Weight = 0.1 },
            new Product { Name = "Jeans", Price = 59.99M, Weight = 0.5 },
            new Product { Name = "Shoes", Price = 89.99M, Weight = 0.8 },
            new Product { Name = "Book", Price = 14.99M, Weight = 0.2 },
            new Product { Name = "Game", Price = 59.99M, Weight = 0.1 },
            new Product { Name = "Movie", Price = 19.99M, Weight = 0.1 },
        });
        }

        public IEnumerable<Client> GetClients()
        {
            return _clients;
        }

        public Client GetClientById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

         
        // Produits
        public IEnumerable<Product> GetProducts() => _products;

        public Product GetProductByName(string name) => _products.FirstOrDefault(p => p.Name == name);

        public void AddProduct(Product product) => _products.Add(product);

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Price = product.Price;
                existingProduct.Weight = product.Weight;
            }
        }

        public void DeleteProduct(string name) => _products.RemoveAll(p => p.Name == name);
    }
}
