using TailorManagement.Commands;
using System;
using System.Windows.Input;
using System.Windows;
using TailorManagement.Services;
using TailorManagement.Views;
using TailorManagement.Utilities;

namespace TailorManagement.ViewModels
{
    public class LoginViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand CloseApplicationCommand { get; }
        public ICommand OpenDashboardCommand { get; }

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            CloseApplicationCommand = new RelayCommand(CommonApplication.CloseApplication);
            OpenDashboardCommand = new RelayCommand(OpenDashboard);
        }

        private void OpenDashboard()
        {
            _navigationService.NavigateTo(typeof(Dashboard));
            Application.Current.MainWindow.Close();
        }
    }
}
