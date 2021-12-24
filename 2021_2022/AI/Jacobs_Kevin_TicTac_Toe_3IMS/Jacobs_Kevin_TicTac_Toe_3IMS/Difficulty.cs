using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacobs_Kevin_TicTac_Toe_3IMS
{
    enum Algorithm
    {
        MinMax,
        Rand,
        KNN
    }
    internal class Difficulty
    {

        public Difficulty()
        {
            m_algo = Algorithm.MinMax;
        }
        #region KNN (2 Public 2 Private
        public void ReadFile(string filename)
        {
            foreach (var elem in System.IO.File.ReadLines(filename))
            {
                string[] el = elem.Split(' ');
                Data d = new Data(Convert.ToInt32(el[el.Length-1]));
                for (int i = 0; i < el.Length-2; i++)
                {
                    d.dataSet.Add(Convert.ToInt32(el[i]));
                }
                m_SampleData.Add(d);
            }
        }
        public int KNN(char[] arr)
        {

            int[] ari = CreateIntArray(arr);
            List<int> available = new List<int>();
            foreach (int elem in ari)
            {
                
                available.Add(elem);
                
            }
            double max = int.MaxValue;
            int move = 0;
            foreach (Data elem in m_SampleData)
            {
                double score = Distance(ari,elem.dataSet.ToArray());
                if (score > max && available[elem.pos] == 0)
                {
                    max = score;
  
                    move = elem.pos;
                }
            }
            return move;
        }
        private double Distance(int[] current, int[] data)
        {
            if (current.Length != data.Length)
            {
                return double.MaxValue;
            }
            double d = 0;

            for (int i = 0; i < current.Length; i++)
            {
                
                d += Math.Pow(Convert.ToDouble(current[i]) - Convert.ToDouble(data[i]), 2);
            }
            return Math.Sqrt(d);
        }
        private int[] CreateIntArray(char [] arr)
        {
            int[] ari = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 'X')
                {
                    ari[i] = -1;
                }
                else if (arr[i] == 'O')
                {
                    ari[i] = 1;
                }
                else
                {
                    ari[i] = 0;
                }

            }
            return ari;
        }
        #endregion
        #region (1 Public 1 Private
        public int Random(char[] arr)
        {
            Random r = new Random();
            int rand = r.Next(0, 8);
            while (!IsAvailable(rand, arr))
            {
                rand = r.Next(0, 8);
            }

            return rand;
        }
        private bool IsAvailable(int p, char[] ar)
        {
            if (ar[p] == 'X' || ar[p] == 'O')
            {
                return false;
            }
            return true;
        }
        #endregion
        #region MiniMax
        public int BestMove(char[] arrField)
        {
            char[,] ar = new char[,] { { arrField[0], arrField[1], arrField[2] }, { arrField[3], arrField[4], arrField[5] }, { arrField[6], arrField[7], arrField[8] } };
            int bestScore = int.MinValue;
            int move = 0;
            int depth = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //is the spot available
                    if (ar[i,j] > 48 && ar[i,j] < 58)
                    {
                        char temp = ar[i,j];
                        ar[i,j] = 'O';
                        int score = MinMax(ar,depth, false);
                        ar[i,j] = temp;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            move = Convert.ToInt32(ar[i,j] +"") -1;
                        }
                    }
                }
            }

            return move;
        }
        private string CheckWinner(char[,] ar)
        {
            for (int i = 0; i < 3; i++)
            {
                //Horizontal
                if (ar[i, 0] == ar[i, 1] && ar[i, 0] == ar[i, 2])
                {
                    return ar[i, 0].ToString();
                }
                //Vertical
                if (ar[0, i] == ar[1, i] && ar[0, i] == ar[2, i])
                {
                    return ar[0, i].ToString();
                }
            }
            //Diagonal
            if (ar[0, 0] == ar[1, 1] && ar[0, 0] == ar[2, 2])
            {
                return ar[1, 1].ToString();
            }
            else if (ar[0, 2] == ar[1, 1] && ar[0, 2] == ar[2, 0])
            {
                return ar[1, 1].ToString();
            }

            //Tie
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ar[i, j] != 'X' && ar[i, j] != 'O')
                    {
                        return null;
                    }

                }
            }

            return "Tie";
        }
        private int MinMax(char[,] ar,int depth,bool isMax)
        {
            //Checkwin
            string result = CheckWinner(ar);
            if (result != null)
            {
                if (result == "O")
                {
                    return 10;
                }
                else if (result == "X")
                {
                    return -10;
                }
                else
                {
                    return 0;
                }
            }
           
            if (isMax)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (ar[i, j] > 48 && ar[i, j] < 58)
                        {
                            char t = ar[i, j];
                            ar[i, j] = 'O';
                            int score = MinMax(ar, ++depth, false);
                            ar[i,j] = t;
                            if (score > bestScore)
                            {
                                bestScore = score;
                                
                            }
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (ar[i, j] > 48 && ar[i, j] < 58)
                        {
                            char t = ar[i, j];
                            ar[i, j] = 'X';
                           int score = MinMax(ar, ++depth, true);
                            ar[i, j] = t;
                            if (score < bestScore)
                            {
                                bestScore = score;

                            }
                        }
                    }
                }
                return bestScore;
            }
        }
        #endregion

        //Variables
        private List<Data> m_SampleData = new List<Data>(); 
        public Algorithm m_algo;
    }
}
