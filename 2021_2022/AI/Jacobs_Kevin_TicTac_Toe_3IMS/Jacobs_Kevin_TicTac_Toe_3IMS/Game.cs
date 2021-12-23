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
            Exit//,
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
            ClearField();

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
                    DrawGame();
                    break;
                case GameState.Options:
                    break;
                case GameState.Difficult:
                    break;
                case GameState.Exit:
                    break;
                default:
                    break;
            }

            PrintField();
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
        private void DrawGame()
        {
            FillBoard();


        }
        private void NumberLoops()
        {
            int centerX = m_Width / 2;
            int centerY = m_Height / 2;
            char[] fillInField = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int c = 0;
            for (int j = -2; j < 3; j += 2)
            {
                for (int i = -4; i < 5; i+= 4)
                {
                    m_Field[centerY + j, centerX + i] = fillInField[c];
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

        }
        private void CalculateText(string w,int h)
        {
            int leng = w.Length;
            for (int i = 0; i < leng; i++)
            {
                m_Field[h,((m_Width / 2) - (leng / 2)) + i] = w[i];
            }
        }
        private void DrawArrow(string w, int h)
        {
            int wLeng =(m_Width/2) - w.Length;
            m_Field[m_Option + h, wLeng - 3] = '-';
            m_Field[m_Option + h, wLeng - 2] = '>';
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
        public GameState m_CurrentState { get; set; }
        public char[,] m_Field;
        public int m_Option;
        private int m_Width;
        private int m_Height;
        public Difficulty m_Bot;
    }
}
