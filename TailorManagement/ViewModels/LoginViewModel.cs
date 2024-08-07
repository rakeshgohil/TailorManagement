﻿using System.Windows;
using System.Windows.Input;
using TailorManagement.Commands;
using TailorManagement.Services;
using TailorManagement.Utilities;
using TailorManagement.Views;

namespace TailorManagement.ViewModels
{
    public class LoginViewModel
    {
        private readonly INavigationService _navigationService;
        public ICommand CloseApplicationCommand { get; }
        public ICommand OpenMainViewCommand { get; }

        public LoginViewModel()
        {
            _navigationService = NavigationService.GetNavigationService();
            CloseApplicationCommand = new RelayCommand(CommonApplication.CloseApplication);
            OpenMainViewCommand = new RelayCommand(OpenMainView);
        }

        private void OpenMainView()
        {
            _navigationService.NavigateTo(typeof(Main));
            Application.Current.MainWindow.Close();
        }
    }
}
