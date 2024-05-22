using System.Collections.Generic;

namespace Chess
{
    internal sealed class Bishop : Figure
    {
        public Bishop(Player player, Position position)
        {
            Name = "B";
            Owner = player;
            Position = position;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigures, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            List<PossibleMove> possibleMoves;

            //Left Up
            possibleMoves = CheckDiagonalForPositions(true, false, ignoreOwnFigures, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Right Up
            possibleMoves = CheckDiagonalForPositions(true, true, ignoreOwnFigures, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Left Down
            possibleMoves = CheckDiagonalForPositions(false, false, ignoreOwnFigures, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Right Down
            possibleMoves = CheckDiagonalForPositions(false, true, ignoreOwnFigures, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            return attacks;
        }
    }
}