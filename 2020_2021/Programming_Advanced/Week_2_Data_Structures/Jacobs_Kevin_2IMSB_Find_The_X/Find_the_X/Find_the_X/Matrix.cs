using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_the_X
{
    class Matrix
    {
        //public
        public Matrix(int x, int y)
        {
            m_Matrix = new int[x, y];
            FillArray(x,y);
        }
        public void Print()
        {
            for (int i = 0; i < m_Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m_Matrix.GetLength(1); j++)
                {
                    Console.Write(m_Matrix[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        public void FindTheX()
        {
            int max = -1;

            if (m_Matrix.GetLength(0) >= 3 && m_Matrix.GetLength(1) >= 3)
            {
                //x,y is a dimension of 3 by 3 so the need to be bigger then 3 or 3
                int x = m_Matrix.GetLength(0) - 3; 
                int y = m_Matrix.GetLength(1) - 3;
                for (int i = 0; i <= x; i++)
                {
                    for (int j = 0; j <= y; j++)
                    {
                        int check = m_Matrix[i, j]; //left up
                        check += m_Matrix[i+2, j];// right up
                        check += m_Matrix[i+1, j+1];//center
                        check += m_Matrix[i, j+2];//left down
                        check += m_Matrix[i+2, j+2];//right down
                        if (check > max)
                        {
                            max = check;
                        }
                    }
                }
            }
            Console.Write(max);
        }


        //private
        private int[,] m_Matrix;
        private void FillArray(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < y; j++)
                {
                    m_Matrix[i, j] = Convert.ToInt32(data.Split(' ')[j]); 
                }
            }
        }
    }
}
