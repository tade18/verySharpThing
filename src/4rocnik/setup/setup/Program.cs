using System;
using System.Security.Cryptography;

namespace setup
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NumberGenerator();
            
            /*
            for (int i = 0; i <= 100; i++)
            {
                FizzBuzz(i);
            }*/
        }

        public static void FizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }

            if (number % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }

        public static void NumberGenerator()
        {
            int nLow = 0;
            int nHigh = 100;
            Random rLow = new Random();
            int rInt = rLow.Next(nLow, nHigh-2);
            
            Random rHigh = new Random();
            int rInt2 = rHigh.Next(rInt, nHigh);
            
            Random number = new Random();
            int correctNumber = number.Next(rInt, rInt2);
            
            Console.WriteLine("Cislo je mezi "+rInt+" a ");
            Console.Write(rInt2);
            
            while (correctNumber != number)
        }
    }
}