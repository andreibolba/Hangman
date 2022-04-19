using Hangman.Model;
using Hangman.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class PlayGameViewModel : BaseVM
    {
        public PlayGameViewModel()
        {
            savedGames = Tool.getGames(currentUser.ID);
            userText = "Hello " + currentUser.UserName + "!";
            startGame();
        }

        public ObservableCollection<Button> firstLetterRow { get; set; }
        public ObservableCollection<Button> secondLetterRow { get; set; }
        public ObservableCollection<Button> thirdLetterRow { get; set; }
        public ObservableCollection<Game> savedGames { get; set; } 
        public ObservableCollection<string> progressPicture { get; set; }

        public static User currentUser { get; set; }
        public string labelContent { get; set; }
        public string userText { get; set; }
        public string currentStage { get; set; }
        public string finishTextVisibility { get; set; }
        public string initialTextVisibility { get; set; }
        public string timer { get; set; }

        private string word;
        private string header;
        private int tries;
        private int time;
        private bool canStart;
        private bool isFinished;
        private bool playing;
        private Thread timerLeft;

        private ICommand m_social;
        private ICommand m_catrories;
        private ICommand m_buttonpress;
        private ICommand m_newgame;
        private ICommand m_stats;
        private ICommand m_save;
        private ICommand m_load;

        private void startGame()
        {
            currentStage = "./image/stage/part_one.png";
            finishTextVisibility = "Hidden";
            initialTextVisibility = "Visible";
            time = 30;
            timer = time.ToString() + " seconds";
            word = null;
            labelContent = null;
            tries = 0;
            progressPicture = new ObservableCollection<string>();
            int goodProgress = currentUser.MinigamesInRow;
            for (int j = 0; j < goodProgress; j++)
                progressPicture.Add("./image/check.png");
            for (int j = goodProgress; j < 5; j++)
                progressPicture.Add("./image/lock.png");
            firstLetterRow = new ObservableCollection<Button> { new Button("Q"), new Button("W"), new Button("E"), new Button("R"), new Button("T"), new Button("Y"), new Button("U"), new Button("I"), new Button("O"), new Button("P") };
            secondLetterRow = new ObservableCollection<Button> { new Button("A"), new Button("S"), new Button("D"), new Button("F"), new Button("G"), new Button("H"), new Button("J"), new Button("K"), new Button("L") };
            thirdLetterRow = new ObservableCollection<Button> { new Button("Z"), new Button("X"), new Button("C"), new Button("V"), new Button("B"), new Button("N"), new Button("M") };
            canStart = true;
            isFinished = false;
            
        }

        private void timeLeft()
        {
            while (time!=0)
            {
                Thread.Sleep(1000);
                time--;
                if(time==1)
                timer = time.ToString() + " second";
                else
                    timer = time.ToString() + " seconds";
                OnPropertyChanged("timer");
            }
            MessageBox.Show("Time exceeded!You lost a game!\nThe word was: " + word,"Lost game");
            currentUser.MinigamesInRow = 0;
            currentUser.TotalGamesPlayed++;
            Tool.update(currentUser);
            int goodProgress = currentUser.MinigamesInRow;
            progressPicture = new ObservableCollection<string>();
            for (int j = 0; j < goodProgress; j++)
                progressPicture.Add("./image/check.png");
            for (int j = goodProgress; j < 5; j++)
                progressPicture.Add("./image/lock.png");
            OnPropertyChanged("progressPicture");
            canStart = false;
            firstLetterRow = new ObservableCollection<Button> { new Button("Q","Hidden"), new Button("W", "Hidden"), new Button("E", "Hidden"), new Button("R", "Hidden"), new Button("T", "Hidden"), new Button("Y", "Hidden"), new Button("U", "Hidden"), new Button("I", "Hidden"), new Button("O", "Hidden"), new Button("P", "Hidden") };
            secondLetterRow = new ObservableCollection<Button> { new Button("A", "Hidden"), new Button("S", "Hidden"), new Button("D", "Hidden"), new Button("F", "Hidden"), new Button("G", "Hidden"), new Button("H", "Hidden"), new Button("J", "Hidden"), new Button("K", "Hidden"), new Button("L", "Hidden") };
            thirdLetterRow = new ObservableCollection<Button> { new Button("Z", "Hidden"), new Button("X", "Hidden"), new Button("C", "Hidden"), new Button("V", "Hidden"), new Button("B", "Hidden"), new Button("N", "Hidden"), new Button("M", "Hidden") };
            OnPropertyChanged("firstLetterRow");
            OnPropertyChanged("secondLetterRow");
            OnPropertyChanged("thirdLetterRow");
            finishTextVisibility = "Visible";
            OnPropertyChanged("finishTextVisibility");
            timerLeft.Abort();
        }

        public void social(object parater)
        {
            string header = parater.ToString();
            switch (header)
            {
                case "LinkdIn":
                    System.Diagnostics.Process.Start("https://www.linkedin.com/in/bolba-mateescu-andrei/");
                    break;
                case "Facebook":
                    System.Diagnostics.Process.Start("https://www.facebook.com/andreibolbamateescu");
                    break;
                case "Instagram":
                    System.Diagnostics.Process.Start("https://www.instagram.com/andreibolba/");
                    break;
                case "GitHub":
                    System.Diagnostics.Process.Start("https://github.com/andreibolba");
                    break;
                case "Author":
                    Author author = new Author();
                    author.Show();
                    break;
                default:
                    break;
            }
        }

        public void stats(object parameter)
        {
            Statistics statistics = new Statistics(currentUser);
            statistics.Show();
        }

        public void categories(object parater)
        {
            if (canStart == true)
            {
                initialTextVisibility = "Hidden";
                header = parater.ToString();
                word = Tool.getStartWord(header);
                labelContent = Tool.getTextFirstTime(word);
                timerLeft = new Thread(timeLeft);
                timerLeft.Start();
                playing = true;
                OnPropertyChanged("labelContent");
                OnPropertyChanged("initialTextVisibility");
            }
            else
                MessageBox.Show("Start a game first!","Start new game!");
        }

        public void changeVisibility(string letter)
        {
            int index = 0;
            for (index = 0; index < firstLetterRow.Count; index++)
                if (firstLetterRow[index].label == letter)
                    firstLetterRow[index] = new Button(letter, "Hidden");
            for (index = 0; index < secondLetterRow.Count; index++)
                if (secondLetterRow[index].label == letter)
                    secondLetterRow[index] = new Button(letter, "Hidden");
            for (index = 0; index < thirdLetterRow.Count; index++)
                if (thirdLetterRow[index].label == letter)
                    thirdLetterRow[index] = new Button(letter, "Hidden");
        }

        public void finishGame()
        {
            int index = 0;
            for (index = 0; index < firstLetterRow.Count; index++)
                firstLetterRow[index] = new Button(firstLetterRow[index].label, "Hidden");
            for (index = 0; index < secondLetterRow.Count; index++)
                secondLetterRow[index] = new Button(secondLetterRow[index].label, "Hidden");
            for (index = 0; index < thirdLetterRow.Count; index++)
                thirdLetterRow[index] = new Button(thirdLetterRow[index].label, "Hidden");
            isFinished = true;
            playing = false;
            finishTextVisibility = "Visible";
            OnPropertyChanged("finishTextVisibility");
            timerLeft.Abort();
        }

        public void buttonPress(object parameter)
        {
            if (string.IsNullOrEmpty(word) == false)
            {
                bool hasChanged = false;
                string letter = parameter.ToString();
                string text = Tool.oneLetterTry(labelContent, word, letter, ref hasChanged);
                changeVisibility(letter);
                if (hasChanged)
                {
                    labelContent = text;
                    OnPropertyChanged("labelContent");
                    if (text == word)
                    {
                        currentUser.MinigamesWon++;
                        currentUser.MinigamesInRow++;
                        currentUser.TotalGamesPlayed++;
                        finishGame();
                        playing = false;
                        MessageBox.Show("You won one game","Minigame won");
                        int goodProgress = currentUser.MinigamesInRow;
                        progressPicture = new ObservableCollection<string>();
                        for (int j = 0; j < goodProgress; j++)
                            progressPicture.Add("./image/check.png");
                        for (int j = goodProgress; j < 5; j++)
                            progressPicture.Add("./image/lock.png");
                        OnPropertyChanged("progressPicture");
                        if (currentUser.MinigamesInRow == 5)
                        {
                            MessageBox.Show("You won a big game. Congratulation!","Big game won");
                            currentUser.MinigamesInRow = 0;
                            currentUser.GameWon++;
                            goodProgress = currentUser.MinigamesInRow;
                            progressPicture = new ObservableCollection<string>();
                            for (int j = 0; j < goodProgress; j++)
                                progressPicture.Add("./image/check.png");
                            for (int j = goodProgress; j < 5; j++)
                                progressPicture.Add("./image/lock.png");
                            OnPropertyChanged("progressPicture");

                        }
                        Tool.update(currentUser);
                        canStart = false;
                    }
                }
                else
                {
                    tries++;
                    currentStage = Tool.images()[tries];
                    OnPropertyChanged("currentStage");
                    if (tries == Tool.images().Count - 1)
                    {
                        finishGame();
                        MessageBox.Show("Lost game!\nThe word was: " + word,"Lost game!");
                        currentUser.MinigamesInRow = 0;
                        currentUser.TotalGamesPlayed++;
                        Tool.update(currentUser);
                        int goodProgress = currentUser.MinigamesInRow;
                        progressPicture = new ObservableCollection<string>();
                        for (int j = 0; j < goodProgress; j++)
                            progressPicture.Add("./image/check.png");
                        for (int j = goodProgress; j < 5; j++)
                            progressPicture.Add("./image/lock.png");
                        OnPropertyChanged("progressPicture");
                        canStart = false;
                    }
                }

            }
            else
                MessageBox.Show("Choose a category","Category");
        }

        public void newGame(object parameter)
        {
            if (playing == true)
                if (MessageBox.Show("You will lose all progress!", "Are you sure?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    currentUser.MinigamesInRow = 0;
                    Tool.update(currentUser);
                    timerLeft.Abort();
                }
                else
                    return;
            startGame();
            OnPropertyChanged("finishTextVisibility");
            OnPropertyChanged("firstLetterRow");
            OnPropertyChanged("secondLetterRow");
            OnPropertyChanged("thirdLetterRow");
            OnPropertyChanged("currentStage");
            OnPropertyChanged("labelContent");
            OnPropertyChanged("initialTextVisibility");
            OnPropertyChanged("progressPicture");
            OnPropertyChanged("timer");
        }

        public void saveGame(object parameter)
        {
            if (playing == true)
            {
                Game game = new Game(Tool.getIdGame(),currentUser.ID, header.Remove(header.Length - 4), labelContent, word, firstLetterRow, secondLetterRow, thirdLetterRow, tries, DateTime.Now.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'"),time);
                Tool.addGame(game);
                savedGames.Add(game);
                OnPropertyChanged("savedGames");
                finishGame();
                MessageBox.Show("Your game was saved succesfully!", "Save game!");
            }
            else
                MessageBox.Show("Start a game first","Start new game");
        }

        public void loadGame(object parameter)
        {
            Game game = Tool.getGame(Int32.Parse(parameter.ToString()));
            currentStage = Tool.images()[game.Tries];
            finishTextVisibility = "Hidden";
            initialTextVisibility = "Hidden";
            time = game.timeLeft;
            timerLeft = new Thread(timeLeft);
            timerLeft.Start();
            if (time == 1)
                timer = time.ToString() + " seconds";
            else
                timer = time.ToString() + " seconds";
            word = game.WordToGuess;
            labelContent = game.Word;
            tries = game.Tries;
            firstLetterRow = game.ButtonsOne;
            secondLetterRow = game.ButtonsTwo;
            thirdLetterRow = game.ButtonsThree;
            canStart = true;
            isFinished = false;
            OnPropertyChanged("finishTextVisibility");
            OnPropertyChanged("initialTextVisibility");
            OnPropertyChanged("timer");
            OnPropertyChanged("labelContent");
            OnPropertyChanged("firstLetterRow");
            OnPropertyChanged("secondLetterRow");
            OnPropertyChanged("thirdLetterRow");
            Tool.deleteGame(game);
            savedGames.Remove(game);
        }

        public ICommand Social
        {
            get
            {
                if (m_social == null)
                    m_social = new RelayCommand(social);
                return m_social;
            }
        }

        public ICommand Categories
        {
            get
            {
                if (m_catrories == null)
                    m_catrories = new RelayCommand(categories);
                return m_catrories;
            }
        }

        public ICommand ButtonPress
        {
            get
            {
                if (m_buttonpress == null)
                    m_buttonpress = new RelayCommand(buttonPress);
                return m_buttonpress;
            }
        }

        public ICommand NewGame
        {
            get
            {
                if (m_newgame == null)
                    m_newgame = new RelayCommand(newGame);
                return m_newgame;
            }
        }

        public ICommand Stats
        {
            get
            {
                if (m_stats == null)
                    m_stats = new RelayCommand(stats);
                return m_stats;
            }
        }

        public ICommand Save
        {
            get
            {
                if (m_save == null)
                    m_save = new RelayCommand(saveGame);
                return m_save;
            }
        }

        public ICommand Load
        {
            get
            {
                if(m_load == null)
                    m_load=new RelayCommand(loadGame);
                return m_load;
            }
        }
    }
}
