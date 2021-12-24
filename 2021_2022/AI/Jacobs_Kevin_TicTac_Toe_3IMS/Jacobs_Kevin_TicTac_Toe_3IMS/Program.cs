using System;
using System.Timers;
using System.Threading;
using System.Media;
//using System.Windows.Media;
using Windows.Media.Playback;
using System.IO;
 

namespace Jacobs_Kevin_TicTac_Toe_3IMS
{
    internal class Program
    {
        static public WMPLib.WindowsMediaPlayer g_Player = new WMPLib.WindowsMediaPlayer();

        static void Main(string[] args)
        {
            //Variables
            int width = 80;
            int height = 25;
            Game gameState = new Game(height,width);
            //Init
            ChangeConsoleSize(width,height);
            gameState.m_CurrentState = GameState.Menue;
            Run(width, height, gameState);

      
         }
        static private void Run(int width, int height, Game gameState)
        {
            g_Player.URL = "data/LetItSnow.mp3";
            //call our intro and music 
            gameState.DrawIntro(); 

            g_Player.controls.play();
           ConsoleKey key = new ConsoleKey();
            while(gameState.m_CurrentState != GameState.Exit)
            {
                //Waiting for input
                while (gameState.m_CurrentState != GameState.Exit)
                {
                    gameState.Draw();
                    if (gameState.m_CurrentState != GameState.Exit)
                    {
                        key = Console.ReadKey(true).Key;
                    }

                    switch (gameState.m_CurrentState)
                    {
                        case GameState.Menue:
                            Navigate(gameState, key);
                            break;
                        case GameState.Game:
                            ControlsGame(key,gameState);
                            break;
                        case GameState.Options:
                            Navigate(gameState, key);
                            break;
                        case GameState.Difficult:
                            Navigate(gameState, key); 
                            break;
                        case GameState.Winner:
                            ChangeWindow(gameState, key);
                            break;
                        default:
                            break;
                    }
                }
            }
            Final(gameState);
        }
        static private void ControlsGame(ConsoleKey k, Game gs)
        {
            switch (k)
            {
                case ConsoleKey.D1:
                    gs.Update(1);
                    break;
                 case ConsoleKey.D2:
                    gs.Update(2);
                    break;
                 case ConsoleKey.D3:
                    gs.Update(3);
                    break;
                 case ConsoleKey.D4:
                    gs.Update(4);
                    break;
                 case ConsoleKey.D5:
                    gs.Update(5);
                    break;
                 case ConsoleKey.D6:
                    gs.Update(6);
                    break;
                 case ConsoleKey.D7:
                    gs.Update(7);
                    break;
                 case ConsoleKey.D8:
                    gs.Update(8);
                    break;
                 case ConsoleKey.D9:
                    gs.Update(9);
                    break;
                case ConsoleKey.M:
                    gs.m_CurrentState = GameState.Menue;
                    gs.m_IsPicked = false;
                    break;
                case ConsoleKey.Escape:
                    gs.m_CurrentState = GameState.Exit;
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
                case ConsoleKey.S:
                    WMPLib.WindowsMediaPlayer eas = new WMPLib.WindowsMediaPlayer();
                    eas.URL = "data/santa.mp3";
                    eas.controls.play();
                    break;

            }
        }
        static private void ChangeWindow(Game gs, ConsoleKey key = 0)
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
                        gs.m_Option = 0;
                    }
                    else if (gs.m_Option == 2)
                    {
                        gs.m_CurrentState = GameState.Options;
                        gs.m_Option = 0;
                    }
                    else if (gs.m_Option == 3)
                    {
                        gs.m_CurrentState = GameState.Exit;
                    }
                    break;
                case GameState.Options:
                    if (gs.m_Option == 0)
                    {
                        //Mute
                        if (g_Player.settings.mute)
                        {
                            g_Player.settings.mute = false;
                        }
                        else
                        {
                        g_Player.settings.mute = true;
                        }
                    }
                    else if (gs.m_Option == 1)
                    {
                        //low Vol
                        g_Player.settings.volume -= 10;
                    }
                    else if (gs.m_Option == 2)
                    {
                        //High Vol
                        g_Player.settings.volume += 10;
                    }
                    else if (gs.m_Option == 3) 
                    {
                        //Play
                        g_Player.controls.play();
                    }
                    else if (gs.m_Option == 4)
                    {
                        //Stop
                        g_Player.controls.stop();
                    }
                    else if (gs.m_Option == 5)
                    {
                        //Back
                        gs.m_CurrentState = GameState.Menue;
                        gs.m_Option = 0; 
                    }
                    break;
                case GameState.Difficult:
                    if (gs.m_Option == 0)
                    {
                        gs.m_Bot.m_algo = Algorithm.MinMax;
                    }
                    else if (gs.m_Option == 1)
                    {
                        gs.m_Bot.m_algo = Algorithm.Rand;
                    }
                    else if (gs.m_Option == 2)
                    {
                        gs.m_Bot.m_algo = Algorithm.KNN;
                    }
                    gs.m_Option = 0;
                        gs.m_CurrentState = GameState.Menue;
                    break; 
                case GameState.Winner:
                    if (key == ConsoleKey.R)
                    {
                        gs.m_CurrentState = GameState.Game;
                    }
                    else if (key == ConsoleKey.M)
                    {
                        gs.m_CurrentState = GameState.Menue;
                    }
                    else if (key == ConsoleKey.M)
                    {
                        gs.m_CurrentState = GameState.Exit;
                    }
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
        static private void Final(Game gs)
        {
            gs.DrawOutro();
        }

    }
}
