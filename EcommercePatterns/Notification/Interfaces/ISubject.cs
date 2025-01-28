using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePatterns.Notification.Interfaces
{
    public interface ISubject
    {
        // Ajoute un nouvel observateur à la liste des observateurs
        void AddObserver(IObserver observer);

        // Retire un observateur de la liste des observateurs
        void RemoveObserver(IObserver observer);

        // Notifie tous les observateurs d'un changement
        void NotifyObservers();
    }
}
