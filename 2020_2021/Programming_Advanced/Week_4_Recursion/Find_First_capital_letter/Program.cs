using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            string input = Console.ReadLine();
            //string testcase = "aberTo";
            //Print Upper
            Console.Write(FindUpper(0, input));
            //Console.Write(FindUpper(0, testcase));

            Console.ReadKey();
        }

        static string FindUpper(int i, string str)
        {
            //check if we arrived at the end and thus no string left
            if (i < str.Length) //I check wit ASCII values 97 is a and 65 is A
            {
               if ((str[i] + 0) > 96)
               {
                  return FindUpper(++i, str);
               }
               else
               {
                   return str[i].ToString();
               }
            }
            else
            {
             //Console.Write("No Upper char in string\n");
             return "";
            }
        }
    }
}
