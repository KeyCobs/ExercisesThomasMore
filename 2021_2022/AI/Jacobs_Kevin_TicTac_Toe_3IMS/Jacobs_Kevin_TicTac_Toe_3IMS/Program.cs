using System;
using System.Timers;
using System.Threading;


namespace Jacobs_Kevin_TicTac_Toe_3IMS
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //Variables
            int width = 80;
            int height = 25;
            Game gameState = new Game(height,width);
            //Init
            ChangeConsoleSize(width,height);
            gameState.m_CurrentState = GameState.Game;
            Run(width, height, gameState);

            //Game.DrawBoard(51);
             char[,] assr = new char[width, height];
//            for (int i = 0; i < 25; i++)
//            {
//                for (int j = 0; j < 80; j++)
//                {
//                    Console.Write("x");
//                }
//                Console.WriteLine();
//            }
            
        }
        static private void Run(int width, int height, Game gameState)
        {
           ConsoleKey key = new ConsoleKey();
            while(gameState.m_CurrentState != GameState.Exit)
            {
                Thread.Sleep(1000);
                //Waiting for input
                while (key != ConsoleKey.Escape)
                {
                    //Checking input
                    
                        gameState.Draw();
                        key = Console.ReadKey(true).Key;
                    switch (gameState.m_CurrentState)
                    {
                        case GameState.Menue:
                            Navigate(gameState, key);
                            break;
                        case GameState.Game:
                            Controls(key,gameState);
                            break;
                        case GameState.Options:
                            Navigate(gameState, key);
                            break;
                        case GameState.Difficult:
                            Navigate(gameState, key);
                            break;
                        default:
                            break;
                    }
                    
                    //Animation
                }
                

                //Draw
                    //Console.WriteLine("new loop");
                //Update
            }
        }
        static private void Controls(ConsoleKey k, Game gs)
        {
            switch (k)
            {
                case ConsoleKey.D1:
                  
                    break;
                 case ConsoleKey.D2:
                  
                    break;
                 case ConsoleKey.D3:
                  
                    break;
                 case ConsoleKey.D4:
                  
                    break;
                 case ConsoleKey.D5:
                  
                    break;
                 case ConsoleKey.D6:
                  
                    break;
                 case ConsoleKey.D7:
                  
                    break;
                 case ConsoleKey.D8:
                  
                    break;
                 case ConsoleKey.D9:
                  
                    break;
                case ConsoleKey.M:

                    break;

                default:
                    break;
            }
        }
        static private void Navigate(Game gs, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    gs.m_CurrentState = GameState.Exit;
                    break;
                case ConsoleKey.UpArrow:
                    gs.m_Option--;
                    break;
                case ConsoleKey.DownArrow:
                    gs.m_Option++;
                    break;
                case ConsoleKey.Spacebar:
                    ChangeWindow(gs);
                    break;
                case ConsoleKey.M:
                    gs.m_CurrentState = GameState.Menue;
                    break;

            }
        }
        static private void ChangeWindow(Game gs)
        {
            switch (gs.m_CurrentState)
            {
                case GameState.Menue:
                    if (gs.m_Option == 0)
                    {
                        gs.m_CurrentState = GameState.Game;
                    }
                    else if (gs.m_Option == 1)
                    {
                        gs.m_CurrentState = GameState.Difficult;
                    }
                    else if (gs.m_Option == 2)
                    {
                        gs.m_CurrentState = GameState.Options;
                    }
                    break;
                case GameState.Game:
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
        }
        static private void ChangeConsoleSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetWindowPosition(0, 0);
            
        }
    }
}
