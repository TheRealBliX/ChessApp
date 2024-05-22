namespace Chess
{
    internal class PossibleMove
    {
        internal MoveType MoveType { get; set; }
        internal MoveType? TypeOfAttack { get; }
        internal Position Position { get; }
        
        public PossibleMove(Position position, MoveType moveType, MoveType? typeOfAttack)
        {
            Position = position;
            MoveType = moveType;
            TypeOfAttack = typeOfAttack;
        }
    }
}
