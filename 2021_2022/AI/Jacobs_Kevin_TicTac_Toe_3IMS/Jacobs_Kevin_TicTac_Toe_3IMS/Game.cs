using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Jacobs_Kevin_TicTac_Toe_3IMS
{
        public enum GameState
        {
            Intro,
            Menue,
            Game,
            Options,
            Difficult,
            Exit,
            Winner//,
            //Snake, EasterEggs
            
        }
    internal class Game
    {
        public Game(int height, int width)
        {
            m_Width = width;
            m_Height = height;
            m_Field = new char[height,width];
            m_Option = 0;
            m_Bot = new Difficulty();
            ClearField();
            ClearNumbers(); 

        }
        private void ClearField()
        {
            for (int i = 0; i < m_Height; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    m_Field[i, j] = ' ';
                    
                
                }
                m_Field[i, m_Width - 1] = '\n';
            }

        }
        private void ClearNumbers()
        {
            m_FillInField = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        }
        #region Update
        public void Update(int input)
        {
            --input;
            if (m_FillInField[input] == 'X' || m_FillInField[input] == 'O')
            {
                return;
            }
            if (m_IsPicked)
            {
                if (m_IsPlayerFirst)
                {
                    m_FillInField[input] = 'X';
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }

                    int aiIndex = m_Bot.BestMove(m_FillInField);
                    m_FillInField[aiIndex] = 'O';

                }
                else
                { 
                    m_FillInField[input] = 'X';
                }
                
            }
            else
            {
            //See if you go first or bot
            m_IsPicked = IsOrderPicked(input);
            }

            if (!m_IsPlayerFirst)
            {
                //AI
                int aiIndex = m_Bot.BestMove(m_FillInField);
                m_FillInField[aiIndex] = 'O';
                m_Result = CheckWinner();
                if (m_Result != null)
                {
                    //Change winningscope
                    m_CurrentState = GameState.Winner;
                    return;
                }

            }

        }

        private string CheckWinner()
        {
            char[,] ar = new char[,] { { m_FillInField[0], m_FillInField[1], m_FillInField[2] }, { m_FillInField[3], m_FillInField[4], m_FillInField[5] }, { m_FillInField[6], m_FillInField[7], m_FillInField[8] } }; // I know it's long but I got this far and got lazy to change this please don't kill me
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

        private bool IsOrderPicked(int inp)
        {
            Random r = new Random();
            Random AiChoice = new Random();
            int a = AiChoice.Next(0, 10);
            int rand = r.Next(0, 10);
            int sumAI = Math.Abs(rand - a);
            if (sumAI < Math.Abs(rand - inp) )
            {
                m_IsPlayerFirst = false;
            }
            else if (sumAI >= (rand - inp))
            {
                m_IsPlayerFirst = true;
            }

            return true;
        }
        #endregion
        #region Draw
        public void Draw()
        {
            ClearField();
            Console.Clear();
            switch (m_CurrentState)
            {
                case GameState.Intro:
                    break;
                case GameState.Menue:
                    DrawMenue();
                    break;
                case GameState.Game:
                    if (m_IsPicked)
                    {
                        DrawGame(); 
                    }
                    else
                    {
                        ClearNumbers();
                        DrawPickOrder();
                    }
                    break;
                case GameState.Options:
                    break;
                case GameState.Difficult:
                    break;
                case GameState.Exit:
                    break;
                case GameState.Winner:
                    CalculateText( m_Result + " Is the winner!", m_Height/2);
                    break;
                default:
                    break;
            }

            PrintField();
        }
        private void PrintField()
        {

            for (int i = 0; i < m_Field.GetLength(0); i++)
            {
                for (int j = 0; j < m_Field.GetLength(1); j++)
                {
                    Console.Write(m_Field[i, j]);
                }
            }
        }
        private void DrawMenue()
        {
            //variables
            string[] title;
            int counter = -1;
            //CheckOptions
            title = new string[3] { "Play", "Difficulty", "Options" };
            CheckOptionAboveOrBelowZero(title.Length);
            //Fill Text
            foreach (string elem in title)
            {
                CalculateText(elem, (m_Height /2) + counter++);
            }
            DrawArrow(title[m_Option], (m_Height / 2) - 1);
        }
        private void DrawGame()
        {
            FillBoard();
            Controls();
        }
        private void DrawPickOrder()
        {
            int h = m_Height / 2;
            string sentance = "Pick a number between 0-9 to see who goes first";
            CalculateText(sentance, h);
        }
        private void DrawArrow(string w, int h)
        {
            int wLeng =(m_Width/2) - w.Length;
            m_Field[m_Option + h, wLeng - 3] = '-';
            m_Field[m_Option + h, wLeng - 2] = '>';
        }
        private void NumberLoops()
        {
            int centerX = m_Width / 2;
            int centerY = m_Height / 2;
            int c = 0;
            for (int j = -2; j < 3; j += 2)
            {
                for (int i = -4; i < 5; i+= 4)
                {
                    m_Field[centerY + j, centerX + i] = m_FillInField[c];
                    c++;
                }
            }
        }
        private void Verticalloop()
        {
            int centerX = m_Width / 2;
            int centerY = m_Height / 2;
            for (int j = -2; j < 3; j += 4)
            {
                for (int i = -3; i < 4; i++)
                {

                    m_Field[i + centerY, j + centerX] = '|';
                }
            }
        }
        private void HorizontalLoop()
        {
            int centerX = m_Width / 2;
            int centerY = m_Height / 2;
            for (int j = -1; j < 3; j+=2)
            {
                for (int i = -6; i < 7; i++)
                {
                    m_Field[j + centerY, i + centerX] = '-';
                }
            }
        }
        private void FillBoard()
        {
            Verticalloop();
            HorizontalLoop();
            NumberLoops();
        }
        private void Controls()
        {
            int height = m_Height/4;
            string name = "Tic Tac Toe - " + m_Bot.m_algo.ToString();
            CalculateText(name, height);
            name = "Controls:";
            height = m_Height - height;
            CalculateText(name,height);
            name = "1-9 to place move";
            CalculateText(name, height);
            name = "Press m to go back to menue";
            CalculateText(name, ++height);
        }
        private void CalculateText(string w,int h)
        {
            int leng = w.Length;
            for (int i = 0; i < leng; i++)
            {
                m_Field[h,((m_Width / 2) - (leng / 2)) + i] = w[i];
            }
        }
        private void CheckOptionAboveOrBelowZero(int numberOfOptions)
        {
            if (numberOfOptions -1 < m_Option)
            {
                m_Option = 0;
            }
            else if (m_Option < 0)
            {
                m_Option = numberOfOptions -1;
            }
            
        }
        #endregion
        //Public
        public GameState m_CurrentState { get; set; }
        public char[,] m_Field;
        public int m_Option;
        public Difficulty m_Bot;
        public bool m_IsPicked = false;

        //private
        //Bool
        private bool m_IsPlayerFirst = false;
        private string m_Result;
        //int
        private int m_Width;
        private int m_Height;
        //Arrays
        private char[] m_FillInField;

    }
}
