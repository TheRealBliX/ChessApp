namespace Chess
{
    internal class Attack
    {
        internal MoveType Type { get; private protected set; }
        internal PossibleMove[] PossibleMoves { get; private protected set; }
        internal Figure Figure { get; }

        protected Attack(PossibleMove[] possibleMoves, Figure figure)
        {
            PossibleMoves = possibleMoves;
            Figure = figure;
        }
    }
}