using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            //import file
            string file = "english.txt";
            string errorMessage = "Error: Wrong file input. Check your Path or spelling mistake. should be english.txt not " + file;
            //input user
            string userInput = Console.ReadLine();
            //Check if file exist
            if (System.IO.File.Exists(file))
            {
                //Input everything in a array
                string[] wordList = System.IO.File.ReadAllLines(file);
                Console.Write("position " + BinarySearch(wordList,userInput,0,wordList.Length -1));
            }
            else
            {
                Console.Write(errorMessage);
            }
            Console.ReadKey();
        }

        static int BinarySearch(string [] arr, string search,int left,int right)
        {
            if (left <= right)
            {
                int currentNode = left + (right - left) / 2;
                //Check if need to go left or right
                int result = search.CompareTo(arr[currentNode]);
                if (result == 0)
                {
                    return currentNode + 1;
                }
                if (result > 0) //right
                {
                   return BinarySearch(arr, search, currentNode + 1, right);
                }
                else
                {
                   return BinarySearch(arr, search, left, currentNode - 1);
                }
            }
            return -1;
        }
    }
}
