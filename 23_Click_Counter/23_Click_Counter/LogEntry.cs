using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_Click_Counter
{
    internal class LogEntry
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return "Klick#"+Id + " " + TimeStamp.ToString("HH:mm:ss");
        }
    }
}
