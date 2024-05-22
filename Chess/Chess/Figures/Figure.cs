using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    internal abstract class Figure
    {
        internal Position Position { get; set; }
        internal Position LastPosition { get; private protected set; }
        internal string Name { get; private protected set; }

        internal Player Owner { get; set; }
        protected Player Enemy => Board.GM.Player1 == Owner ? Board.GM.Player2 : Board.GM.Player1;

        internal abstract List<Attack> GetAvailableMoves(bool ignoreOwnFigure = false, bool checkIfCheck = true);
        
        internal virtual Move MakeMove(Type figureAfterType, PossibleMove possibleMove)
        {
            LastPosition = Position;
            Position = possibleMove.Position;

            Figure figureAfter = null;
            if (figureAfterType == typeof(Pawn))
                figureAfter = new Pawn(Owner, possibleMove.Position, true);
            else if (figureAfterType == typeof(Rook))
                figureAfter = new Rook(Owner, possibleMove.Position, true);
            else if (figureAfterType == typeof(Knight))
                figureAfter = new Knight(Owner, possibleMove.Position, Board.GM.IsHKMOn);
            else if (figureAfterType == typeof(Bishop))
                figureAfter = new Bishop(Owner, possibleMove.Position);
            else if (figureAfterType == typeof(Queen))
                figureAfter = new Queen(Owner, possibleMove.Position);
            else if (figureAfterType == typeof(King))
                figureAfter = new King(Owner, possibleMove.Position, true);

            Board.GM.Field[LastPosition.LineIndex, LastPosition.ColumnIndex].FigureOnCell = null;
            Board.GM.Field[Position.LineIndex, Position.ColumnIndex].FigureOnCell = figureAfter;

            Board.GM.Player1.UpdateInfo();
            Board.GM.Player2.UpdateInfo();

            return new Move(LastPosition, this, figureAfter, Position, possibleMove.MoveType, Board.GM.GetMoveResultType(Owner, Enemy));
        }

        internal Figure MakeVirtualMove(Position newPosition)
        {
            var figure = Board.GM.Field[newPosition.LineIndex, newPosition.ColumnIndex].FigureOnCell;
            Board.GM.Field[Position.LineIndex, Position.ColumnIndex].FigureOnCell = null;
            Board.GM.Field[newPosition.LineIndex, newPosition.ColumnIndex].FigureOnCell = this;

            Board.GM.Player1.UpdateInfo();
            Board.GM.Player2.UpdateInfo();

            return figure;
        }

        internal void UndoVirtualMove(Position newPosition, Figure figure)
        {
            Board.GM.Field[newPosition.LineIndex, newPosition.ColumnIndex].FigureOnCell = figure;
            Board.GM.Field[Position.LineIndex, Position.ColumnIndex].FigureOnCell = this;

            Board.GM.Player1.UpdateInfo();
            Board.GM.Player2.UpdateInfo();
        }

        protected List<PossibleMove> CheckDiagonalForPositions(bool? isLineActionPlus, bool? isColumnActionPlus, bool ignoreOwnFigures, bool checkIfCheck)
        {
            var possibleMoves = new List<PossibleMove>();
            Position newPosition;
            int newLineIndex;
            int newColumnIndex;

            for (int i = 0; i < 8; i++)
            {
                if (isLineActionPlus == null)
                    newLineIndex = Position.LineIndex;
                else
                    newLineIndex = (bool)isLineActionPlus ? Position.LineIndex + i :
                                                            Position.LineIndex - i;

                if (isColumnActionPlus == null)
                    newColumnIndex = Position.LineIndex;
                else
                    newColumnIndex = (bool)isColumnActionPlus ? Position.ColumnIndex + i :
                                                                Position.ColumnIndex - i;

                newPosition = new Position(newLineIndex, newColumnIndex);
                if (Position.CheckIndexes(newPosition) && newPosition != Position)
                {
                    var canMakeMove = true;

                    if (checkIfCheck)
                        canMakeMove = CheckIfCanMakeMove(newPosition);

                    var figure = Board.GM.Field[newPosition.LineIndex, newPosition.ColumnIndex].FigureOnCell;
                    if (figure == null)
                    {
                        if (canMakeMove)
                            possibleMoves.Add(new PossibleMove(newPosition, MoveType.Common, MoveType.CellAttack));
                    }
                    else if (figure.Owner != Owner || (ignoreOwnFigures && figure.Owner == Owner))
                    {
                        if (canMakeMove)
                            possibleMoves.Add(new PossibleMove(newPosition, MoveType.Take, MoveType.LineAttack));
                        return possibleMoves;
                    }
                    else
                    {
                        return possibleMoves;
                    }
                }
            }

            return possibleMoves;
        }

        protected List<PossibleMove> CheckLineForPositions(bool? isLineActionPlus, bool? isColumnActionPlus, bool ignoreOwnFigures, bool checkIfCheck)
        {
            var possibleMoves = new List<PossibleMove>();
            Position newPosition;
            int newLineIndex = Position.LineIndex;
            int newColumnIndex = Position.ColumnIndex;

            for (int i = 0; i < 8; i++)
            {
                if (isLineActionPlus == null)
                    newColumnIndex = (bool)isColumnActionPlus ? Position.ColumnIndex + i : 
                                                                Position.ColumnIndex - i;
                else if (isColumnActionPlus == null)
                    newLineIndex = (bool)isLineActionPlus ? Position.LineIndex + i : 
                                                            Position.LineIndex - i;

                newPosition = new Position(newLineIndex, newColumnIndex);
                if (Position.CheckIndexes(newPosition) && newPosition != Position)
                {
                    var canMakeMove = true;

                    if (checkIfCheck)
                        canMakeMove = CheckIfCanMakeMove(newPosition);

                    var figure = Board.GM.Field[newPosition.LineIndex, newPosition.ColumnIndex].FigureOnCell;
                    if (figure == null)
                    {
                        if (canMakeMove)
                            possibleMoves.Add(new PossibleMove(newPosition, MoveType.Common, MoveType.CellAttack));
                    }
                    else if (figure.Owner != Owner || (ignoreOwnFigures && figure.Owner == Owner))
                    {
                        if (canMakeMove)
                            possibleMoves.Add(new PossibleMove(newPosition, MoveType.Take, MoveType.LineAttack));
                        return possibleMoves;
                    }
                    else
                    {
                        return possibleMoves;
                    }
                }
            }   

            return possibleMoves;
        }

        protected bool CheckIfCanMakeMove(Position newPosition, bool isForKing = false)
        {
            var checkFigure = MakeVirtualMove(newPosition);
            if (isForKing)
            {
                if (GameManager.CheckIfCheckOnPosition(Enemy, newPosition))
                {
                    UndoVirtualMove(newPosition, checkFigure);
                    return false;
                }
            }
            else if (!isForKing)
            {
                if (GameManager.CheckIfCheck(Enemy, Owner))
                {
                    UndoVirtualMove(newPosition, checkFigure);
                    return false;
                }
            }
            UndoVirtualMove(newPosition, checkFigure);
            return true;
        }

        protected PossibleMove CheckCellForPosition(Position position, bool ignoreOwnFigures, bool checkIfCheck, bool isForMove = true, bool isForAttack = true, bool isCheckingAdditional = false, bool isEnPassant = false)
        {
            PossibleMove checkedPosition = null;
            if (Position.CheckIndexes(position))
            {
                var canMakeMove = true;
                if (checkIfCheck)
                    canMakeMove = CheckIfCanMakeMove(position);

                var figure = Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell;

                if (isEnPassant && canMakeMove)
                    checkedPosition = new PossibleMove(position, MoveType.EnPassant, MoveType.CellAttack);

                else if (isForMove && canMakeMove && (figure == null || (ignoreOwnFigures && figure.Owner == Owner)))
                {
                    if (isCheckingAdditional)
                        checkedPosition = new PossibleMove(position, MoveType.AdditionalCommon, MoveType.CellAttack);
                    else
                        checkedPosition = new PossibleMove(position, MoveType.Common, MoveType.CellAttack);
                }
                else if (isForAttack && canMakeMove && figure != null && Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell.Owner != Owner)
                    checkedPosition = new PossibleMove(position, MoveType.Take, MoveType.CellAttack);
            }

            return checkedPosition;
        }

        protected PossibleMove CheckCellForPositionKingVersion(Position position, bool ignoreOwnFigures, bool checkIfCheck, bool isForMove = true, bool isForAttack = true)
        {
            PossibleMove checkedPosition = null;
            if (Position.CheckIndexes(position))
            {
                var canMakeMove = true;
                if (checkIfCheck)
                    canMakeMove = CheckIfCanMakeMove(position, true);

                var figure = Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell;
                if (isForMove && canMakeMove && figure == null || (ignoreOwnFigures && figure.Owner == Owner))
                    checkedPosition = new PossibleMove(position, MoveType.Common, MoveType.CellAttack);
                else if (isForAttack && canMakeMove && figure != null && Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell.Owner != Owner)
                    checkedPosition = new PossibleMove(position, MoveType.Take, MoveType.CellAttack);
            }
            return checkedPosition;
        }
    }
}