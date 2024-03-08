using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TailorManagement.Commands;
using TailorManagement.Services;
using TailorManagementModels;

namespace TailorManagement.ViewModels
{
    public class ShirtViewModel
    {
        public ICommand SaveShirtCommand { get; }
        public Shirt Shirt { get; set; }
        public ShirtViewModel()
        {
            SaveShirtCommand = new RelayCommand(SaveShirt);
        }
        private async void SaveShirt()
        {
            Shirt addedShirt =  await ApiClient.GetApiClient().PostAsync<Shirt>(Shirt, "api/Shirts/PostShirt");
            Shirt.Id = addedShirt.Id;
        }
    }
}
