using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chess
{
    public partial class Board : Form
    {
        internal static GameManager GM;

        private int player1Time;
        private int player2Time;

        private bool isGameEnded;

        private Player currentPlayer;
        private List<PossibleMove> possibleMoves;

        private Figure selectedFigure;
        private Type selectedTypeOfFigure;
        private PossibleMove selectedPossibleMove;

        public Board()
        {
            InitializeComponent();

            GM = new GameManager(Color.White, InfoHolder.Player1Name, Color.Black, InfoHolder.Player2Name, (bool)InfoHolder.IsHKMOn);

            GM.Field = new Cell[8, 8]
            {
                { new Cell(new Position(0,0), new Rook(GM.Player1, new Position(0,0)), Cell1),
                  new Cell(new Position(0,1), new Knight(GM.Player1, new Position(0,1), GM.IsHKMOn), Cell2),
                  new Cell(new Position(0,2), new Bishop(GM.Player1, new Position(0,2)), Cell3),
                  new Cell(new Position(0,3), new Queen(GM.Player1, new Position(0,3)), Cell4),
                  new Cell(new Position(0,4), new King(GM.Player1, new Position(0,4)), Cell5),
                  new Cell(new Position(0,5), new Bishop(GM.Player1, new Position(0,5)), Cell6),
                  new Cell(new Position(0,6), new Knight(GM.Player1, new Position(0,6), GM.IsHKMOn), Cell7),
                  new Cell(new Position(0,7), new Rook(GM.Player1, new Position(0,7)), Cell8) },

                { new Cell(new Position(1,0), new Pawn(GM.Player1, new Position(1,0)), Cell9),
                  new Cell(new Position(1,1), new Pawn(GM.Player1, new Position(1, 1)), Cell10),
                  new Cell(new Position(1,2), new Pawn(GM.Player1, new Position(1, 2)), Cell11),
                  new Cell(new Position(1,3), new Pawn(GM.Player1, new Position(1, 3)), Cell12),
                  new Cell(new Position(1,4), new Pawn(GM.Player1, new Position(1, 4)), Cell13),
                  new Cell(new Position(1,5), new Pawn(GM.Player1, new Position(1, 5)), Cell14),
                  new Cell(new Position(1,6), new Pawn(GM.Player1, new Position(1,6)), Cell15),
                  new Cell(new Position(1,7), new Pawn(GM.Player1, new Position(1,7)), Cell16) },

                { new Cell(new Position(2,0), null, Cell17),
                  new Cell(new Position(2,1), null, Cell18),
                  new Cell(new Position(2,2), null, Cell19),
                  new Cell(new Position(2,3), null, Cell20),
                  new Cell(new Position(2,4), null, Cell21),
                  new Cell(new Position(2,5), null, Cell22),
                  new Cell(new Position(2,6), null, Cell23),
                  new Cell(new Position(2,7), null, Cell24) },

                { new Cell(new Position(3,0), null, Cell25),
                  new Cell(new Position(3,1), null, Cell26),
                  new Cell(new Position(3,2), null, Cell27),
                  new Cell(new Position(3,3), null, Cell28),
                  new Cell(new Position(3,4), null, Cell29),
                  new Cell(new Position(3,5), null, Cell30),
                  new Cell(new Position(3,6), null, Cell31),
                  new Cell(new Position(3,7), null, Cell32) },

                { new Cell(new Position(4,0), null, Cell33),
                  new Cell(new Position(4,1), null, Cell34),
                  new Cell(new Position(4,2), null, Cell35),
                  new Cell(new Position(4,3), null, Cell36),
                  new Cell(new Position(4,4), null, Cell37),
                  new Cell(new Position(4,5), null, Cell38),
                  new Cell(new Position(4,6), null, Cell39),
                  new Cell(new Position(4,7), null, Cell40) },

                { new Cell(new Position(5,0), null, Cell41),
                  new Cell(new Position(5,1), null, Cell42),
                  new Cell(new Position(5,2), null, Cell43),
                  new Cell(new Position(5,3), null, Cell44),
                  new Cell(new Position(5,4), null, Cell45),
                  new Cell(new Position(5,5), null, Cell46),
                  new Cell(new Position(5,6), null, Cell47),
                  new Cell(new Position(5,7), null, Cell48) },

                { new Cell(new Position(6,0), new Pawn(GM.Player2, new Position(6,0)), Cell49),
                  new Cell(new Position(6,1), new Pawn(GM.Player2, new Position(6,1)), Cell50),
                  new Cell(new Position(6,2), new Pawn(GM.Player2, new Position(6,2)), Cell51),
                  new Cell(new Position(6,3), new Pawn(GM.Player2, new Position(6,3)), Cell52),
                  new Cell(new Position(6,4), new Pawn(GM.Player2, new Position(6,4)), Cell53),
                  new Cell(new Position(6,5), new Pawn(GM.Player2, new Position(6,5)), Cell54),
                  new Cell(new Position(6,6), new Pawn(GM.Player2, new Position(6,6)), Cell55),
                  new Cell(new Position(6,7), new Pawn(GM.Player2, new Position(6,7)), Cell56) },

                { new Cell(new Position(7,0), new Rook(GM.Player2, new Position(7,0)), Cell57),
                  new Cell(new Position(7,1), new Knight(GM.Player2, new Position(7,1), GM.IsHKMOn), Cell58),
                  new Cell(new Position(7,2), new Bishop(GM.Player2, new Position(7,2)), Cell59),
                  new Cell(new Position(7,3), new Queen(GM.Player2, new Position(7,3)), Cell60),
                  new Cell(new Position(7,4), new King(GM.Player2, new Position(7,4)), Cell61),
                  new Cell(new Position(7,5), new Bishop(GM.Player2, new Position(7,5)), Cell62),
                  new Cell(new Position(7,6), new Knight(GM.Player2, new Position(7,6), GM.IsHKMOn), Cell63),
                  new Cell(new Position(7,7), new Rook(GM.Player2, new Position(7,7)), Cell64) },
            };

            GM.UpdateInfoOnField();

            currentPlayer = GM.Player1;
            UnlockFiguresCells();

            possibleMoves = new List<PossibleMove>();
            GM.LastMove = null;

            GM.FirstPlayerKingPosition = GameManager.GetKingPosition(GM.Player1);
            GM.SecondPlayerKingPosition = GameManager.GetKingPosition(GM.Player2);

            Player1ColorBox.BackColor = GM.Player1.Color;
            Player2ColorBox.BackColor = GM.Player2.Color;

            Player1NameLabel.Text = GM.Player1.Name;
            Player2NameLabel.Text = GM.Player2.Name;

            ChangePanel.Visible = false;

            ExitButton.Width = 175;
            ExitButton.Visible = false;
            SaveGameIntoFileButton.Visible = false;

            label3.Visible = false;
            GameResultLabel.Visible = false;

            label4.Text = $"{GM.Player1.Name}'s time:";
            label6.Text = $"{GM.Player2.Name}'s time:";

            player1Time = (int)InfoHolder.Time;
            UpdateTimeLabel(player1Time, Player1TimeLabel);
            player2Time = (int)InfoHolder.Time;
            UpdateTimeLabel(player2Time, Player2TimeLabel);

            isGameEnded = false;

            Player1Timer.Stop();
            Player2Timer.Stop();

            Player1Timer.Start();
        }

        private void Player1Timer_Tick(object sender, EventArgs e)
        {
            if (!isGameEnded)
            {
                player1Time--;

                if (player1Time <= 0)
                {
                    Player1Timer.Stop();
                    GM.Player2.Status = Status.Winner;
                    GM.Player1.Status = Status.Loser;
                    UpdateTimeLabel(0, Player1TimeLabel);
                    DeclareEndOfGame();
                }
                else
                {
                    UpdateTimeLabel(player1Time, Player1TimeLabel);
                }
            }
            else
            {
                ShowObjectAtTheEndOfGame();
            }
        }

        private void ShowObjectAtTheEndOfGame()
        {
            Player1TimeLabel.Visible = false;
            Player2TimeLabel.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            label3.Visible = true;
            GameResultLabel.Visible = true;
        }

        private void Player2Timer_Tick(object sender, EventArgs e)
        {
            if (!isGameEnded)
            {
                player2Time--;

                if (player2Time <= 0)
                {
                    Player2Timer.Stop();
                    GM.Player1.Status = Status.Winner;
                    GM.Player2.Status = Status.Loser;
                    UpdateTimeLabel(0, Player2TimeLabel);
                    DeclareEndOfGame();
                }
                else
                {
                    UpdateTimeLabel(player2Time, Player2TimeLabel);
                }
            }
            else
            {
                ShowObjectAtTheEndOfGame();
            }
        }

        private void UpdateTimeLabel(int time, Label timeLabel) =>
            timeLabel.Text = GetTimeText(time);

        private string GetTimeText(int time)
        {
            var seconds = Convert.ToString(time % 60);

            if (seconds.Length == 1)
                seconds = $"0{seconds}";

            return $"{time / 60}:{seconds}";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
            new Menu().ShowDialog();
        }

        private void GiveUpButton_Click(object sender, EventArgs e)
        {
            currentPlayer.Status = Status.Loser;
            GM.PlayerWhoGiveUp = currentPlayer;
            GM.GetNextPlayer(currentPlayer).Status = Status.Winner;
            DeclareEndOfGame();
        }

        private void DeclareEndOfGame()
        {
            BlockAllCells();

            GiveUpButton.Visible = false;
            ExitButton.Visible = true;
            SaveGameIntoFileButton.Visible = true;

            GM.Player1.Time = GetTimeText(player1Time);
            GM.Player2.Time = GetTimeText(player2Time);

            if (GM.Player1.Status == Status.None && GM.Player2.Status == Status.None)
            {
                GameResultLabel.Text = "Draw.";

                ShowObjectAtTheEndOfGame();

                Player1Timer.Stop();
                Player2Timer.Stop();

                isGameEnded = true;

                MessageBox.Show("Draw.");
            }
            else if (GM.Player1.Status == Status.Winner)
            {
                Player1NameLabel.ForeColor = Color.Green;
                Player2NameLabel.ForeColor = Color.Red;
                GameResultLabel.Text = $"{GM.Player1.Name} is winner.";

                ShowObjectAtTheEndOfGame();

                Player1Timer.Stop();
                Player2Timer.Stop();

                isGameEnded = true;

                MessageBox.Show($"{GM.Player1.Name} is winner.");
            }
            else if (GM.Player2.Status == Status.Winner)
            {
                Player1NameLabel.ForeColor = Color.Red;
                Player2NameLabel.ForeColor = Color.Green;
                GameResultLabel.Text = $"{GM.Player2.Name} is winner.";

                ShowObjectAtTheEndOfGame();

                Player1Timer.Stop();
                Player2Timer.Stop();

                isGameEnded = true;

                MessageBox.Show($"{GM.Player2.Name} is winner.");
            }
        }

        private void UnlockFiguresCells()
        {
            foreach (var cell in GM.Field)
            {
                cell.Button.Enabled = false;
                var figure = cell.FigureOnCell;
                if (figure != null && figure.Owner == currentPlayer)
                    cell.Button.Enabled = true;
            }
        }

        private void BlockAllCells()
        {
            foreach (var cell in GM.Field)
                cell.Button.Enabled = false;
        }

        private void ResetBackgroundColorOnCells()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (i % 2 != 0 && j % 2 == 0)
                        GM.Field[i, j].Button.BackColor = Color.LightGray;
                    else if (i % 2 == 0 && j % 2 != 0)
                        GM.Field[i, j].Button.BackColor = Color.LightGray;
                    else
                        GM.Field[i, j].Button.BackColor = Color.Gray;
        }

        private void SelectFigure(Cell cell)
        {
            ResetBackgroundColorOnCells();
            UnlockFiguresCells();
            selectedFigure = cell.FigureOnCell;
            
            var attacks = GM.LastMove == null ? cell.FigureOnCell.GetAvailableMoves() : 
                                                GM.GetAvailableAttacks(currentPlayer, GM.GetNextPlayer(currentPlayer));

            if (attacks != null)
            {
                foreach (var attack in attacks)
                {
                    if (attack.Figure == selectedFigure)
                    {
                        foreach (var possibleMove in attack.PossibleMoves)
                        {
                            possibleMoves.Add(possibleMove);
                            var cellOfMove = GM.Field[possibleMove.Position.LineIndex, possibleMove.Position.ColumnIndex];
                            cellOfMove.Button.Enabled = true;
                            cellOfMove.Button.BackColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void TryToMakeMove(PossibleMove possibleMove)
        {
            ResetBackgroundColorOnCells();
            Move move;

            if (selectedFigure.GetType() != typeof(Pawn) || (selectedFigure.GetType() == typeof(Pawn) && possibleMove.Position.LineIndex != 0 && possibleMove.Position.LineIndex != 7))
            {
                move = selectedFigure.MakeMove(selectedFigure.GetType(), possibleMove);
                MakeMove(move);
            }
            else
            {
                if ((selectedFigure.Owner == GM.Player1 && possibleMove.Position.LineIndex == 7) || (selectedFigure.Owner == GM.Player2 && possibleMove.Position.LineIndex == 0))
                {
                    ChangePanel.Visible = true;
                    BlockAllCells();
                    if (selectedTypeOfFigure != null)
                    {
                        possibleMove.MoveType = MoveType.Change;
                        move = selectedFigure.MakeMove(selectedTypeOfFigure, possibleMove);
                        selectedTypeOfFigure = null;
                        selectedFigure = null;
                        MakeMove(move);
                    }
                }
            }
        }

        private void MakeMove(Move move)
        {
            GM.UpdateInfoOnField();

            if (move.MoveResultType != MoveResultType.Mate)
            {
                selectedFigure = null;
                currentPlayer = GM.GetNextPlayer(currentPlayer);
                GM.LastMove = move;

                if (GM.Check50MoveRule())
                {
                    GM.LastMove.MoveResultType = MoveResultType.Stalemate;
                    DeclareEndOfGame();
                }
                else if (GM.LastMove.MoveResultType != MoveResultType.Check)
                {
                    var attacks = new List<Attack>();

                    foreach (var attack in GM.GetAvailableAttacks(currentPlayer, GM.GetNextPlayer(currentPlayer)))
                        attacks.Add(attack);

                    if (attacks.Count == 0)
                    {
                        GM.LastMove.MoveResultType = MoveResultType.Stalemate;
                        DeclareEndOfGame();
                    }
                }
                UnlockFiguresCells();
            }
            else
            {
                GM.LastMove = move;
                currentPlayer.Status = Status.Winner;
                GM.GetNextPlayer(currentPlayer).Status = Status.Loser;
                currentPlayer = GM.GetNextPlayer(currentPlayer);
                DeclareEndOfGame();
            }

            if (currentPlayer == GM.Player2)
            {
                GM.AllMoves.Add(new Move[2] { move, null });
                GM.UpdateInfoInMovesTable(MovesTable);
            }
            else
            {
                GM.AllMoves[GM.AllMoves.Count - 1][1] = move;
                GM.UpdateInfoInMovesTable(MovesTable);
            }

            ChangePanel.Visible = false;

            if (currentPlayer == GM.Player2)
            {
                Player1Timer.Stop();
                Player2Timer.Start();
            }
            else
            {
                Player2Timer.Stop();
                Player1Timer.Start();
            }
        }

        private void MakeDecision(Position position)
        {
            var cell = GM.Field[position.LineIndex, position.ColumnIndex];
            var figure = cell.FigureOnCell;
            selectedPossibleMove = null;

            foreach (var pm in possibleMoves)
                if (pm.Position == position)
                    selectedPossibleMove = pm;

            if (figure != null && figure.Owner == currentPlayer)
                SelectFigure(cell);
            else
                TryToMakeMove(selectedPossibleMove);
        }

        private void SubmitChangeButton_Click(object sender, EventArgs e)
        {
            var radioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton3, radioButton4};

            for (int i = 0; i < 4; i++)
            {
                if (radioButtons[i].Checked)
                {
                    switch (i)
                    {
                        case 0:
                            selectedTypeOfFigure = typeof(Queen);
                            break;

                        case 1:
                            selectedTypeOfFigure = typeof(Rook);
                            break;

                        case 2:
                            selectedTypeOfFigure = typeof(Bishop);
                            break;

                        case 3:
                            selectedTypeOfFigure = typeof(Knight);
                            break;
                    }

                    ChangePanel.Visible = false;

                    foreach (var button in radioButtons)
                        button.Checked = false;

                    TryToMakeMove(selectedPossibleMove);
                    break;
                }
            }
        }

        private void SaveGameIntoFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.FileName = "Game";
            SaveFileDialog.DefaultExt = ".txt";
            SaveFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SaveFileDialog.FileName, GM.GetGameText());
                SaveGameIntoFileButton.Visible = false;
                ExitButton.Width = 352;
            }
            else
            {
                MessageBox.Show("Unable to save game.\n" +
                                "Try again.");
            }
        }

        private void Cell64_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 7));

        private void Cell63_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 6));

        private void Cell62_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 5));

        private void Cell61_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 4));

        private void Cell60_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 3));

        private void Cell59_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 2));

        private void Cell58_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 1));

        private void Cell57_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(7, 0));

        private void Cell56_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 7));

        private void Cell55_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 6));

        private void Cell54_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 5));

        private void Cell53_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 4));

        private void Cell52_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 3));

        private void Cell51_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 2));

        private void Cell50_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 1));

        private void Cell49_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(6, 0));

        private void Cell48_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 7));

        private void Cell47_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 6));

        private void Cell46_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 5));

        private void Cell45_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 4));

        private void Cell44_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 3));

        private void Cell43_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 2));

        private void Cell42_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 1));

        private void Cell41_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(5, 0));

        private void Cell40_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 7));

        private void Cell39_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 6));

        private void Cell38_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 5));

        private void Cell37_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 4));

        private void Cell36_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 3));

        private void Cell35_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 2));

        private void Cell34_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 1));

        private void Cell33_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(4, 0));

        private void Cell32_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 7));

        private void Cell31_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 6));

        private void Cell30_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 5));

        private void Cell29_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 4));

        private void Cell28_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 3));

        private void Cell27_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 2));

        private void Cell26_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 1));

        private void Cell25_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(3, 0));

        private void Cell24_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 7));

        private void Cell23_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 6));

        private void Cell22_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 5));

        private void Cell21_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 4));

        private void Cell20_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 3));

        private void Cell19_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 2));

        private void Cell18_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 1));

        private void Cell17_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(2, 0));

        private void Cell16_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 7));

        private void Cell15_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 6));

        private void Cell14_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 5));

        private void Cell13_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 4));

        private void Cell12_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 3));

        private void Cell11_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 2));

        private void Cell10_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 1));

        private void Cell9_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(1, 0));

        private void Cell8_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 7));

        private void Cell7_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 6));

        private void Cell6_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 5));

        private void Cell5_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 4));

        private void Cell4_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 3));

        private void Cell3_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 2));

        private void Cell2_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 1));

        private void Cell1_Click(object sender, EventArgs e) =>
            MakeDecision(new Position(0, 0));
    }
}
