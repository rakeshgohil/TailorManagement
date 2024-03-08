using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagement.ViewModels
{
    public class BillViewModel
    {
        public ObservableCollection<Item> YourItemList { get; set; }
        public BillViewModel()
        {
            YourItemList = new ObservableCollection<Item>();
            // Add some initial items if needed
            YourItemList.Add(new Item { ItemName = "Item 1", Qty = 1, Price = 10});
            YourItemList.Add(new Item { ItemName = "Item 2", Qty = 2, Price = 20});

        }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; OnPropertyChanged(nameof(ItemName)); }
        }

        private int _qty;
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; OnPropertyChanged(nameof(Qty)); OnPropertyChanged(nameof(Amount)); }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); OnPropertyChanged(nameof(Amount)); }
        }

        public double Amount => Qty * Price;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
