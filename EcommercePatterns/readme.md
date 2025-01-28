# 🛍️ Système de Gestion de Commandes E-commerce

## 📋 Table des Matières
- [Vue d'ensemble](#vue-densemble)
- [Fonctionnalités](#fonctionnalités)
- [Architecture](#architecture)
- [Configuration](#configuration)
- [Patterns de Conception](#patterns-de-conception)
- [Structure du Projet](#structure-du-projet)
- [Installation](#installation)
- [Utilisation](#utilisation)
- [Sécurité](#sécurité)

## 🎯 Vue d'ensemble
Système de gestion de commandes e-commerce développé en .NET 8, intégrant :
- Gestion complète des commandes
- Système de paiement multi-méthodes
- Calcul dynamique des frais de port
- Notifications par email
- Configuration centralisée
- Gestion des clients

## ✨ Fonctionnalités

### Gestion des Commandes
- Création de commandes avec produits multiples
- Génération automatique des numéros de commande
- Suivi des statuts de commande
- Association client-commande

### Système de Paiement
- Support de multiples méthodes (Carte de crédit, PayPal)
- Architecture extensible pour nouveaux moyens de paiement
- Sécurisation des transactions

### Calcul des Frais de Port
- Stratégies de calcul configurables
- Prise en compte du poids et de la destination
- Support national et international

### Notifications
- Notifications email automatiques
- Templates HTML personnalisables
- Suivi des changements de statut en temps réel

### Configuration
- Configuration centralisée via appsettings.json
- Gestion sécurisée des credentials
- Paramètres d'application configurables

## 🏗️ Architecture

### Patterns de Conception

#### 🏭 Factory Method
```csharp
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
```

#### 📐 Strategy
```csharp
public interface IShippingStrategy
{
    decimal CalculateShipping(Order order);
}
```

#### 👀 Observer
```csharp
public interface IObserver
{
    void Update(Order order);
}

public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

#### 🔒 Singleton (Configuration)
```csharp
public sealed class Configuration : IConfiguration
{
    private static readonly Configuration instance = new Configuration();
    private Configuration() { }
    public static Configuration Instance => instance;
}
```

## ⚙️ Configuration

### Structure du fichier appsettings.json
```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "EnableSsl": true,
    "Username": "your-email@gmail.com",
    "Password": "your-app-password"
  },
  "ApplicationSettings": {
    "CompanyName": "My E-commerce"
  }
}
```

## 📁 Structure du Projet

```
ECommerceApp/
├── Core/
│   ├── Exceptions/
│   │   └── ConfigurationException.cs 
│   ├── Interaces/
│   │   └── IConfiguration.cs
│   ├── Models/
│   │   ├── ApplicationSettings.cs
│   │   ├── EmailSettings.cs
│   │   └── ShippingSettings.cs
│   ├── Configuration.cs 
│   └── Order.cs
├── Models/
│   ├── Client.cs
│   ├── Product.cs
│   └── Enum.cs 
├── Notification/
│   ├── Interaces/
│   │   ├── IObserver.cs
│   │   └── ISubject.cs
│   └── EmailNotifier.cs
├── Payment/
│   ├── Interaces/
│   │   └── IPaymentMethod.cs 
│   ├── Specialized/
│   │   ├── CreditCardPayment.cs 
│   │   └── PayPalPayment.cs
│   └── PaymentMethodFactory.cs 
├── Services/
│   ├── Exceptions/
│   │   └── EmailServiceException.cs 
│   └── EmailService.cs
├── Shipping/
│   ├── Interaces/
│   │   └── IShippingStrategy.cs 
│   ├── Specialized/
│   │   ├── InternationalShippingStrategy.cs 
│   │   └── LocalShippingStrategy.cs 
│   └── ShippingCalculator.cs 
├── Program.cs 
└── appsettings.json
```

## 🚀 Installation

1. Cloner le repository
```bash
git clone [url-du-repo]
```

2. Configurer appsettings.json
```bash
cp appsettings.example.json appsettings.json
# Modifier les valeurs dans appsettings.json
```

3. Restaurer les packages
```bash
dotnet restore
```

4. Compiler le projet
```bash
dotnet build
```

## 💻 Utilisation

### Exemple de Code Principal
```csharp
// Initialisation
var config = Configuration.Instance;
config.LoadConfiguration();

// Création client
var client = new Client
{
    Name = "John Doe",
    Email = "john@example.com"
};

// Création commande
var order = new Order(client);
order.AddProduct(new Product { Name = "Laptop", Price = 999.99m });

// Configuration notifications
var emailService = new EmailService();
var emailNotifier = new EmailNotifier(emailService);
order.AddObserver(emailNotifier);

// Traitement commande
order.UpdateStatus(OrderStatus.Confirmed);
```

## 🔐 Sécurité

### Protection des Données Sensibles
- Ne pas commiter appsettings.json avec des credentials
- Utiliser des variables d'environnement en production
- Sécuriser les connexions SMTP avec SSL/TLS

### Bonnes Pratiques
- Chiffrer les mots de passe en base de données
- Utiliser des connexions sécurisées pour les paiements
- Logger les actions sensibles

## 🤝 Contribution

1. Forker le projet
2. Créer une branche (`git checkout -b feature/AmazingFeature`)
3. Commiter les changements (`git commit -m 'Add AmazingFeature'`)
4. Pousser la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request
 