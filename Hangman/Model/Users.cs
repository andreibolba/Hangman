using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tools
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PicPath { get; set; }
        public int GamePlayed { get; set; }
        public int GameWon { get; set; }

        public User()
        {
            ID = -1;
            UserName = null;
            PicPath = null;
            GamePlayed = -1;
            GameWon = -1;
        }

        public User(int id,string userName,string picPath)
        {
            ID = id;
            UserName = userName;
            PicPath = picPath;
            GamePlayed = 0;
            GameWon = 0;
        }

        public override string ToString()
        {
            return ID.ToString()+" "+UserName+" "+PicPath+" "+GamePlayed.ToString()+" "+GameWon.ToString();
        }
    }
}
