using System;
using System.Linq;
//using TM.ProgrammingAdvanced;

namespace Jacobs_Kevin_2IMSB_Big_Brother
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string [] arrayString = Console.ReadLine().Split(" "); //getting values
            // creating array
            int[] arr = new int[arrayString.Length];
            CreateArray(arr, arrayString);

            BigBrother(arr);

            //Console.ReadKey();
        }

        static void BigBrother(int [] arr)
        {
         //   PrintArray(arr);
           

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(CheckBigBrother(arr, i) + " ");
            }

        }

        static int CheckBigBrother(int [] arr, int idx)
        {
            int temp = arr.Max();
            if (temp == arr[idx])
            {
                return -1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[idx] < arr[i] && arr[i] < temp)
                {
                    temp = arr[i];
                }
            }
            return temp;
        }

        static void CreateArray(int [] arr,string [] arrString)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(arrString[i]);
            }
        }

        static void PrintArray(int [] arr)
        { 
            foreach (int e in arr)
            {
                Console.Write(e + " ");
            }
            Console.Write("\n");
        }
    }
}
