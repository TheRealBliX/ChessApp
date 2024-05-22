using System;
using System.IO;
using System.Windows.Forms;

namespace Chess
{
    internal class InfoHolder
    {
        internal static string Player1Name { get; private set; }
        internal static string Player2Name { get; private set; }
        internal static int? Time { get; private set; }
        internal static bool? IsHKMOn { get; private set; }

        internal static void LoadInfo(string player1Name, string player2Name, int time, bool isHKMOn)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
            Time = time;
            IsHKMOn = isHKMOn;

            var isHKMOnText = (bool)IsHKMOn ? "t" : "f";
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), 
                                           "..\\..\\GameInfo\\Config.txt"), $"{Player1Name}\n{Player2Name}\n{Convert.ToString(time)}\n{isHKMOnText}");
        }
    }
}
