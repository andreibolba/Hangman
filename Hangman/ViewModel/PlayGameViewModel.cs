﻿using Hangman.Tools;
using Hangman.View;
using System.Collections.Generic;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class PlayGameViewModel: BaseVM
    {

        public string Header { get; set; }
        public string labelContent { get; set; }

        public static List<string> allCategories { get; set; }
        public static List<string> cars { get; set; }
        public static List<string> movies { get; set; }
        public static List<string> city { get; set; }
        public static List<string> country { get; set; }

        private string word;

        private ICommand m_social;
        private ICommand m_catrories;

        public void social(object parater)
        {
            switch (Header)
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
            switch (Header)
            {
                case "All Categories":
                    word = Tool.getWord(allCategories);
                    break;
                case "Cars":
                    word = Tool.getWord(cars);
                    break;
                case "City":
                    word = Tool.getWord(city);
                    break;
                case "Country":
                    word = Tool.getWord(country);
                    break;
                case "Movie":
                    word = Tool.getWord(movies);
                    break;
                default:
                    break;
            }
            labelContent = "Melania";
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
