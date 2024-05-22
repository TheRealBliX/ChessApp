using System;
using System.Collections.Generic;

namespace Chess
{
    internal sealed class Pawn : Figure
    {
        private readonly bool isMadeMove;

        public Pawn(Player player, Position position, bool isNew = false)
        {
            Name = "";
            Owner = player;
            Position = position;
            isMadeMove = isNew;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            PossibleMove possibleMove;

            if (Owner == Board.GM.Player1)
            {
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 2, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false, true);
                if (!isMadeMove && possibleMove != null && CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false) != null)
                    attacks.Add(new CellAttack(possibleMove, this, false));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this, false));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck, false, true); //Left attack
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck, false, true); //Right attack
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                var enPassantAttack = GetEnPassantAttack(ignoreOwnFigure, checkIfCheck);
                if (enPassantAttack != null)
                    attacks.Add(enPassantAttack);
            }
            else
            {
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 2, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false, true);
                if (!isMadeMove && possibleMove != null && CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false) != null)
                    attacks.Add(new CellAttack(possibleMove, this, false));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck, true, false);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this, false));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck, false, true); //Left attack
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck, false, true); //Right attack
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                var enPassantAttack = GetEnPassantAttack(ignoreOwnFigure, checkIfCheck);
                if (enPassantAttack != null)
                    attacks.Add(enPassantAttack);
            }

            return attacks;
        }

        private CellAttack GetEnPassantAttack(bool ignoreOwnFigure, bool checkIfCheck)
        {
            if (Board.GM.LastMove != null &&
                Board.GM.LastMove.FigureAfter.GetType() == typeof(Pawn) &&
                Board.GM.LastMove.FigureAfter.Owner != Owner &&
                Board.GM.LastMove.MoveType == MoveType.AdditionalCommon &&
                Board.GM.LastMove.FigureAfter.Position.LineIndex == Position.LineIndex &&
                (Board.GM.LastMove.FigureAfter.Position.ColumnIndex == Position.ColumnIndex + 1 ||
                 Board.GM.LastMove.FigureAfter.Position.ColumnIndex == Position.ColumnIndex - 1))
            {
                var possibleMove = CheckCellForPosition(new Position(Owner == Board.GM.Player1 ? Position.LineIndex + 1 : Position.LineIndex - 1, 
                                                                     Board.GM.LastMove.FigureAfter.Position.ColumnIndex == Position.ColumnIndex + 1 ? Position.ColumnIndex + 1 : Position.ColumnIndex - 1), 
                                                                     ignoreOwnFigure, checkIfCheck, true, false, false, true);
                if (possibleMove != null)
                    return new CellAttack(possibleMove, this);
            }

            return null;
        }

        internal override Move MakeMove(Type figureAfterType, PossibleMove possibleMove)
        {
            if (possibleMove.MoveType == MoveType.EnPassant)
            {
                var enemyPawnPosition = new Position(possibleMove.Position.LineIndex - 1, possibleMove.Position.ColumnIndex);
                Board.GM.Field[enemyPawnPosition.LineIndex, enemyPawnPosition.ColumnIndex].FigureOnCell = null;

                Board.GM.Field[Position.LineIndex, Position.ColumnIndex].FigureOnCell = null;
                Board.GM.Field[possibleMove.Position.LineIndex, possibleMove.Position.ColumnIndex].FigureOnCell = this;

                Board.GM.Player1.UpdateInfo();
                Board.GM.Player2.UpdateInfo();

                return base.MakeMove(figureAfterType, possibleMove);
            }

            return base.MakeMove(figureAfterType, possibleMove);
        }
    }
}