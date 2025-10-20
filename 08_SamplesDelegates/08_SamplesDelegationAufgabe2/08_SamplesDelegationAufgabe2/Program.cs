using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SamplesDelegationAufgabe2
{
    internal class Program
    {
        enum Subject { SEW, INSY, SYT, M, D, E, NWT, NW2, GGP, PH, BESP, FIT, CCIT, KPT, WIR, RK, ETH, ITP2, PAUSE, ENDE, SUPPL }
        delegate void SubjectSelector(Dictionary<string, Subject[]> plan);
        static void Main(string[] args)
        {
            var plan = new Dictionary<string, Subject[]>
            {
                ["Mo"] = new[] { Subject.GGP, Subject.NW2, Subject.E, Subject.E, Subject.BESP, Subject.WIR, Subject.ENDE, Subject.ENDE, Subject.ENDE, Subject.ENDE },
                ["Di"] = new[] { Subject.CCIT, Subject.CCIT, Subject.ITP2, Subject.ITP2, Subject.INSY, Subject.FIT, Subject.ITP2, Subject.ITP2, Subject.ITP2, Subject.ITP2 },
                ["Mi"] = new[] { Subject.INSY, Subject.INSY, Subject.SYT, Subject.SYT, Subject.CCIT, Subject.CCIT, Subject.ENDE, Subject.ENDE, Subject.ENDE, Subject.ENDE },
                ["Do"] = new[] { Subject.M, Subject.M, Subject.KPT, Subject.WIR, Subject.NW2, Subject.GGP, Subject.PAUSE, Subject.SEW, Subject.SEW, Subject.SEW },
                ["Fr"] = new[] { Subject.RK, Subject.RK, Subject.D, Subject.D, Subject.INSY, Subject.INSY, Subject.ETH, Subject.ENDE, Subject.ENDE, Subject.ENDE }
            };

            Console.WriteLine("Normaler Stundenplan der 4AHIT:");
            printTimetable(plan);

            Console.WriteLine("Achtung! Es werden 5 zufällige Stunden suppliert - Tast drücken:");
            Console.ReadKey();

            Random random = new Random();
            HashSet<(string, int)> ersetzt = new HashSet<(string, int)>();
            int count = 0;
            var tage = plan.Keys.ToArray();

            while (count < 5)
            {
                string tag = tage[random.Next(tage.Length)];
                int stunde = random.Next(10);
                if (!ersetzt.Contains((tag, stunde)) && plan[tag][stunde] != Subject.ENDE && plan[tag][stunde] != Subject.PAUSE)
                {
                    plan[tag][stunde] = Subject.SUPPL;
                    ersetzt.Add((tag, stunde));
                    count++;
                }
            }
            printTimetable(plan);

            Console.WriteLine("Wähle FachSelector-Strategie:");
            Console.WriteLine("1 = Zufall");
            Console.WriteLine("2 = Round-Robin");
            Console.WriteLine("3 = Regelbasiert (Vormittag Technik, Nachmittag Sprachen);");
            Console.Write("Deine Auswahl:");
            int input = int.Parse(Console.ReadLine());
            SubjectSelector action = null;
            switch (input)
            {
                case 1:
                    action = FillSupplWithRandomFach;
                    break;
                case 2:
                    action = roundRobin;
                    break;
                case 3:
                    action = fillWithStrategy;
                    break;
                default:
                    Console.WriteLine("Falsche Eingabe!");
                    Environment.Exit(0);
                    break;
            }
            action(plan);
            printTimetable(plan);
            Console.ReadKey();
        }

        static void fillWithStrategy(Dictionary<string, Subject[]> plan)
        {
            Random random = new Random();
            Subject[] pmSubjects = { Subject.M, Subject.D, Subject.E };
            Subject fillIn;
            Subject[] amSubjects = { Subject.NWT, Subject.INSY, Subject.SEW, Subject.SYT };
            Subject[] validSubjects = Enum.GetValues(typeof(Subject))
                                          .Cast<Subject>()
                                          .Where(s => s != Subject.ENDE && s != Subject.PAUSE)
                                          .ToArray();

            foreach (var tag in plan.Keys)
            {
                for (int stunde = 0; stunde < plan[tag].Length; stunde++)
                {
                    if (plan[tag][stunde] == Subject.SUPPL)
                    {
                        if(stunde > 6)
                        {
                            fillIn = pmSubjects[random.Next(pmSubjects.Length)];
                        }
                        else
                        {
                            fillIn = amSubjects[random.Next(amSubjects.Length)];
                        }
                        plan[tag][stunde] = fillIn;
                    }
                }
            }
        }

        static void FillSupplWithRandomFach(Dictionary<string, Subject[]> plan)
        {
            Random random = new Random();

            // Alle Fächer außer ENDE und PAUSE
            Subject[] validSubjects = Enum.GetValues(typeof(Subject))
                                          .Cast<Subject>()
                                          .Where(s => s != Subject.ENDE && s != Subject.PAUSE)
                                          .ToArray();

            foreach (var tag in plan.Keys)
            {
                for (int stunde = 0; stunde < plan[tag].Length; stunde++)
                {
                    if (plan[tag][stunde] == Subject.SUPPL)
                    {
                        // Zufälliges Fach auswählen
                        Subject randomFach = validSubjects[random.Next(validSubjects.Length)];
                        plan[tag][stunde] = randomFach;
                    }
                }
            }
        }

        static void roundRobin(Dictionary<string, Subject[]> plan)
        {
            Subject[] validSubjects = Enum.GetValues(typeof(Subject))
                                          .Cast<Subject>()
                                          .Where(s => s != Subject.ENDE && s != Subject.PAUSE)
                                          .ToArray();
            int count = 0;
            foreach (var tag in plan.Keys)
            {
                for (int stunde = 0; stunde < plan[tag].Length; stunde++)
                {
                    if (plan[tag][stunde] == Subject.SUPPL)
                    {
                        Subject fillIn = validSubjects[count % validSubjects.Length];
                        plan[tag][stunde] = fillIn;
                        count++;
                    }
                }
            }
        }

        static void printTimetable(Dictionary<string, Subject[]> plan)
        {
            Console.Write("Stunde ");
            foreach (var tag in plan.Keys)
                Console.Write($" {tag,-6}");
            Console.WriteLine();

            for (int stunde = 0; stunde < 10; stunde++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{stunde + 1,6} ");
                foreach (var tag in plan.Keys)
                {
                    string fach = plan[tag][stunde].ToString();
                    if (fach == Subject.SUPPL.ToString())
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {fach,-6}");
                }
                Console.WriteLine();
            }

        }
    }
}
