using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Sort_It_Out_exercise
{
    struct SortArray
    {
        public int sortValue { get; set; }
        public char value { get; set; }
       public SortArray(char c)
        {
            value = c;
            sortValue = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //filling arrays
            string[] str = Console.ReadLine().Split(' ');
            SortArray[] myArray = new SortArray[str.Length];
            //calculate possiblities
            string[] outcomes = new string[CalculateDifferentOutcome(str.Length)];
            //filling struct
            for (int i = 0; i < str.Length; i++)
            {
                myArray[i].value = Convert.ToChar(str[i]);
            }
            //index all outcomes
            int index = 0;
            int count = 0; // for fun
            while (outcomes.Last() == null)
            {
                ++count;
                //step 1: Give random values to sort them randomly
                RandomSort(myArray);
                //step 2: sort them using a selection sort so we get the right order(the boggus order)
                SelectionSort(myArray);
                //step 3: convert Char Array to string for step 4
                string order = ConvertStructToString(myArray);
                //step 4: Check if we already had this combination
                if (!outcomes.Contains(order))
                {
                    outcomes[index++] = order;
                }
            }
            //When we found all possibilities we print out all the combo's
         //   Console.Write("Yay you found all combos in " + count + " tries\n");
            PrintArray(outcomes);
            Console.ReadKey();
        }

        static void PrintArray<T>(T[] a)
        {
            foreach (T e in a)
            {
                Console.Write(e + "\n");
            }
        }
        static void RandomSort(SortArray[] sa)
        {
            Random rnd = new Random();
            for (int i = 0; i < sa.Length; i++)
            {
                 sa[i].sortValue = rnd.Next(0, 101);
            }

        }
        static void SelectionSort(SortArray[] sa)
        {
            SortArray temp;
            int delim, index = 0;
            for (int i = 0; i < sa.Length; i++)
            {
                delim = sa[i].sortValue;
                index = i;
                for (int j = i+1; j < sa.Length; j++)
                {
                    if (delim > sa[j].sortValue)
                    {
                        index = j;
                        delim = sa[j].sortValue;
                    }
                }
                temp = sa[i];
                sa[i] = sa[index];
                sa[index] = temp;
            }
        }
        static int CalculateDifferentOutcome(int length)
        {
            int possiblilities =1;
            for (int i = 2; i <= length; i++)
            {
                possiblilities *= i;
            }

            return possiblilities;
        }
        static string ConvertStructToString(SortArray[] sa)
        {
            string structToString = "";
            foreach (SortArray e in sa)
            {
                structToString += e.value;
            }
            return structToString;
        }
    }
}
