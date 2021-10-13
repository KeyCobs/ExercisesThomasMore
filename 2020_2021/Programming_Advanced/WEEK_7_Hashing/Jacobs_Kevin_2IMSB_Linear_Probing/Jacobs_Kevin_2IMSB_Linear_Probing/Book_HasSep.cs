using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacobs_Kevin_2IMSB_Linear_Probing
{
    class Book_HasSep
    {
        //public
        public Book_HasSep(int size)
        {
            m_Size = 0;
            SetSize(size);
            
        }


        public int Hashing(string key)
        {
            long newKey = 0;
            for (int i = 0; i < key.Length; i++)
            {
                newKey = (31 * newKey) + key[i];
            }
            
            return Convert.ToInt32(newKey % m_Size);
        }

        
        public void AddItem( string name, double value)
        {
            int key = Hashing(name);
            int count = 0;
            while (!CheckEmpty(key) && count < m_Size)
            {
                ++count;
                ++key;
                if (key == m_Size)
                {
                    key = 0;
                }
            }

            if (count == m_Size)
            {
                Console.Write("No Space available\n");
            }
            else
            {
                m_Table[key] = new List<KeyValuePair<string, double>>();
                m_Table[key].Add(new KeyValuePair<string, double>(name, value));  
            }
        }

        public void Print()
        {
            foreach (List<KeyValuePair<string, double>> e in m_Table)
            {
                if (e != null)
                {
                    foreach (KeyValuePair<string, double> elem in e)
                    {
                        Console.Write(elem.Key + " " + elem.Value + "\n");
                    }
                }
                else
                {
                    Console.Write("null" + '\n');
                }
            }
        }

        //private
        private List<KeyValuePair<string, double>>[] m_Table;
        private int m_Size;
        private bool CheckEmpty(int key) 
        {
            if (m_Table[key] == null)
            {
                return true;
            }
            return false;
        }
        private void SetSize(int size)
        {
            int newSize = NextPrime((int)Math.Ceiling(size * 1.3));
            m_Table = new List<KeyValuePair<string, double>>[newSize];
            m_Size += newSize;
        }


        ////////
        private bool isPrime(int n)
        {
            for (int i = 4; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private int NextPrime(int n)
        {
            while (!isPrime(n)) n++;
            return n;
        }
    }
}
