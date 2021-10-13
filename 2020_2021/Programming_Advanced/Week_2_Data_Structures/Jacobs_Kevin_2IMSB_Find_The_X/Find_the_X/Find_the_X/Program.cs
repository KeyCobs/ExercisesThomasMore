using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_the_X
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string sizeString = Console.ReadLine();
            int x = Convert.ToInt32(sizeString.Split(' ')[0]);
            int y = Convert.ToInt32(sizeString.Split(' ')[1]);
            Matrix m = new Matrix(x, y);
            //m.Print();
            m.FindTheX();

            //End of program
            Console.ReadKey();
        }
    }
}
