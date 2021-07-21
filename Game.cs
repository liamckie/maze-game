using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace maze
{
    class Game
    {
        private World world;
        private Player player;
        private string Title = @" _____ _                                     ___                     
/__   \ |__   ___    /\/\   __ _ _______    / _ \__ _ _ __ ___   ___ 
  / /\/ '_ \ / _ \  /    \ / _` |_  / _ \  / /_\/ _` | '_ ` _ \ / _ \
 / /  | | | |  __/ / /\/\ \ (_| |/ /  __/ / /_\\ (_| | | | | | |  __/
 \/   |_| |_|\___| \/    \/\__,_/___\___| \____/\__,_|_| |_| |_|\___|";

        public void Start()
        {
            string[,] grid = LvlParser.ParseFileToArray("Lvl1.txt");
            //string[,] grid =
            //{
            //    { "┌", "─", "┬", "─", "─", "─", "┐" },
            //    { "│", " ", "│", " ", " ", " ", "X" },
            //    { " ", " ", "│", " ", "│", " ", "│" },
            //    { "│", " ", "│", " ", "│", " ", "│" },
            //    { "│", " ", "│", " ", "│", " ", "│" },
            //    { "│", " ", " ", " ", "│", " ", "│" },
            //    { "└", "─", "─", "─", "┴", "─", "┘" },
                
            //};

            world = new World(grid);
            player = new Player(1, 1);

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            Console.Title = "The Maze Game";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Title);
            Console.ResetColor();

            Console.WriteLine("\nWelcome to The Maze Game!");
            Console.Write("\nInstructions :" +
                              "\n -> Use the arrow keys to move around the maze" +
                              "\n -> Try and reach the goal, which looks like this : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("X");
            Console.ResetColor();
            WaitForKey();
        }

        private void DisplayOutro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Title);
            Console.ResetColor();
            Console.WriteLine("\nThank you for playing!");
            WaitForKey();
        }

        private void DrawFrame()
        {
            Console.Clear();
            world.Draw();
            player.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

            } while (Console.KeyAvailable);


            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (world.IsPositionWalkable(player.X, player.Y - 1))
                    {
                        player.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (world.IsPositionWalkable(player.X, player.Y + 1))
                    {
                        player.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (world.IsPositionWalkable(player.X - 1, player.Y))
                    {
                        player.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (world.IsPositionWalkable(player.X + 1, player.Y))
                    {
                        player.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();

            while (true)
            {
                DrawFrame();
                HandlePlayerInput();
                string elementAtPlayerPos = world.GetElementAt(player.X, player.Y);
                if (elementAtPlayerPos == "X")
                {
                    Thread.Sleep(1000);
                    break;
                }
                Thread.Sleep(0);
            }

            DisplayOutro();
        }

        public void WaitForKey()
        {
            Console.WriteLine("\nPress any key...");
            Console.ReadKey(true);
        }
    }
}
