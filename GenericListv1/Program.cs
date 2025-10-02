using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GenericListv1
{
    public interface ISelector
    {
        bool Select(object obj);
    }

    class StringSelector : ISelector
    {
        public bool Select(object obj)
        {
            if (obj is string)
            {
                return true;
            }
            return false;
        }
    }


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

        public object findFirst(ISelector selector)
        {
            ListEntry currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                if (selector.Select(currentEntry.data))
                {
                    return currentEntry.data;
                }
                currentEntry = currentEntry.next;
            }
            return null;
        }

        public GenericList findAll(ISelector selector)
        {
            GenericList results = new GenericList();
            ListEntry currentEntry = this.firstEntry;
            while (currentEntry != null)
            {
                if (selector.Select(currentEntry.data))
                    results.Add(currentEntry.data);
                currentEntry = currentEntry.next;
            }
            return results;
        }

        public void Remove(ISelector selector)
        {
            while (firstEntry != null && selector.Select(firstEntry.data))
            {
                firstEntry = firstEntry.next;
            }

            ListEntry currentEntry = firstEntry;
            while (currentEntry?.next != null)
            {
                if (selector.Select(currentEntry.next.data))
                {
                    currentEntry.next = currentEntry.next.next;
                }
                else
                {
                    currentEntry = currentEntry.next;
                }
            }
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
            meineListe.Add("Sigma");
            meineListe.Add(new { name = "Dagobert, alter = 70" });
            meineListe.Ausgabe();
            Console.WriteLine("Anzahl der Eintrage: " + meineListe.Count());
            Console.WriteLine("gelöschter Eintrag: " + meineListe.Pop().data);
            meineListe.Ausgabe();
            Console.WriteLine("Anzahl der Eintrage: " + meineListe.Count());
            ISelector selector = new StringSelector();
            object found = meineListe.findFirst(selector);
            Console.WriteLine("Erster String in der Liste: " + found);
            GenericList results = meineListe.findAll(selector);
            results.Ausgabe();
            meineListe.Remove(selector);
            Console.WriteLine("Alle Strings gelöscht: "+meineListe.Ausgabe());
            Console.ReadKey();
        }
    }
}
