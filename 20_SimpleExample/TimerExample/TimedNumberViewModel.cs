using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
using System.Windows.Input;

namespace TimerExample
{
    internal class TimedNumberViewModel: INotifyPropertyChanged, ICommand
    {
        DispatcherTimer timer = new DispatcherTimer();
        private TimedNumberModel model = new TimedNumberModel();
        Random random = new Random();
        public ICommand CmdButtonClick { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public int Number
        {
            get
            {
                return model.Number;
            }
            set
            {
                model.Number = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
            }


        }

        public void UpdateNumber(object sender, EventArgs e)
        {
            Number =random.Next(0, 1000); 
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if((string)parameter == "value0")
                Number = 0;
            else if((string)parameter == "value1000")
                Number = 1000;
        }

        public TimedNumberViewModel()
        {
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += UpdateNumber;
            timer.Start();

            CmdButtonClick = this;
        }
    }
}
