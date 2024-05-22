using System.Collections.Generic;

namespace Chess
{
    internal sealed class Queen : Figure
    {
        public Queen(Player player, Position position)
        {
            Name = "Q";
            Owner = player;
            Position = position;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            List<PossibleMove> possibleMoves;

            //Left Up
            possibleMoves = CheckDiagonalForPositions(true, false, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Right Up
            possibleMoves = CheckDiagonalForPositions(true, true, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Left Down
            possibleMoves = CheckDiagonalForPositions(false, false, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

            //Right Down
            possibleMoves = CheckDiagonalForPositions(false, true, ignoreOwnFigure, checkIfCheck);
            if (possibleMoves.Count != 0)
                attacks.Add(new LineAttack(possibleMoves.ToArray(), this));

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