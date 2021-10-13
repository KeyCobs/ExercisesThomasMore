using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsMissing
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] num = Console.ReadLine().Split().Select(Int32.Parse).ToArray();
            Console.Write(MissingBigNum(num.Length-1,num.Length-2,num));


            Console.ReadKey();
        }

        static float MissingBigNum(int i, int iNext, int [] num)
        {
            if (iNext < 0)
            {
                return -1;
            }
            if (num[i] == num[iNext] + 1)
            {

                return MissingBigNum(--i, --iNext, num);
                
            }

            return num[iNext] + ((num[i] - num[iNext]) / 2.0f);
        }
    }
}
