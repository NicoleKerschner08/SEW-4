using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Städteliste
{
    internal class staedtelisteViewModel : ICommand, INotifyPropertyChanged
    {
        public ICommand CmdbuttonClick { get; set; }
        private staedtelisteModel model = new staedtelisteModel();
        int countOfCity = 0;
        public string Namen
        {
            get
            {
                for (int i = 0; i < model.StaedteListe.Count; i++)
                {
                    if (model.StaedteListe[i].Name == model.StaedteListe[countOfCity].Name)
                    {
                        return model.StaedteListe[i].Name;
                    }
                }
                return null;
            }
            set
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Namen)));
            }
        }

        public string Country
        {
            get
            {
                for (int i = 0; i < model.StaedteListe.Count; i++)
                {
                    if (model.StaedteListe[i].Name == model.StaedteListe[countOfCity].Name)
                    {
                        return model.StaedteListe[i].Country;
                    }
                }
                return null;
            }
        }

        public int Population
        {
            get
            {
                for (int i = 0; i < model.StaedteListe.Count; i++)
                {
                    if (model.StaedteListe[i].Name == model.StaedteListe[countOfCity].Name)
                    {
                        return model.StaedteListe[i].Population;
                    }
                }
                return 0;
            }
        }

        public bool isCapital
        {
            get
            {
                for (int i = 0; i < model.StaedteListe.Count; i++)
                {
                    if (model.StaedteListe[i].Name == model.StaedteListe[countOfCity].Name)
                    {
                        return model.StaedteListe[i].isCapital;
                    }
                }
                return false;
            }
        }


        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if ((string)parameter == "back")
            {
                if (countOfCity != 0)
                    countOfCity--;
                else
                    countOfCity = model.StaedteListe.Count - 1;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Namen)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Country)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Population)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(isCapital)));
            }
            else if ((string)parameter == "forward")
            {
                if (countOfCity != model.StaedteListe.Count - 1)
                    countOfCity++;
                else
                    countOfCity = 0;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Namen)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Country)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Population)));
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(isCapital)));
            }
        }

        public staedtelisteViewModel()
        {
            CmdbuttonClick = this;
        }
    }
}
