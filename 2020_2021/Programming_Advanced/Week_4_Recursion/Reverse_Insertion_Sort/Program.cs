using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //input user
             string[] userStr = Console.ReadLine().Split(' ');
             int[] userInt = Array.ConvertAll(userStr, e => Convert.ToInt32(e)); //converting str to int
            //int[] userInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 19 };
            Insertion(userInt, userInt.Length - 1);
            Print(userInt);
            Console.ReadKey();
        }
        static void Print(int [] a)
        {
            foreach (int e in a)
            {
                Console.Write(e + " ");
            }
            Console.Write("\n");
        }

        static void Insertion(int [] arr, int i)
        {
            int current = arr[i];
            int next = arr[i - 1];
            Print(arr);
            if (current > next)
            {
                DoInsert(arr, i); //recursion
                
            }
            --i;
            if (i >= 1)
            {
                Insertion(arr, i);
            }

            return;
        }

        static void DoInsert(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return;
            }
            int move = arr[index - 1];
            
            if (arr[index] > arr[index -1])
            {
                arr[index - 1] = arr[index];
                arr[index] = move;
                DoInsert(arr, index + 1);
            }
            else
            {
                return;
            }
        }
    }
}
