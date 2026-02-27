using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextObservers
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void TextUpdate(string s);

        event TextUpdate TextEvent;

        public MainWindow()
        {
            InitializeComponent();

            TextEvent += (new LabelObserver(Label1)).Update;
            TextEvent += (new LabelObserver(Label2)).Update;
            TextEvent += (new LabelObserver(Label3)).Update;
            TextEvent += (new LabelObserver(Label4)).Update;
            TextEvent += (new LabelObserver(Label5)).Update;
        }

        private void tbxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextEvent.Invoke(tbxTextBox.Text);
        }
    }
}
