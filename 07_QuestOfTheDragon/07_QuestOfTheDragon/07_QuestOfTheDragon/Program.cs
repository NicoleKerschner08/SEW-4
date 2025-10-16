using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _07_QuestOfTheDragon
{

    public class Character
    {
        public string name = "";
        public int life;
        public int attackStrength;

        public Character(string name, int life, int attackStrength)
        {
            this.name = name;
            this.life = life;
            this.attackStrength = attackStrength;
        }

        public void showStatus()
        {
            Console.WriteLine($"Name: {name}, Leben: {life}, Angriffskraft: {attackStrength}");
        }

        public void normalAttack(Character attacker, Character target)
        {
            target.life = target.life - attacker.attackStrength;
        }

        public void heal(Character attacker, Character target)
        {
            if(attacker.life < 90)
            {
                attacker.life += 10;
            }

            target.life += 5;
        }

        public void specialAttack(Character attacker, Character target)
        {
            target.life -= attacker.attackStrength * 2;
            attacker.life -= 5;
        }

        public void executeAction(Character attacker, Character target, fightingAction action)
        {
            action(attacker, target);
            attacker.showStatus();
            target.showStatus();
        }
    }

    public delegate void fightingAction(Character attacker, Character target);
    internal class Program
    {
        static void Main(string[] args)
        {
            Character Hero = new Character("Held", 100, 30);
            Character Dragon = new Character("Drache", 100, 35);
            do
            {
                Console.WriteLine("Welche Aktion möchtest du durchführen (1 = Angriff, 2 = Heilen, 3 = Spezialangrif):");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Hero.executeAction(Hero, Dragon, Hero.normalAttack);
                        break;
                    case 2:
                        Hero.executeAction(Hero, Dragon, Hero.heal);
                        break;
                    case 3:
                        Hero.executeAction(Hero,Dragon, Hero.specialAttack);
                        break;
                    default:
                        Console.WriteLine("Falsche Eingabe");
                        break;
                } 
            } while (Hero.life > 0 || Dragon.life > 0);

        } 
    }
}
