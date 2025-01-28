using EcommercePatterns.core;
using EcommercePatterns.Models;
using EcommercePatterns.Notification;
using EcommercePatterns.Payment;
using EcommercePatterns.Shipping;
using EcommercePatterns.Shipping.Specialized;
using EcommercePatterns.Services;
using EcommercePatterns.core.Exceptions;
using EcommercePatterns.core.Models;

// Initialisation du singleton de configuration
try
{
    // Initialisation de la configuration
    var config = Configuration.Instance;
    config.LoadConfiguration();

    // Récupération des paramètres spécifiques si nécessaire
    var emailSettings = config.GetSection<EmailSettings>("EmailSettings");
    var appSettings = config.GetSection<ApplicationSettings>("ApplicationSettings");

    // Création du client
    var client = new Client
    {
        Id = 1,
        Name = "John Doe",
        Email = "john.doe@example.com",
        PhoneNumber = "+33 6 12 34 56 78",
        Address = "123 rue de Paris, 75000 Paris"
    };

    // Création d'une commande avec le client
    var order = new Order(client);
    order.AddProduct(new Product { Name = "Laptop", Price = 999.99m, Weight = 2.5 });
    order.AddProduct(new Product { Name = "Mouse", Price = 29.99m, Weight = 0.2 });

    // Création du moyen de paiement via la Factory
    var paymentFactory = new PaymentMethodFactory();
    var payment = paymentFactory.CreatePaymentMethod(PaymentType.CreditCard);

    // Calcul des frais de port avec la stratégie appropriée
    var shippingStrategy = new LocalShippingStrategy();
    var shippingCalculator = new ShippingCalculator(shippingStrategy);
    decimal shippingCost = shippingCalculator.CalculateShipping(order);

    // Configuration du service d'email
    var emailService = new EmailService();
    var emailNotifier = new EmailNotifier(emailService);
    order.AddObserver(emailNotifier);

    // Simulation du processus de commande
    try
    {
        order.UpdateStatus(OrderStatus.Confirmed);
        payment.ProcessPayment(order.TotalAmount + shippingCost);
        order.UpdateStatus(OrderStatus.Paid);

        Console.WriteLine($"Commande {order.OrderNumber} traitée avec succès");
        Console.WriteLine($"Email de confirmation envoyé à {client.Email}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors du traitement de la commande : {ex.Message}");
    }
}
catch (ConfigurationException ex)
{
    Console.WriteLine($"Erreur de configuration : {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur inattendue : {ex.Message}");
}

