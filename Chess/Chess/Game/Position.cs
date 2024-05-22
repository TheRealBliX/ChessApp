namespace Chess
{
    internal sealed class Position
    {
        internal int LineIndex { get; }
        internal int ColumnIndex { get; }

        public Position(int lineIndex, int columnIndex)
        {
            LineIndex = lineIndex;
            ColumnIndex = columnIndex;
        }
        
        internal static bool CheckIndexes(Position position)
        {
            if (position.LineIndex >= 0 && position.LineIndex <= 7 && position.ColumnIndex >= 0 && position.ColumnIndex <= 7)
                return true;

            return false;
        }

        private string GetLetter(int column)
        {
            switch (column)
            {
                case 0:
                    return "a";

                case 1:
                    return "b";

                case 2:
                    return "c";

                case 3:
                    return "d";

                case 4:
                    return "e";

                case 5:
                    return "f";

                case 6:
                    return "g";

                case 7:
                    return "h";

                default:
                    return null;
            }
        }

        public override string ToString() => 
            $"{GetLetter(ColumnIndex)}{LineIndex + 1}";

        public static bool operator ==(Position position1, Position position2)
        {
            if((position1.LineIndex == position2.LineIndex) && (position1.ColumnIndex == position2.ColumnIndex))
                return true;

            return false;
        }

        public static bool operator !=(Position position1, Position position2)
        {
            if ((position1.LineIndex == position2.LineIndex) && (position1.ColumnIndex == position2.ColumnIndex))
                return false;

            return true;
        }
    }
}