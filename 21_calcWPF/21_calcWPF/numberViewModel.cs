using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _21_calcWPF
{
    internal class numberViewModel : ICommand, INotifyPropertyChanged
    {
        private numberModel model = new numberModel();
        public ICommand cmdButtonClick { get; set; }
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public int number1
        {
            get { return model.number1; }
            set
            {
                model.number1 = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(number1)));
            }

        }

        public int number2
        {
            get { return model.number2; }
            set
            {
                model.number2 = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(number2)));
            }
        }

        public int result { 
            get { return model.result; } 
            set 
            {
                model.result = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(result)));
            }
        }

        public string status
        {
            get { return model.staus; }
            set
            {
                model.staus = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(status)));
            }
        }

        public SolidColorBrush brush
        {
            get { return model.brush; }
            set
            {
                model.brush = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(brush)));

            }
        }

        public numberViewModel()
        {
            cmdButtonClick = this;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {

                if((string)parameter == "addition")
                {
                    result = number1 + number2;
                    status ="Addition erfolgreich";
                }
                 else if ((string)parameter == "subtraktion")
                {
                    result = number1 - number2;
                    status = "Subtraktion erfolgreich";
                }
                 else if ((string)parameter == "multiplikation")
                {
                    result = number1 * number2;
                    status = "Multiplikation erfolgreich";
                }
                 else if ((string)parameter == "division")
                {
                    result = number1 / number2;
                    status = "Division erfolgreich";
                }
                else
                {
                    result = 0;
                    number1 = 0;
                    number2 = 0;
                    brush = new SolidColorBrush(Colors.Black);  
                }

                if(result < 0)
                {
                    brush = new SolidColorBrush(Colors.Red);
                }
                else if(result > 0)
                {
                    brush = new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    brush = new SolidColorBrush(Colors.Black);
                }

            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
        }
    }
}
