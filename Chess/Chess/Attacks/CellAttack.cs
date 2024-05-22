namespace Chess
{
    internal class CellAttack : Attack
    {
        internal bool IsForAttack { get; private set; }
        public CellAttack(PossibleMove possibleMove, Figure figure, bool isForAttack = true) : base(null, figure)
        {
            PossibleMoves = new PossibleMove[] { possibleMove };
            Type = MoveType.CellAttack;
            IsForAttack = isForAttack;
        }
    }
}
