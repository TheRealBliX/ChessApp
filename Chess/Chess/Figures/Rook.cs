using System.Collections.Generic;

namespace Chess
{
    internal sealed class Rook : Figure
    {
        internal bool IsMadeMove;

        public Rook(Player player, Position position, bool isNew = false)
        {
            Name = "R";
            Owner = player;
            Position = position;
            IsMadeMove = isNew;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            List<PossibleMove> possibleMoves;

            //Up
            possibleMoves = CheckLineForPositions(true, null, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Down
            possibleMoves = CheckLineForPositions(false, null, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Left
            possibleMoves = CheckLineForPositions(null, false, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Right
            possibleMoves = CheckLineForPositions(null, true, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            return attacks;
        }
    }
}