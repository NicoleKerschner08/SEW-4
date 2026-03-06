using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _21_calcWPF
{
    internal class numberModel
    {
        public int number1 { get; set; }
        public int number2 { get; set; }
        public int result { get; set; } = 0;
        public string staus { get; set; } = "";
        public SolidColorBrush brush { get; set; } = Brushes.Black;
    }
}
