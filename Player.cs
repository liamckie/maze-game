using System;
using System.Collections.Generic;
using System.Text;

namespace maze
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColour;

        public Player(int initX, int initY)
        {
            X = initX;
            Y = initY;
            PlayerMarker = "O";
            PlayerColour = ConsoleColor.Red;
        }

        public void Draw()
        {
            Console.ForegroundColor = PlayerColour;
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerMarker);
            Console.ResetColor();
        }
    }
}
