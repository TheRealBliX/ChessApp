using System;
using System.IO;
using System.Windows.Forms;

namespace Chess
{
    public partial class Menu : Form
    {
        private string player1Name, player2Name;
        private int time;
        private bool isHKMON;

        public Menu()
        {
            InitializeComponent();

            StreamReader streamReader = new StreamReader(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "..\\..\\GameInfo\\Config.txt"));
            var index = 0;
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                index++;
                switch (index)
                {
                    case 1:
                        player1Name = line;
                        break;
                    case 2:
                        player2Name = line;
                        break;
                    case 3:
                        if (int.TryParse(line, out int time))
                            this.time = time;
                        else
                            MessageBox.Show("Wrong type of time inside of config.");
                        break;
                    case 4:
                        switch (line)
                        {
                            case "t":
                                isHKMON = true;
                                break;

                            case "f":
                                isHKMON = false;
                                break;

                            default:
                                MessageBox.Show("Wrong type of HKM inside of config.");
                                break;
                        }
                        break;
                }
            }

            streamReader.Close();

            InfoHolder.LoadInfo(player1Name, player2Name, time, isHKMON);

            Player2NameTextbox.Text = InfoHolder.Player1Name;
            Player2NameTextbox.Text = InfoHolder.Player2Name;

            TimeTextbox.Text = Convert.ToString(InfoHolder.Time);

            HKMCheckbox.Checked = (bool)InfoHolder.IsHKMOn;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (Player1NameTextbox.Text != null && Player2NameTextbox.Text != null && int.TryParse(TimeTextbox.Text, out int time))
            {
                InfoHolder.LoadInfo(Player1NameTextbox.Text, Player2NameTextbox.Text, time, HKMCheckbox.Checked);
                Hide();
                new Board().ShowDialog();
            }
            else
            {
                MessageBox.Show("Some information have unsupported format.");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) =>
            Application.Exit();
    }
}
