namespace Chess
{
    internal class LineAttack : Attack
    {
        public LineAttack(PossibleMove[] possibleMoves, Figure figure) : base(possibleMoves, figure)
        {
            Type = MoveType.LineAttack;
        }
    }
}
