using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _23_Click_Counter
{
    internal class ViewModel: INotifyCollectionChanged, ICommand, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        private ObservableCollection<LogEntry> collection = new ObservableCollection<LogEntry>();
        public ICommand cmdClick { get; }

        public ViewModel() { 
            cmdClick = this;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                ((INotifyCollectionChanged)Collection).CollectionChanged += value;
            }

            remove
            {
                ((INotifyCollectionChanged)Collection).CollectionChanged -= value;
            }
        }

        public ObservableCollection<LogEntry> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
            }
        }

        public string count { get { return "Gesamtanzahl der Klicks: "+ collection.Count; } }

        public bool CanExecute(object parameter)
        {
            if ((string)parameter == "clear")
            {
                if (collection.Count > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public void Execute(object parameter)
        {
            if((string)parameter == "log")
            {
                LogEntry entry = new LogEntry();
                entry.Id = collection.Count + 1;
                collection.Add(entry);
            }
            else if((string)parameter == "clear")
            {
                collection.Clear();
            }
            else { }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(count)));
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
