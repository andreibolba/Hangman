using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.ViewModel
{
    class StatisticsViewModel:BaseVM
    {
        public StatisticsViewModel()
        {
            mainLabel = currentUser.UserName + " statistics";
            gameWon = currentUser.GameWon.ToString();
            minigamePlayed=currentUser.TotalGamesPlayed.ToString();
            minigameWon=currentUser.MinigamesWon.ToString();
            minigameLost=(currentUser.TotalGamesPlayed-currentUser.MinigamesWon).ToString();
        }

        public static User currentUser { get; set; }
        public string mainLabel { get; set; }
        public string gameWon { get; set; }
        public string minigameWon { get; set; }
        public string minigamePlayed { get; set; }
        public string minigameLost { get; set; }
    }
}
