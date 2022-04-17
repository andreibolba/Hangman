using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman.ViewModel
{
    class StatisticsViewModel:BaseVM
    {
        public StatisticsViewModel()
        {
            mainLabel = currentUser.UserName + " statistics";
            gameWon = currentUser.GameWon.ToString();
            float minigameP = currentUser.TotalGamesPlayed, minigameW = currentUser.MinigamesWon, minigameL = minigameP - minigameW;
            minigamePlayed = minigameP.ToString();
            minigameWon = minigameW.ToString() + "(" + (minigameW * 100 / minigameP).ToString("0.00") + "%)";
            minigameLost = minigameL.ToString() + "(" + (100- (minigameW * 100 / minigameP)).ToString("0.00") + "%)";
        }

        public static User currentUser { get; set; }
        public string mainLabel { get; set; }
        public string gameWon { get; set; }
        public string minigameWon { get; set; }
        public string minigamePlayed { get; set; }
        public string minigameLost { get; set; }
    }
}
