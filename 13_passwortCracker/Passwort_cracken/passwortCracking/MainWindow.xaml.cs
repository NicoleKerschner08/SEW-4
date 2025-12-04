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
using PasswordCracker;
using System.Threading;

namespace passwortCracking
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

        private Thread bgThread;

        private void btn_crack(object sender, RoutedEventArgs e)
        {
            string hash = tb_hash.Text;
            string salt = tb_salt.Text;

            ulong start = ulong.Parse(tb_start.Text);
            ulong end = ulong.Parse(tb_end.Text);

            pb_progress.Value = 0;

            bgThread = new Thread(() =>
            {
                for (ulong pw = start; pw <= end; pw++)
                {
                    ulong calcHash = HashFunction.SimpleHash(pw.ToString(), salt);

                    if (calcHash.ToString() == hash)
                    {
                        tb_password.Dispatcher.Invoke(() =>
                        {
                            tb_password.Text = pw.ToString();
                        });
                    }

                    // Fortschritt berechnen
                    double progress = (double)(pw - start) / (double)(end - start) * 100.0;

                    // Fortschritt in UI setzen
                    pb_progress.Dispatcher.Invoke(() =>
                    {
                        pb_progress.Value = progress;
                    });
                }
            });

            bgThread.Start();
        }

    }
}
