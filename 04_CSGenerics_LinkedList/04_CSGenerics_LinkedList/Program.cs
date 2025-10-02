using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CSGenerics_LinkedList
{
    class GenericList<T>
    {
        private ListEntry<T> firstEntry = null;
        public void Add(T data)
        {
            ListEntry<T> newEntry = new ListEntry<T>();
            newEntry.data = data;
            newEntry.next = firstEntry;
            firstEntry = newEntry;
        }

        public void Ausgabe()
        {
            ListEntry<T> currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                Console.Write(currentEntry.data + " ,");
                currentEntry = currentEntry.next;
            }
            Console.WriteLine();
        }

        public int Count()
        {
            int count = 0;
            ListEntry<T> currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                count++;
                currentEntry = currentEntry.next;
            }
            return count;
        }

        public ListEntry<T> Pop()
        {
            ListEntry<T> temp = firstEntry;
            this.firstEntry = firstEntry.next;
            return temp;
        }

        public void shiftFwd(int shiftValue)
        {
            if (shiftValue <= 0 && this.firstEntry == null && this.firstEntry.next == null)
                return;
            ListEntry<T> lastEntry = firstEntry;
            ListEntry<T> currentEntry = firstEntry;
            for(int i = 0; i < shiftValue; i++)
                currentEntry = currentEntry.next;
            firstEntry = currentEntry;
            while(currentEntry.next != null)
                currentEntry = currentEntry.next;
            currentEntry.next = lastEntry;
            for (int i = 0; i < shiftValue; i++)
                currentEntry = currentEntry.next;
            currentEntry.next = null;      
        }

        public void shiftBwd(int shiftValue)
        {
            if (shiftValue <= 0 && this.firstEntry == null && this.firstEntry.next == null)
                return;
            shiftFwd(this.Count()-shiftValue);
        }
    }
    class ListEntry<T>
    {
        public ListEntry<T> next;
        public T data;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<char> meineListe = new GenericList<char>();
            meineListe.Add('F');
            meineListe.Add('E');
            meineListe.Add('D');
            meineListe.Add('C');
            meineListe.Add('B');
            meineListe.Add('A');
            meineListe.Ausgabe();
            meineListe.shiftFwd(2);
            meineListe.Ausgabe();
            meineListe.shiftBwd(2);
            meineListe.Ausgabe();
            meineListe.shiftBwd(3);
            meineListe.Ausgabe();
            Console.ReadKey();
        }
    }
}
