using System.Collections.Generic;

namespace Chess
{
    internal sealed class Knight : Figure
    {
        private bool isHKMON;

        public Knight(Player player, Position position, bool isHKMON)
        {
            Name = "N";
            Owner = player;
            Position = position;
            this.isHKMON = isHKMON;
        }

        internal override List<Attack> GetAvailableMoves(bool ignoreOwnFigure, bool checkIfCheck)
        {
            var attacks = new List<Attack>();
            Position newPosition;

            if (isHKMON)
            {
                CellAttack attack;

                //Up Left
                newPosition = new Position(Position.LineIndex + 2, Position.ColumnIndex - 1);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex + 2, Position.ColumnIndex),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);


                //Up Right
                newPosition = new Position(Position.LineIndex + 2, Position.ColumnIndex + 1);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex + 2, Position.ColumnIndex),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Down Left
                newPosition = new Position(Position.LineIndex - 2, Position.ColumnIndex - 1);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex - 2, Position.ColumnIndex),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Down Right
                newPosition = new Position(Position.LineIndex - 2, Position.ColumnIndex + 1);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex - 2, Position.ColumnIndex),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Left Up 
                newPosition = new Position(Position.LineIndex + 1, Position.ColumnIndex - 2);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex - 2),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Left down
                newPosition = new Position(Position.LineIndex - 1, Position.ColumnIndex - 2);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex - 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex - 2),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Right Up 
                newPosition = new Position(Position.LineIndex + 1, Position.ColumnIndex + 2);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex + 1, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex + 2),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);

                //Right down
                newPosition = new Position(Position.LineIndex - 1, Position.ColumnIndex + 2);

                attack = GetAttack(newPosition,
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex),
                                   new Position(Position.LineIndex - 1, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex + 1),
                                   new Position(Position.LineIndex, Position.ColumnIndex + 2),
                                   ignoreOwnFigure, checkIfCheck);

                if (attack != null)
                    attacks.Add(attack);
            }
            else
            {
                PossibleMove possibleMove;

                //Up left
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 2, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Up right
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 2, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Down left
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 2, Position.ColumnIndex - 1), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Down right
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 2, Position.ColumnIndex + 1), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Left up
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex - 2), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Left down
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex - 2), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Right up
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex + 1, Position.ColumnIndex + 2), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));

                //Right down
                possibleMove = CheckCellForPosition(new Position(Position.LineIndex - 1, Position.ColumnIndex + 2), ignoreOwnFigure, checkIfCheck);
                if (possibleMove != null)
                    attacks.Add(new CellAttack(possibleMove, this));
            }

            return attacks;
        }

        private CellAttack GetAttack(Position position, Position checkPosition1, Position checkPosition2, Position checkPosition3, Position checkPosition4, bool ignoreOwnFigure, bool checkIfCheck)
        {
            PossibleMove possibleMove;

            possibleMove = CheckCell(position,
                                         checkPosition1,
                                         checkPosition2,
                                         checkPosition3,
                                         checkPosition4,
                                         ignoreOwnFigure,
                                         checkIfCheck);

            if (possibleMove != null)
                return new CellAttack(possibleMove, this);

            return null;
        }

        private PossibleMove CheckCell(Position position, Position checkPosition1, Position checkPosition2, Position checkPosition3, Position checkPosition4, bool ignoreOwnFigure, bool checkIfCheck)
        {
            PossibleMove checkedPosition = null;

            if (Position.CheckIndexes(position) && Position.CheckIndexes(checkPosition1) && Position.CheckIndexes(checkPosition2) && Position.CheckIndexes(checkPosition3) && Position.CheckIndexes(checkPosition4) &&
               (Board.GM.Field[checkPosition1.LineIndex, checkPosition1.ColumnIndex].FigureOnCell == null || Board.GM.Field[checkPosition2.LineIndex, checkPosition2.ColumnIndex].FigureOnCell == null ||
                Board.GM.Field[checkPosition3.LineIndex, checkPosition3.ColumnIndex].FigureOnCell == null || Board.GM.Field[checkPosition4.LineIndex, checkPosition4.ColumnIndex].FigureOnCell == null))
            {
                var canMakeMove = true;
                if (checkIfCheck)
                    canMakeMove = CheckIfCanMakeMove(position);

                if (canMakeMove && Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell == null)
                    checkedPosition = new PossibleMove(Board.GM.Field[position.LineIndex, position.ColumnIndex].Position, MoveType.Common, MoveType.CellAttack);
                else if (!ignoreOwnFigure && canMakeMove && Board.GM.Field[position.LineIndex, position.ColumnIndex].FigureOnCell.Owner != Owner)
                    checkedPosition = new PossibleMove(Board.GM.Field[position.LineIndex, position.ColumnIndex].Position, MoveType.Take, MoveType.CellAttack);
            }
            
            return checkedPosition;
        }
    }
}