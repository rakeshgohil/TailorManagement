using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TailorManagement.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Window> _viewTypeToWindowMap = new Dictionary<Type, Window>();
        private static NavigationService navigationService;
        public void NavigateTo(Type viewType)
        {
            if (!_viewTypeToWindowMap.TryGetValue(viewType, out var window))
            {
                window = (Window)Activator.CreateInstance(viewType);
                window.Closed += (sender, args) => _viewTypeToWindowMap.Remove(viewType);
                _viewTypeToWindowMap[viewType] = window;
            }

            window.Show();
        }

        public static NavigationService GetNavigationService()
        {
            if(navigationService == null)
            {
                navigationService = new NavigationService();
            }
            return navigationService;
        }
    }
}
