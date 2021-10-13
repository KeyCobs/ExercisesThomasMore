using System;


namespace Hailstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //user input
            int user = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            //int user = 12;
            Hailstone(user);
            Console.ReadKey();
        }

        static void Hailstone(int n)
        {
            Console.Write(n + " ");
            if (n == 1)
            {
                return;
            }
            else if ((n % 2) ==0)
            {
                Hailstone(n / 2);
            }
            else
            {
                Hailstone((n * 3) + 1);
            }

        }
    }
}
