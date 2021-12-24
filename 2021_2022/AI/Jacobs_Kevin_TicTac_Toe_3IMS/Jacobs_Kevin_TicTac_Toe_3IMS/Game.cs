using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Winner
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
            m_Bot.ReadFile("data/tictac_single.txt");
            ClearField();
            ClearNumbers(); 

        }

        #region Clearing (5 Private)
        private void ClearField()
        {
            //Make sure the field is reset
            for (int i = 0; i < m_Height; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    m_Field[i, j] = ' ';
                    
                
                }
                m_Field[i, m_Width - 1] = '\n';

            }
            CreateTree();
        }
        private void CreateTree()
        {
            //I lied it's more then a tree
            string[] tree = new string[10];
            string[] Crans = new string[17];
            string[] Santa = new string[18];
            #region ASCII
            //I know don't judge me :p
            tree[0] = @"      /\      ";
            tree[1] = @"     /\*\     ";
            tree[2] = @"    /\O\*\    ";
            tree[3] = @"   /*/\/\/\   ";
            tree[4] = @"  /\O\/\*\/\  ";
            tree[5] = @" /\*\/\*\/\/\ ";
            tree[6] = @"/\O\/\/*/\/O/\";
            tree[7] = "      ||";
            tree[8] = "      ||";
            tree[9] = "      ||";


            Santa[0] = "        i!!!!!!;,";
            Santa[1] = "     .,; i!!!!!'`,uu,o$$bo.";
            Santa[2] = "    !!!!!!!'.e$$$$$$$$$$$$$$.";
            Santa[3] = "   !!!!!!! $$$$$$$$$$$$$$$$$P";
            Santa[4] = "   !!!!!!!,`$$$$$$$$$$$    p";
            Santa[5] = "!!!!!!!!!'P..,e$$$$$$$$   ?";
            Santa[6] = "`!!!!!!!!z$'J$$$$$'.,$bd$b,";
            Santa[7] = " `!!!!!!f;$'d$$$$$$$$$$$$$P',";
            Santa[8] = "  !!!!!! $B,` ?$$$$$P',uggg$$$$";
            Santa[9] = "  !!!!!!.$$$$be.  zd$$$P .,uooe";
            Santa[10] = "  `!!!',$$$$$$$$$c,$$,ud$$$$$$$";
            Santa[11] = "   !! $$$$$$$$$$$$$$$$$$$$$$$$$$";
            Santa[12] = "   !'j$$$$$$$$$$$$$$$$$$$$$$$$$$";
            Santa[13] = " d@@,?$$$$$$$$$$$$$$$$$$$$$$$$$$";
            Santa[14] = " ?@@f:$$$$$$$$$$$$$$$$$$$$$$$$$";
            Santa[15] = "      $$$$$$$$$$$$$$$$$$$$$$$$";
            Santa[16] = "      `3$$$$$$$$$$$$$$$$$$$$$";
            Santa[17] = "           $$$$$$P?$$$$$$$";

            Crans[0] = @"        .----.";
            Crans[1] = @"      .'`.  .'`.";
            Crans[2] = @"     /-._:--:_.-\";
            Crans[3] = @"    |-._/    \ _.|";
            Crans[4] = @"    |._ |    |' _|";
            Crans[5] = @"    `---'    |-' |";
            Crans[6] = @"             |.-'|";
            Crans[7] = @"             |_.-|";
            Crans[8] = @"             | _.|";
            Crans[9] = @"             |' _|";
            Crans[10] = @"             |-' |";
            Crans[11] = @"             |.-'|";
            Crans[12] = @"             |_.-|";
            Crans[13] = @"             | _.|";
            Crans[14] = @"             |' _|";
            Crans[15] = @"             |-' |";
            Crans[16] = @"             `---'";
            #endregion

            if (m_CurrentState == GameState.Menue )
            {
                PrintImageRight(Santa);
                PrintImageLeft(Crans);
            }
            if (m_CurrentState == GameState.Options || m_CurrentState == GameState.Difficult)
            {
                PrintImageLeft(tree);
            }
        }
        private void PrintImageRight(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    int width = m_Width / 2 + 7 + j;
                    int heigh = (m_Height / 2) - (arr.Length / 2) + i;
                    m_Field[heigh, width] = arr[i][j];
                }
            }
        }
        private void PrintImageLeft(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    int width = 3 + j;
                    int heigh = (m_Height / 2) - (arr.Length / 2) + i;
                    m_Field[heigh, width] = arr[i][j];
                }
            }
        }
        private void ClearNumbers()
        {
            m_FillInField = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        }
        #endregion
        #region Update (1 Public 5 Private)
        public void Update(int input)
        {
            --input;
            switch (m_Bot.m_algo)
            {
                case Algorithm.MinMax:
                    MiniMax(input);
                    break;
                case Algorithm.Rand:
                    Random(input);
                    break;
                case Algorithm.KNN:
                    KNN(input);
                    break;
                default:
                    break;
            }
        }
        private void KNN(int input)
        {
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
                    //check if available else 2nd closest
                    m_FillInField[m_Bot.KNN(m_FillInField)] = 'O';
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }
                }
                else
                {
                    m_FillInField[input] = 'X';
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }
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
                m_FillInField[m_Bot.KNN(m_FillInField)] = 'O';
                m_Result = CheckWinner();
                if (m_Result != null)
                {
                    //Change winningscope
                    m_CurrentState = GameState.Winner;
                    return;
                }

            }
        }
        private void Random(int input)
        {
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
                    m_FillInField[m_Bot.Random(m_FillInField)] = 'O';
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }
                }
                else
                {
                    m_FillInField[input] = 'X';
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }
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
                m_FillInField[m_Bot.Random(m_FillInField)] = 'O';
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
        private void MiniMax(int input)
        {
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
                    m_Result = CheckWinner();
                    if (m_Result != null)
                    {
                        //Change winningscope
                        m_CurrentState = GameState.Winner;
                        return;
                    }
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
        #region Draw (2 Publics 5 Private)
        public void Draw()
        {
            //DrawMenue, DrawGame and DrawPickorder, etc,.. Can be combined in one function. It the same function with different values. But lack due time I put them sepperatly
            ClearField();
            Console.Clear();
            switch (m_CurrentState)
            {
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
                    DrawOptions();
                    break;
                case GameState.Difficult:
                    DrawDifficult();
                    break;
                case GameState.Winner:
                    if (m_Result == "Tie")
                    {
                        CalculateText("It's a Tie!", m_Height / 2);
                    }
                    else
                    {
                    CalculateText( m_Result + " Is the winner!", m_Height/2);
                    }
                    CalculateText( "Press 'R' to restard and 'M' to go back to menue", m_Height/2 + 1);
                    m_IsPicked = false;
                    ClearNumbers();
                    break;
                default:
                    break;
            }

            //Print our field
            PrintField();
        }
        public void DrawIntro()
        {
            Console.Clear();
            string intro = "Game made by: Kevin ";
            Console.SetCursorPosition(m_Width/2 - intro.Length/2,0);
            for (int i = 1; i < m_Height/2; i++)
            {
                Console.SetCursorPosition(m_Width/2 - intro.Length/2,i);
                Console.Write(intro);
                Console.SetCursorPosition(m_Width / 2 - (intro.Length / 2), i-1);
                Console.Write("                    ");
                Thread.Sleep(200);
            }
            Thread.Sleep(3000);
        }
        public void DrawOutro()
        {
            Console.Clear();
            string intro = "Thank you for playing! Hope you liked it! And thank you for all the classes!";
            Console.SetCursorPosition(m_Width / 2 - intro.Length / 2, 0);
            for (int i = 1; i < m_Height / 2; i++)
            {
                Console.SetCursorPosition(m_Width / 2 - intro.Length / 2, i);
                Console.Write(intro);
                Console.SetCursorPosition(m_Width / 2 - (intro.Length / 2), i - 1);
                Console.Write("                                                                              ");
                Thread.Sleep(300);
            }
            Thread.Sleep(3000);
        }
        private void DrawOptions()
        {
            string[] titles = { "Mute", "Lower Volume", "Higher Volume", "Play Music", "Stop Music", "Back" };
            int c = -1*(titles.Length/2);// make negative
            CheckOptionAboveOrBelowZero(titles.Length);
            foreach (string elem in titles)
            {
                CalculateText(elem, (m_Height / 2) + ++c);
            }
            DrawArrow(titles[m_Option], m_Height / 2 - (titles.Length / 2) + 1);
        }
        private void DrawDifficult()
        {
            string[] options = { "MiniMax - Impossible", "Random - Lucky", "KNN - douable", "Back" };
            CheckOptionAboveOrBelowZero(options.Length);
            int counter = -1 * (options.Length / 2); 
            foreach (string elem in options)
            {
                CalculateText(elem, (m_Height / 2) + ++counter);
            }
            DrawArrow(options[m_Option], ((m_Height / 2)  - (options.Length / 2) + 1));
        }
        private void DrawArrow(string w, int h)
        {
            int wLeng =(m_Width/2) - w.Length;
            m_Field[m_Option + h, wLeng - 3] = '-';
            m_Field[m_Option + h, wLeng - 2] = '>';
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
        #region Menue
        private void DrawMenue()
        {
            //variables
            string[] title;
            //CheckOptions
            title = new string[4] { "Play", "Difficulty", "Options", "Exit" };
            int counter = -1 * (title.Length / 2);
            CheckOptionAboveOrBelowZero(title.Length);
            //Fill Text
            foreach (string elem in title)
            {
                CalculateText(elem, (m_Height /2) + ++counter);
            }
            DrawArrow(title[m_Option], (m_Height / 2) - (title.Length / 2) + 1);
        }
        #endregion
        #region Game
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
            Controls();
        }
        private void DrawPickOrder()
        {
            int h = m_Height / 2;
            string sentance = "Pick a number between 0-9 to see who goes first";
            CalculateText(sentance, h);
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
        #endregion
        #endregion

        //Public
        public GameState m_CurrentState { get; set; }
        public Difficulty m_Bot;
        public int m_Option;
        public char[,] m_Field;
        public bool m_IsPicked = false;

        //private
        //Bool
        private bool m_IsPlayerFirst = false;
        //int
        private int m_Width;
        private int m_Height;
        //Arrays
        private char[] m_FillInField;
        private string m_Result;

    }
}
