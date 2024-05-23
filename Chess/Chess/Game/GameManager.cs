using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chess
{
    internal class GameManager
    {
        internal Position FirstPlayerKingPosition { get; set; }
        internal Position SecondPlayerKingPosition { get; set; }

        internal Player Player1 { get; private set; }
        internal Player Player2 { get; private set; }
        internal Player None { get; private set; }

        internal Color MainColor { get; private set; }
        internal Color SecondColor { get; private set; }

        internal static Image[] FigureImages { get; private set; }

        internal Cell[,] Field { get; set; }

        internal List<Move[]> AllMoves { get; set; }
        internal List<string> AllMovesTextRepresentation{ get; set; }
        internal Move LastMove { get; set; }

        internal Player PlayerWhoGiveUp {  get; set; }

        internal bool IsHKMOn { get; }

        internal GameManager(Color mainColor, string nameOfPlayer1, Color secondColor, string nameOfPlayer2, bool isHKMON)
        {
            MainColor = mainColor;
            SecondColor = secondColor;

            Player1 = new Player(nameOfPlayer1, MainColor);
            Player2 = new Player(nameOfPlayer2, SecondColor);
            None = new Player("", Color.Red);

            PlayerWhoGiveUp = None;

            IsHKMOn = isHKMON;

            AllMoves = new List<Move[]>();
            AllMovesTextRepresentation = new List<string>();

            var directory = Path.GetDirectoryName(Application.ExecutablePath);

            FigureImages = new Image[]
            {
                null,

                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhitePawn.png")), //White Pawn
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhiteRook.png")), //White Rook
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhiteKnight.png")), //White Knight
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhiteBishop.png")), //White Bishop
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhiteQueen.png")), //White Queen
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\WhiteKing.png")), //White King

                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackPawn.png")), //Black Pawn
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackRook.png")), //Black Rook
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackKnight.png")), //Black Knight
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackBishop.png")), //Black Bishop
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackQueen.png")), //Black Queen
                Image.FromFile(Path.Combine(directory, "..\\..\\Assets\\BlackKing.png")) //Black King
            };
        }

        internal void UpdateInfoOnField()
        {
            Player1.UpdateInfo();
            Player2.UpdateInfo();

            foreach (var cell in Field)
            {
                if (cell.FigureOnCell == null)
                {
                    cell.Button.BackgroundImage = FigureImages[0];
                    continue;
                }
                    

                if (cell.FigureOnCell.Owner == Player1)
                {
                    if (cell.FigureOnCell is Pawn)
                    {
                        cell.Button.BackgroundImage = FigureImages[1];
                        continue;
                    }
                    else if (cell.FigureOnCell is Rook)
                    {
                        cell.Button.BackgroundImage = FigureImages[2];
                        continue;
                    }
                    else if (cell.FigureOnCell is Knight)
                    {
                        cell.Button.BackgroundImage = FigureImages[3];
                        continue;
                    }
                    else if (cell.FigureOnCell is Bishop)
                    {
                        cell.Button.BackgroundImage = FigureImages[4];
                        continue;
                    }  
                    else if (cell.FigureOnCell is Queen)
                    {
                        cell.Button.BackgroundImage = FigureImages[5];
                        continue;
                    }
                    else if (cell.FigureOnCell is King)
                    {
                        cell.Button.BackgroundImage = FigureImages[6];
                        continue;
                    }
                }
                else
                {
                    if (cell.FigureOnCell is Pawn)
                    {
                        cell.Button.BackgroundImage = FigureImages[7];
                        continue;
                    }
                    else if (cell.FigureOnCell is Rook)
                    {
                        cell.Button.BackgroundImage = FigureImages[8];
                        continue;
                    }
                    else if (cell.FigureOnCell is Knight)
                    {
                        cell.Button.BackgroundImage = FigureImages[9];
                        continue;
                    }
                    else if (cell.FigureOnCell is Bishop)
                    {
                        cell.Button.BackgroundImage = FigureImages[10];
                        continue;
                    } 
                    else if (cell.FigureOnCell is Queen)
                    {
                        cell.Button.BackgroundImage = FigureImages[11];
                        continue;
                    }  
                    else if (cell.FigureOnCell is King)
                    {
                        cell.Button.BackgroundImage = FigureImages[12];
                        continue;
                    }
                }
            }
        }

        internal void UpdateInfoInMovesTable(RichTextBox table)
        {
            table.Text = "";
            for (int i = 0; i < AllMoves.Count; i++)
            {
                if (AllMoves[i][1] != null)
                {
                    var line = $"{i + 1}: {AllMoves[i][0].GetMove()}{AllMoves[i][1].GetMove("")}\n";
                    table.Text += line;
                    if (!AllMovesTextRepresentation.Contains(line))
                        AllMovesTextRepresentation.Add(line);
                }
                else
                {
                    var line = $"{i + 1}: {AllMoves[i][0].GetMove()}";
                    table.Text += line;
                    if ((AllMoves[i][0].MoveResultType == MoveResultType.Mate || AllMoves[i][0].MoveResultType == MoveResultType.Mate) && !AllMovesTextRepresentation.Contains(line))
                        AllMovesTextRepresentation.Add(line);
                }
            }
        }

        internal List<Attack> GetAvailableAttacks(Player owner, Player enemy)
        {
            var attacks = new List<Attack>();

            if (LastMove != null)
                foreach (var attack in GetAllAttacks(enemy, owner))
                    attacks.Add(attack);

            return attacks;
        }

        internal static Position GetKingPosition(Player player)
        {
            player.UpdateInfo();
            foreach (var figure in player.Figures)
            {
                if (figure is King)
                {
                    if (player == Board.GM.Player1)
                        Board.GM.FirstPlayerKingPosition = figure.Position;
                    else
                        Board.GM.SecondPlayerKingPosition = figure.Position;

                    return figure.Position;
                }
            }  

            if (player == Board.GM.Player1)
                return Board.GM.FirstPlayerKingPosition;

            return Board.GM.SecondPlayerKingPosition;
        }

        internal static bool CheckIfPositionUnderAttack(Position position, Player enemy)
        {
            if (GetAttacksOnPosition(enemy, position, true).Length != 0)
                return true;

            return false;
        }

        internal static bool CheckIfCheck(Player owner, Player enemy) =>
            CheckIfCheckOnPosition(owner, GetKingPosition(enemy));

        internal static bool CheckIfCheckOnPosition(Player owner, Position position)
        {
            if (GetAttacksOnPosition(owner, position, false, false).Length != 0)
                return true;

            return false;
        }

        internal static bool CheckIfMate(Player owner, Player enemy)
        {
            if (CheckIfCheck(owner, enemy))
            {
                var kingPosition = GetKingPosition(enemy);

                if (GetAllAttacks(owner, enemy).Length != 0)
                    return false;

                if (Board.GM.Field[kingPosition.LineIndex, kingPosition.ColumnIndex].FigureOnCell.GetAvailableMoves().Count == 0)
                    return true;
            }

            return false;
        }

        private static Attack[] GetAttacksOnPosition(Player owner, Position position, bool ignoreOwnFigures = false, bool checkIfCheck = true)
        {
            var attacks = new List<Attack>();
            owner.UpdateInfo();

            foreach (var figure in owner.Figures)
            {
                if (figure.GetType() == typeof(Pawn))
                {
                    var pawn = (Pawn)figure;
                    foreach (var attack in pawn.GetAvailableMoves(ignoreOwnFigures, checkIfCheck))
                    {
                        if (attack.GetType() == typeof(CellAttack))
                        {
                            var cellAttack = (CellAttack)attack;
                            if (cellAttack.IsForAttack)
                                foreach (var move in attack.PossibleMoves)
                                    if (move.Position == position)
                                        attacks.Add(attack);
                        }
                            
                    }
                        
                }
                else if (figure.GetType() == typeof(King))
                {
                    var king = (King)Board.GM.Field[GetKingPosition(owner).LineIndex, GetKingPosition(owner).ColumnIndex].FigureOnCell;
                    foreach (var attack in king.GetAvailableMovesSimplified(ignoreOwnFigures, checkIfCheck))
                        foreach (var move in attack.PossibleMoves)
                            if (move.Position == position)
                                attacks.Add(attack);
                }
                else
                {
                    foreach (var attack in figure.GetAvailableMoves(ignoreOwnFigures, checkIfCheck))
                        foreach (var move in attack.PossibleMoves)
                            if (move.Position == position)
                                attacks.Add(attack);
                }
            }

            return attacks.ToArray();
        }

        private static Attack[] GetAllAttacks(Player owner, Player enemy)
        {
            var attacks = new List<Attack>();

            owner.UpdateInfo();
            enemy.UpdateInfo();

            foreach (var figure in enemy.Figures)
                foreach (var theirAttack in figure.GetAvailableMoves())
                    attacks.Add(theirAttack);

            return attacks.ToArray();
        }

        internal List<Figure> GetFigures(Player player)
        {
            var figures = new List<Figure>();

            foreach (var cell in Field)
                if (cell.FigureOnCell != null && cell.FigureOnCell.Owner == player)
                    figures.Add(cell.FigureOnCell);

            return figures;
        }

        internal MoveResultType GetMoveResultType(Player owner, Player enemy)
        {
            if (CheckIfMate(owner, enemy))
                return MoveResultType.Mate;
            else if (CheckIfCheck(owner, enemy))
                return MoveResultType.Check;
            return MoveResultType.None;
        }

        internal Player GetNextPlayer(Player currentPlayer) =>
            currentPlayer == Player1 ? Player2 : Player1;

        internal bool Check50MoveRule()
        {
            var amountOfMovesWithoutTakes = 0;
            foreach (var moves in AllMoves)
            {
                if ((moves[0].MoveType != MoveType.Take && moves[0].MoveType != MoveType.EnPassant) || (moves[0].FigureAfter.GetType() != typeof(Pawn)))
                {
                    if (moves[1] != null)
                    {
                        if ((moves[1].MoveType != MoveType.Take && moves[1].MoveType != MoveType.EnPassant) || (moves[0].FigureAfter.GetType() != typeof(Pawn)))
                            amountOfMovesWithoutTakes++;
                        else
                            amountOfMovesWithoutTakes = 0;
                    }
                    else
                    {
                        amountOfMovesWithoutTakes++;
                    }
                }
                else
                {
                    amountOfMovesWithoutTakes = 0;
                }
            }

            if (amountOfMovesWithoutTakes >= 50)
                return true;
            else
                return false;
        }

        internal string GetGameText()
        {
            var result = "[Chess by BliX]\n\n";

            result += $"{Player1.Name}: {Player1.Status}\n-Remaining time: {Player1.Time}\n" +
                      $"{Player2.Name}: {Player2.Status}\n-Remaining time: {Player2.Time}\n\n";

            foreach (var moves in AllMovesTextRepresentation)
                result += moves;

            if (PlayerWhoGiveUp != None)
                result += $"[{PlayerWhoGiveUp.Name} give up]";

            return result;
        }
    }
}
