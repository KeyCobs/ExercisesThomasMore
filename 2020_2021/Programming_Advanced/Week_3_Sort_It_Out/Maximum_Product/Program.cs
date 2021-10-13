using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Product
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            int[] myProducts = new int[userInput.Split(' ').Length];
            FillArray(myProducts, userInput);
            Array.Sort(myProducts);
            FindMaxim(myProducts);

            Console.ReadKey();
        }

        static void FillArray(int[] arr, string ui)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(ui.Split(' ')[i]);
            }
        }
        static void FindMaxim(int [] arr)
        {
            int[] max = new int[2];
            int val1 = arr[0];
            int val2 = arr[1];
            int val3 = arr[arr.Length - 2];
            int val4 = arr[arr.Length - 1] ;
            int total = val1 * val2;
            int total2 = val3 * val4;
            if (total < total2)
            {
                Print(val3, val4);
                return;
            }
            Print(val1, val2);

        }
        static void Print(int val1, int val2)
        {
            Console.Write("Pair is (" + val1 + "," + val2 + ")");
        }
    }
}
