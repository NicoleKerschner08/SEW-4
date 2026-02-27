using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TextObservers
{
    internal class LabelObserver
    {
        private Label label;
        public LabelObserver(Label label)
        {
            this.label = label;
        }

        public void Update(string txt)
        {
            label.Content = txt;
        }
    }
}
