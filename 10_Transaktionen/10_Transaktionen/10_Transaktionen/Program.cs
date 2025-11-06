using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _10_Transaktionen
{


    class BankAccount
    {
        public char AccountNumber;
        public double Balance;
        public static Object blockBalance = new Object();
        public double added_deleted_money = 0;

        public BankAccount(char accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public void Deposit(double amount)
        {
            lock (blockBalance)
            {
                added_deleted_money += amount;
                Balance += amount;
                Console.WriteLine($"Zahlt {amount}Euro von Konto {AccountNumber} ein");
                
            }

        }

        public void Withdraw(double amount) 
        {
            lock (blockBalance)
            {
               added_deleted_money -= amount;
               Balance -= amount;
               Console.WriteLine($"Hebt {amount}Euro von Konto {AccountNumber} ab");
            }
        }

        public void Transfer(BankAccount target, double amount) 
        {
            Withdraw(amount);
            target.Deposit(amount);
            Console.WriteLine($"Überweist {amount}Euro von Konto {AccountNumber} zu Konto {target.AccountNumber}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double startMoney = 0;
            int asciiValue = 65;
            double currentMoney = 0;
            double added_deleted_money = 0;
            List<BankAccount> accounts = new List<BankAccount>();
            Random rand = new Random();
            for(int i = 0; i < 10; i++)
            {
                BankAccount a = new BankAccount((char)asciiValue, rand.Next(1000, 10000)*2);
                accounts.Add(a);
                asciiValue++;
            }
            foreach (BankAccount a in accounts)
            {
                Console.WriteLine($"Konto {a.AccountNumber} hat eine Kontostand von {a.Balance}Euro");
                startMoney += a.Balance;
            }
            Thread t1 = new Thread(() => accounts[0].Deposit(500));
            Thread t2 = new Thread(() => accounts[1].Withdraw(200));
            Thread t3 = new Thread(() => accounts[2].Transfer(accounts[5], 1000));
            Thread t4 = new Thread(() => accounts[3].Deposit(300));
            Thread t5 = new Thread(() => accounts[4].Withdraw(150));
            Thread t6 = new Thread(() => accounts[5].Transfer(accounts[8], 600));
            Thread t7 = new Thread(() => accounts[6].Deposit(400));
            Thread t8 = new Thread(() => accounts[7].Withdraw(250));
            Thread t9 = new Thread(() => accounts[8].Transfer(accounts[2], 800));
            Thread t10 = new Thread(() => accounts[9].Deposit(100));
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();
            t9.Start();
            t10.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();
            t9.Join();
            t10.Join();
            foreach (BankAccount a in accounts)
            {
                Console.WriteLine($"Konto {a.AccountNumber} hat eine Kontostand von {a.Balance}Euro");
                currentMoney +=a.Balance;
                added_deleted_money += a.added_deleted_money;
            }
            Console.WriteLine("Summe aller Konten: " + currentMoney);
            if (currentMoney == startMoney + added_deleted_money)
            {
                Console.WriteLine("Alles wurde richtig überwiesen!");
            }
            else
                Console.WriteLine("Es gab Probleme beim überweisen!");
            Console.ReadKey();
        }
    }
}
