namespace Chess
{
    internal enum MoveType
    {
        Common,
        AdditionalCommon,
        EnPassant,
        Take,
        Change,
        ShortCastling,
        LongCastling,

        LineAttack,
        CellAttack
    }
}