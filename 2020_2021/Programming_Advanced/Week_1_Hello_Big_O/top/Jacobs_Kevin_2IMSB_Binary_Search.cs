using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Jacobs_Kevin_2IMSB_BinarySearch
{
    class Jacobs_Kevin_2IMSB_Binary_Search
    {
        static int attampts = 0;
        static void Main(string[] args)
        {
            //variables
            string file = "english.txt";
            string search = Console.ReadLine(); //grabbing value
            //error variables
            string errorFile = "Error: Cannot read file >> " + file + "\nPlease make sure your naming is correct and is in the right location.";
            //check if file exist
            if (File.Exists(file))
            {
                //Create word list
                string [] wordList = File.ReadAllLines(file);
                Console.Write("position " + BinarySearch(wordList, search) + " in " + attampts + " guesses");
            }
            else
            {
                Console.Write(errorFile);
            }
            //Stops the program from closing to check results
            Console.ReadKey();
        }

        private static int BinarySearch(string [] wordList,string search)
        {
            //variables
            int left = 0;
            int right = wordList.Length - 1; // -1 because start at 0
            while (left <= right)
            {
                attampts++;
                int currentNode = left + (right - left) / 2;
                //check if need to go left or right
                int result = search.CompareTo(wordList[currentNode]); //compare: 0 = same position, smaller is left side, bigger is right side
                //found index
                if (result == 0)
                {
                    return currentNode +1; //starting from 1
                }
                //go Right
                if (result > 0)
                {
                    left = currentNode + 1;
                }
                else
                {
                    //go left
                    right = currentNode - 1;
                }
            }
            return -1;
        }
    }
}
