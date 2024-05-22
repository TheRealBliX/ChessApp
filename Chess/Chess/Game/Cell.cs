using System.Windows.Forms;

namespace Chess
{
    internal class Cell
    {
        internal Position Position { get; }
        internal Figure FigureOnCell { get; set; }
        internal Button Button { get; }
        internal bool isNewMove = false;

        public Cell(Position position, Figure figureOnCell, Button button)
        {
            Position = position;
            FigureOnCell = figureOnCell;
            Button = button;
        }
    }
}