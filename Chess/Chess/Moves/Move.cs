namespace Chess
{
    internal class Move
    {
        internal Position PositionBefore { get; }
        internal Position PositionAfter { get; }
        internal Figure FigureBefore { get; }
        internal Figure FigureAfter { get; }
        internal MoveType MoveType { get; }
        internal MoveResultType MoveResultType { get; set; }

        internal Move(Position before, Figure figureBefore, Figure figureAfter, Position after, MoveType type, MoveResultType moveResultType)
        {
            PositionBefore = before;
            FigureBefore = figureBefore;
            FigureAfter = figureAfter;
            PositionAfter = after;
            MoveType = type;
            MoveResultType = moveResultType;
        }

        internal string GetMove(string space = "   ")
        {
            string result = "";

            switch(MoveType)
            {
                case MoveType.ShortCastling:
                    result = "O-O";
                    break;

                case MoveType.LongCastling:
                    result = "O-O-O";
                    break;

                case MoveType.AdditionalCommon:
                case MoveType.Common:
                    result = $"{FigureBefore.Name}{PositionBefore} - {PositionAfter}";
                    break;

                case MoveType.EnPassant:
                    result = $"{FigureBefore.Name}{PositionBefore} x {PositionAfter} (e.p)";
                    break;

                case MoveType.Take:
                    result = $"{FigureBefore.Name}{PositionBefore} x {PositionAfter}";
                    break;

                case MoveType.Change:
                    result = $"{PositionBefore} => {FigureAfter.Name}{PositionAfter}";
                    break;
            }

            switch(MoveResultType)
            {
                case MoveResultType.Check:
                    return $"{result}+{space}";

                case MoveResultType.Stalemate:
                    return $"{result}=";

                case MoveResultType.Mate:
                    return $"{result}#";

                default:
                    return $"{result}{space}";
            }
        }
    }
}
