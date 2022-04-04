using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tools
{
    public class User
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string PicPath { get; set; }
        public string GamePlayed { get; set; }
        public string GameWon { get; set; }

        public User()
        {
            ID = null;
            UserName = null;
            PicPath = null;
            GamePlayed = null;
            GameWon = null;
        }

        public User(string id,string userName,string picPath, string gamePlayed, string gameWon)
        {
            ID = id;
            UserName = userName;
            PicPath = picPath;
            GamePlayed = gamePlayed;
            GameWon = gameWon;
        }

        public override string ToString()
        {
            return UserName+" "+GamePlayed+" "+GameWon;
        }
    }
}
