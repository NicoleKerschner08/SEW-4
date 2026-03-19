using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kaffee_konfigurator
{
    internal class coffeOrderViewModel : INotifyPropertyChanged, ICommand
    {
        public coffeeOrderModel coffeeOrderModel = new coffeeOrderModel();
        public ICommand cmdButtonClick { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        public List<string> Sizes { get; } = new List<string> {"Klein","Mittel","Groß"};

        public double basePrice
        {
            get
            {
                return coffeeOrderModel.basePrice;
            }
            set
            {
                coffeeOrderModel.basePrice = value;
            }
        }


        private string selectedSize;
        public string SelectedSize
        {
            get
            {
                return selectedSize;
            }
            set
            {
                if (selectedSize != value)
                {
                    selectedSize = value;
                    if (SelectedSize == "Klein")
                    {
                        basePrice = 1.40;
                    }
                    else if (SelectedSize == "Mittel")
                    {
                        basePrice = 1.80;
                    }
                    else if (SelectedSize == "Groß")
                    {
                        basePrice = 2.20;
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(price)));
            }
        }

        private bool isChecked;
        public bool IsChecked 
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    if (isChecked)
                    {
                        coffeeOrderModel.isChecked = 0.50;
                    }
                    else
                    {
                        coffeeOrderModel.isChecked = 0.00;
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(price)));
            }
        }

        public double price
        {
            get
            {
                return coffeeOrderModel.basePrice + coffeeOrderModel.isChecked;
            }
        }
        public coffeOrderViewModel()
        {
            cmdButtonClick = this;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SelectedSize = null;
            IsChecked = false;
            basePrice = 0.00;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSize)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(price)));
        }
    }
}
