using Hangman.Model;
using Hangman.Tools;
using Hangman.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class PlayGameViewModel : BaseVM
    {
        public PlayGameViewModel()
        {
            userText = "Hello " + currentUser.UserName + "!";
            startGame();
        }

        public ObservableCollection<Button> firstLetterRow { get; set; }
        public ObservableCollection<Button> secondLetterRow { get; set; }
        public ObservableCollection<Button> thirdLetterRow { get; set; }

        public static User currentUser { get; set; }
        public string labelContent { get; set; }
        public string userText { get; set; }
        public string currentStage { get; set; }
        public string finishTextVisibility { get; set; }
        public string initialTextVisibility { get; set; }

        private string word;
        private int tries;

        private ICommand m_social;
        private ICommand m_catrories;
        private ICommand m_buttonpress;
        private ICommand m_newgame;

        private void startGame()
        {
            currentStage = "./image/stage/part_one.png";
            finishTextVisibility = "Hidden";
            initialTextVisibility = "Visible";
            word = null;
            labelContent = null;
            tries = 0;
            firstLetterRow = new ObservableCollection<Button> { new Button("Q"), new Button("W"), new Button("E"), new Button("R"), new Button("T"), new Button("Y"), new Button("U"), new Button("I"), new Button("O"), new Button("P") };
            secondLetterRow = new ObservableCollection<Button> { new Button("A"), new Button("S"), new Button("D"), new Button("F"), new Button("G"), new Button("H"), new Button("J"), new Button("K"), new Button("L") };
            thirdLetterRow = new ObservableCollection<Button> { new Button("Z"), new Button("X"), new Button("C"), new Button("V"), new Button("B"), new Button("N"), new Button("M"), new Button("I") };
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

        public void categories(object parater)
        {
            initialTextVisibility = "Hidden";
            string header = parater.ToString();
            word = Tool.getStartWord(header);
            labelContent = Tool.getTextFirstTime(word);
            OnPropertyChanged("labelContent");
            OnPropertyChanged("initialTextVisibility");
        }

        public void changeVisibility(string letter)
        {
            int index = 0;
            for(index = 0;index < firstLetterRow.Count;index++)
                if (firstLetterRow[index].label == letter)
                    firstLetterRow[index] = new Button(letter, "Hidden");
            for(index = 0;index < secondLetterRow.Count;index++)
                if (secondLetterRow[index].label == letter)
                    secondLetterRow[index] = new Button(letter, "Hidden");
            for(index = 0;index < thirdLetterRow.Count;index++)
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
                    if(text==word)
                    {
                        MessageBox.Show("You won one game");
                        finishGame();
                        finishTextVisibility = "Visible";
                        OnPropertyChanged("finishTextVisibility");
                    }
                }
                else
                {
                    tries++;
                    currentStage = Tool.images()[tries];
                    OnPropertyChanged("currentStage");
                    if (tries == Tool.images().Count - 1)
                    {
                        MessageBox.Show("Lost game!\nThe word was: "+word);
                        finishGame();
                        finishTextVisibility = "Visible";
                        OnPropertyChanged("finishTextVisibility");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Choose a category");
            }
        }

        public void newGame(object parameter)
        {
            startGame();
            OnPropertyChanged("finishTextVisibility");
            OnPropertyChanged("firstLetterRow");
            OnPropertyChanged("secondLetterRow");
            OnPropertyChanged("thirdLetterRow");
            OnPropertyChanged("currentStage");
            OnPropertyChanged("labelContent");
            OnPropertyChanged("initialTextVisibility");
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
                if(m_newgame==null)
                    m_newgame = new RelayCommand(newGame);
                return m_newgame;
            }
        }
    }
}
