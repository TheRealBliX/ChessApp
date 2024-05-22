using System;
using System.Collections.Generic;

namespace Chess
{
    internal sealed class King : Figure
    {
        private bool isMadeMove;

        public King(Player player, Position position, bool isNew = false)
        {
            Name = "K";
            Owner = player;
            Position = position;
            isMadeMove = isNew;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            PossibleMove possibleMove;

            //Up
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex + 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Down
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex - 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Left
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Right
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Left Up
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex + 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Left Down
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex - 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Right Up
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex + 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Right Down
            possibleMove = CheckCellForPositionKingVersion(new Position(Position.LineIndex - 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null && !GameManager.CheckIfPositionUnderAttack(possibleMove.Position, Enemy))
                attacks.Add(new CellAttack(possibleMove, this));

            //Castling
            if (!isMadeMove)
            {
                //Short
                var shortRookPosition = new Position(Position.LineIndex, Position.ColumnIndex + 3);
                var shortFigure = Board.GM.Field[shortRookPosition.LineIndex, shortRookPosition.ColumnIndex].FigureOnCell;

                if (shortFigure != null && shortFigure.GetType() == typeof(Rook))
                {
                    var rook = (Rook)shortFigure;

                    if (!rook.IsMadeMove && CheckShortCastling(new Cell[] { Board.GM.Field[Position.LineIndex, Position.ColumnIndex + 1], 
                                                                            Board.GM.Field[Position.LineIndex, Position.ColumnIndex + 2] }))
                    {
                        possibleMove = CheckCellForPosition(new Position(Position.LineIndex, Position.ColumnIndex + 2), ignoreOwnFigure, checkIfCheck);
                        if (possibleMove != null)
                            attacks.Add(new CellAttack(possibleMove, this));
                    }
                }

                //Long
                var longRookPosition = new Position(Position.LineIndex, Position.ColumnIndex - 4);
                var longFigure = Board.GM.Field[longRookPosition.LineIndex, longRookPosition.ColumnIndex].FigureOnCell;

                if (longFigure != null && longFigure.GetType() == typeof(Rook))
                {
                    var rook = (Rook)longFigure;

                    if (!rook.IsMadeMove && CheckLongCastling(new Cell[] { Board.GM.Field[Position.LineIndex, Position.ColumnIndex - 1], 
                                                                            Board.GM.Field[Position.LineIndex, Position.ColumnIndex - 2],
                                                                            Board.GM.Field[Position.LineIndex, Position.ColumnIndex - 3] }))
                    {
                        possibleMove = CheckCellForPosition(new Position(Position.LineIndex, Position.ColumnIndex - 2), ignoreOwnFigure, checkIfCheck);
                        if (possibleMove != null)
                            attacks.Add(new CellAttack(possibleMove, this));
                    }
                }

            }

            return attacks;
        }

        internal List<Attack> GetAvailableMovesSimplified(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            PossibleMove possibleMove;

            //Up
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Down
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Left
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Right
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Left Up
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Left Down
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Right Up
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            //Right Down
            possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
            if (possibleMove != null)
                attacks.Add(new CellAttack(possibleMove, this));

            return attacks;
        }

        private bool CheckShortCastling(Cell[] cellsOnWay)
        {
            foreach (var cellOfWay in cellsOnWay)
                if (GameManager.CheckIfPositionUnderAttack(cellOfWay.Position, Enemy) || cellOfWay.FigureOnCell != null)
                    return false;

            return true;
        }

        private bool CheckLongCastling(Cell[] cellsOnWay)
        {
            for (int i = 0; i < cellsOnWay.Length; i++)
                if ((i < 2 && (GameManager.CheckIfPositionUnderAttack(cellsOnWay[i].Position, Enemy) || cellsOnWay[i].FigureOnCell != null)) || 
                    (i == 2 && cellsOnWay[i].FigureOnCell != null))
                    return false;

            return true;
        }

        internal override Move MakeMove(Type figureAfterType, PossibleMove possibleMove)
        {
            if (possibleMove.Position == new Position(Position.LineIndex, Position.ColumnIndex + 2))
            {
                var rookPosition = new Position(Position.LineIndex, Position.ColumnIndex + 3);
                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex - 2].FigureOnCell = Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex].FigureOnCell;
                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex].FigureOnCell = null;

                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex - 2].FigureOnCell.Position = new Position(rookPosition.LineIndex, rookPosition.ColumnIndex - 2);

                Board.GM.Player1.UpdateInfo();
                Board.GM.Player2.UpdateInfo();

                possibleMove.MoveType = MoveType.ShortCastling;
                return base.MakeMove(figureAfterType, possibleMove);
            }
            else if (possibleMove.Position == new Position(Position.LineIndex, Position.ColumnIndex - 2))
            {
                var rookPosition = new Position(Position.LineIndex, Position.ColumnIndex - 4);
                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex + 3].FigureOnCell = Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex].FigureOnCell;
                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex].FigureOnCell = null;

                Board.GM.Field[rookPosition.LineIndex, rookPosition.ColumnIndex + 3].FigureOnCell.Position = new Position(rookPosition.LineIndex, rookPosition.ColumnIndex + 3);

                possibleMove.MoveType = MoveType.LongCastling;
                return base.MakeMove(figureAfterType, possibleMove);
            }

            return base.MakeMove(figureAfterType, possibleMove);
        }
    }
}