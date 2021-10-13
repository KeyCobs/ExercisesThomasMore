using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //importing
           string userInput = Console.ReadLine();
            //string userInput = "eedoopsnf";
            char[] charArray = new char[userInput.Length];
            FillArray(charArray, userInput);
            CountingSort(charArray);
            Console.ReadKey();
        }

        static void CountingSort(char[] ca)
        {
            int highest = ca[0];
            int lowest = ca[0];
            foreach (int e in ca)
            {
                if (e > highest)
                {
                    highest = e;
                }
                else if (e < lowest)
                {
                    lowest = e;
                }
            }       
    
            int sizeRange = highest - lowest + 1;
            int[] range = new int[sizeRange]; // going from z to a (reverse order) so --
            // creating another one because we are gonna need the values of step 1 only and I change them
            // in step 2 and 3
            int[] rangeStepOne = new int[sizeRange];
            CreateRangeAndPostitions(ca, range,rangeStepOne, highest, lowest);
            string word = CharToString(ca, range);
            Print(word, rangeStepOne);
        }
        static void Print(string s,int[] arr)
        {
            Console.Write(s + "\n");
            Print(arr);
        }
        static void Print(int[] arr)
        {
            foreach (int e in arr)
            {
                Console.Write(e + " ");
            }
        }
        static void CreateRangeAndPostitions(char [] ca,int [] r ,int [] r2,int high,int low)
        {
            //Don't need to countdown but I saw this too late and I am commited.
            for (int i = 0; i < r.Length; i++)
            {
                char check = Convert.ToChar(high - i);
                r[i] = ca.Count(n => n == check);
                r2[i] = ca.Count(n => n == check);
            }
            AddingPosition(r);
        }
        static void AddingPosition(int [] r) //Step 2 adding positions
        {
            for (int i = 1; i < r.Length; i++)
            {
                r[i] += r[i - 1];
            }
            ShiftPostions(r);
        }
        static void ShiftPostions(int [] r)//step 3 shifting positions
        {
            for (int i = r.Length -1; i > 0; i--)
            {
                r[i] = r[i - 1];
            }
            r[0] = 0;
        }
        static void FillArray(char [] ca, string s) //ca == Character array
        {
            for (int i = 0; i < ca.Length; i++)
            {
                ca[i] = s[i];
            }
        }
        static string CharToString(char[] ca,int [] r)
        {
            string word = "";
            int high = ca.Max();
            for (int i = 0; i < r.Length-1; i++)
            {
                if (r[i] != r[i+1])
                {
                    int length = r[i + 1] - r[i];
                    for (int j = 0; j < length; j++)
                    {
                        word += ((char)(high - i)).ToString();
                    }
                }
            }
            int leftOver = ca.Length - r[r.Length - 1];
            for (int i = 0; i < leftOver; i++)
            {
                word += ca.Min().ToString();
            }
            return word;
        }
    }
}
