using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_personenFiltern
{

    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Geburtsjahr { get; set; }

        public Person(string vorname, string nachname, int geburtsjahr) {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsjahr = geburtsjahr;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person("Max", "Mustermann", 2005));
            persons.Add(new Person("Andra", "Dumitrascu", 2007));
            persons.Add(new Person("Roman", "Haider", 2008));
            persons.Add(new Person("Armin", "Fluch", 2008));
            persons.Add(new Person("Anna", "Lyse", 2000));
            Predicate<Person> findPersonWithA = findPersonsWithA;
            List<Person> list = persons.FindAll(findPersonsWithA);
            Console.WriteLine("Personen die mit A anfangen:");
            foreach(Person p in list){
                Console.WriteLine(p.Vorname + " " + p.Nachname + " " + p.Geburtsjahr);
            }
            Predicate<Person> findPersonOlderThan2007 = methodFindPersonOlderThan2007;
            list = persons.FindAll(findPersonOlderThan2007);
            Console.WriteLine("Personen, die nach 2007 geboren wurden:");
            foreach (Person p in list)
            {
                Console.WriteLine(p.Vorname + " " + p.Nachname + " " + p.Geburtsjahr);
            }
            Console.ReadKey();
        }
        public static bool findPersonsWithA(Person person)
        {
            if (person.Vorname.StartsWith("A"))
            {
                return true;
            }
            else
                return false;
        }

        public static bool methodFindPersonOlderThan2007(Person person) {
            if(person.Geburtsjahr > 2007)
                return true;
            else 
                return false;
        }
    }
}
