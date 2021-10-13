using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacobs_Kevin_2IMSB_Linear_Probing
{
    class Program
    {
        static void Main(string[] args)
        {
            int modulo = Convert.ToInt32(Console.ReadLine());
            Book_HasSep book = new Book_HasSep(modulo);
            string input = Console.ReadLine();
            do
            {
                book.AddItem(input.Split(',')[0], Convert.ToDouble(input.Split(',')[1]));
                input = Console.ReadLine();
            } while (input != "x");

            book.Print();
            Console.ReadKey();
        }
    }
}
