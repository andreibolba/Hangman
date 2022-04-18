using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Model
{
    public class Game
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Word { get; set; }
        public string WordToGuess { get; set; }
        public ObservableCollection<Button> ButtonsOne { get; set; }
        public ObservableCollection<Button> ButtonsTwo { get; set; }
        public ObservableCollection<Button> ButtonsThree { get; set; }
        public int Tries { get; set; }
        public string saveTime { get; set; }
        public int timeLeft { get; set; }
        
        public Game()
        {
            Id = -1;
            Name = null;
            Word = null;
            Word = null;
            ButtonsOne = new ObservableCollection<Button>();
            ButtonsTwo = new ObservableCollection<Button>();
            ButtonsThree = new ObservableCollection<Button>();
            Tries = -1;
            saveTime = "";
            timeLeft = 0;
        }

        public Game(int gameId,int id,string name,string word,string wordGuess, ObservableCollection<Button> buttonsOne, ObservableCollection<Button> buttonsTwo, ObservableCollection<Button> buttonsThree, int tries, string time,int tLeft)
        {
            Id = gameId;
            UserId = id;
            Name = name;
            Word = word;
            WordToGuess= wordGuess;
            ButtonsOne = buttonsOne;
            ButtonsTwo = buttonsTwo;
            ButtonsThree = buttonsThree;
            Tries = tries;
            saveTime = time;
            timeLeft = tLeft;
        }
    }
}
