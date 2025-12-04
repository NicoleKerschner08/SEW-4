using PasswordCracker;
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

namespace _13_passwordCracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_compute(object sender, RoutedEventArgs e)
        {
            HashFunction hashFunction = new HashFunction();
            string password = tb_password.Text;
            string salt = tb_salt.Text;
            ulong hash = HashFunction.SimpleHash(password, salt);
            tb_hashcode.Text = hash.ToString();
        }
    }
}
