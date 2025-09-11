using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList
    {
        private ListEntry firstEntry = null;
        public void Add(object data)
        {
            ListEntry newEntry = new ListEntry();
            newEntry.data = data;
            newEntry.next = firstEntry;
            firstEntry = newEntry;
        }

        public void Ausgabe()
        {
            ListEntry currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                Console.WriteLine(currentEntry.data);
                currentEntry = currentEntry.next;
            }
        }

        public int Count()
        {
            int count = 0;
            ListEntry currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                count++;
                currentEntry = currentEntry.next;
            }
            return count;
        }

        public ListEntry Pop()
        {
            ListEntry temp = firstEntry;
            this.firstEntry = firstEntry.next;
            return temp;
        }
    }
    class ListEntry
    {
        public ListEntry next;
        public object data;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList meineListe = new GenericList();
            meineListe.Add("Hallo");
            meineListe.Add(345.5);
            meineListe.Add(new { name = "Dagobert, alter = 70" });
            meineListe.Ausgabe();
            Console.WriteLine("Anzahl der Eintrage: "+meineListe.Count());
            Console.WriteLine("gelöschter Eintrag: "+meineListe.Pop().data);
            meineListe.Ausgabe();
            Console.WriteLine("Anzahl der Eintrage: " + meineListe.Count());
            Console.ReadKey();
        }
    }
}
