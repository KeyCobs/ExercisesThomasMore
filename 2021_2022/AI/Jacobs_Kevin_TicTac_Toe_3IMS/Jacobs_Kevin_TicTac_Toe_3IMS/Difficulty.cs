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
        Rand
    }
    internal class Difficulty
    {
        public Difficulty()
        {
            m_algo = Algorithm.MinMax;
        }
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
        public Algorithm m_algo;
    }
}
