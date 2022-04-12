using Hangman.Model;
using Hangman.Tools;
using Hangman.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class PlayGameViewModel: BaseVM
    {
        public PlayGameViewModel()
        {
            userText = "Hello " + currentUser.UserName + "!";
            currentStage = "./image/stage/part_one.png";
        }

        public static User currentUser { get; set; }
        public string labelContent { get; set; }
        public string userText { get; set; }
        public string currentStage { get; set; }

        private string word;

        private ICommand m_social;
        private ICommand m_catrories;

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
            string header=parater.ToString();
            word=Tool.getStartWord(header);
            labelContent = Tool.getTextFirstTime(word);
            OnPropertyChanged("labelContent");
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
    }
}
