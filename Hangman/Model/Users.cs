using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PicPath { get; set; }
        public int GameWon { get; set; }
        public int MinigamesInRow { get; set; }
        public int MinigamesWon { get; set; }
        public int TotalGamesPlayed { get; set; }
        

        public User()
        {
            ID = -1;
            UserName = "";
            PicPath = "";
            GameWon = -1;
            MinigamesInRow = -1;
            MinigamesWon = -1;
            TotalGamesPlayed = -1;
        }

        public User(int id,string userName,string picPath)
        {
            ID = id;
            UserName = userName;
            PicPath = picPath;
            GameWon = 0;
            MinigamesInRow = 0;
            MinigamesWon = 0;
            TotalGamesPlayed = 0;
        }

        public override string ToString()
        {
            return ID.ToString()+" "+UserName+" "+PicPath+" "+GameWon.ToString();
        }
    }
}
