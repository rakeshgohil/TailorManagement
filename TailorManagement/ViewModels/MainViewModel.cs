using System.Windows.Input;
using TailorManagement.Commands;
using TailorManagement.Services;
using TailorManagement.Utilities;
using TailorManagement.Views;

namespace TailorManagement.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand CloseApplicationCommand { get; }
        public ICommand OpenShirtViewCommand { get; }
        public MainViewModel()
        {
            _navigationService = NavigationService.GetNavigationService();
            CloseApplicationCommand = new RelayCommand(CommonApplication.CloseApplication);
            OpenShirtViewCommand = new RelayCommand(OpenShirtView);
        }
        private void OpenShirtView()
        {
            _navigationService.NavigateTo(typeof(Shirt));
        }
    }
}
