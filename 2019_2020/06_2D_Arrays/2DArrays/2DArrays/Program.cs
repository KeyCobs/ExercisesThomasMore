using System;
using System.IO;

namespace _2DArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arrays();
            Console.WriteLine(Arrays2D());
            //ErrorHandling();

        }
        static void Arrays()
        {
            //Frist we converte then we make exercise Find The numbers
            string[] ar = Console.ReadLine().Split(' ');
            PrintArray(ar);

            #region converting 1
            //Converting #1
            double[] ar2 = new double[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                ar2[i] = Convert.ToDouble(ar[i]);

            }

            PrintArray(ar2);
            #endregion


            #region Converting 2
            //Converting #2
            float[] ar3 = Array.ConvertAll(ar, elem => float.Parse(elem));
            int[] ar4 = Array.ConvertAll(ar3, elem => Convert.ToInt32(elem));
            PrintArray(ar3);

            PrintArray(ar4);
            #endregion

            #region Find the numbers
            Console.WriteLine("Find the numbers");
            string[] sentance = Console.ReadLine().Split(' ');
            string s = "";
            foreach (string elem in sentance)
            {
                
                //strings zijn ook arrays!!!
                if (elem[0] <= 57)
                {
                    s += elem +",";
                    Console.Write(elem + " ");
                }
            }
            s = s.Remove(s.Length - 1);
            string [] sarr = s.Split(',');
            
            int[] arr = Array.ConvertAll(sarr, e => Convert.ToInt32(e));
            PrintArray(arr);
            #endregion

        }
        static bool Arrays2D()
        {
            //multiple ways for size

            //It's magic!
            int amount = Convert.ToInt32(Console.ReadLine());
            string[][] input = new string[amount][];
            for (int i = 0;i < input.GetLength(0);i++) // Get Length good for 2D
            {
                //string[] s = Console.ReadLine().Split(' ');
                input[i] = Console.ReadLine().Split(' ');
            }
            //Print2DArray(input);

            
            int[] sum = new int[amount];



            for (int i = 0; i < amount; i++)
            {
                //Check if same length
                if (input.Length != input[i].Length)
                {
                    Console.WriteLine(false);
                    return false;
                }


                for (int j = 0; j < input[i].Length; j++)
                {

                    sum[i] += Convert.ToInt32(input[j][i]);

                }
            }

            for(int i = 0; i < input.Length; i++)
            {
                if (sum[0] == sum[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(false);
                    return false;
                }
            }

            return true;
        }
        static void ErrorHandling()
        {

            //There are 4 mistakes in this exercise
            //Output
            /*
            1 2 3 4 5
            1 + 1 = 2
            2 + 1 = 3
            3 + 1 = 4
            4 + 1 = 5
            5 + 1 = 6
             */

            //string[] input = Console.ReadLine().Split(' ');
            //int[] arr = Array.ConvertAll(input, elem => Convert.ToInt32(elem));

            //for (int i = arr.Length; i >= 0; --i)
            //{
            //    Console.Write(arr[i] + " + 1 = " + arr[i]++ + "\n");
            //}



            //output
            /*
             81 64 82 64 83 64 84 64 85
             */

            //string input2 = Console.ReadLine();
            //for (int i = 1; i <= input2.Length(); j--)
            //{
            //    Console.Write(input2[i] + " ");
            //}



        }
        static void PrintArray<T>(T[] ar)
        {
                Console.Write(typeof(T) + ": ");
            foreach (T e in ar)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
        }        
        
        static void Print2DArray<T>(T[][] ar)
        {
                Console.Write(typeof(T) + ": ");
                Console.Write("\n");
            foreach (T[] e in ar)
            {
                foreach (T e2 in e)
                {
                    Console.Write(e2 + " ");

                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }





        
    }
}
