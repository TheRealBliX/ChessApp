using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    internal class Player
    {
        internal string Name { get; }
        internal Color Color { get; }
        internal List<Figure> Figures;

        internal Status Status { get; set; } = Status.None;
        internal string Time { get; set; }

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        internal void UpdateInfo()
        {
            Figures = Board.GM.GetFigures(this);
        }

        public static bool operator ==(Player player1, Player player2)
        {
            if ((player1.Name == player2.Name) && (player1.Color == player2.Color))
                return true;

            return false;
        }

        public static bool operator !=(Player player1, Player player2)
        {
            if ((player1.Name == player2.Name) && (player1.Color == player2.Color))
                return false;

            return true;
        }
    }
}