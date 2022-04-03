using Hangman.Tools;
using Hangman.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Hangman.ViewModel
{
    public class HangmanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static List<string> allCategories { get; set; }
        public static List<string> cars { get; set; }
        public static List<string> movies { get; set; }
        public static List<string> city { get; set; }
        public static List<string> country { get; set; }
        public static List<string> photos { get; set; }

        private string word=null;
        private const int lives = 7;
        private int lifeUsed = 0;

        public static Button m_letter { get; set; }
        public static MenuItem m_item { get; set; }
        
        private ICommand m_pressLetter;
        private ICommand m_social;
        private ICommand m_catrories;


        public void pressLetter(object parameter)
        {
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Choose a word");
            }
            else
            {
                string text = m_letter.Content.ToString();
                bool hasGuessed = false;
                string newText = Tool.oneLetterTry(PlayGameView.label.Content.ToString(), word, text, ref hasGuessed);
                if (hasGuessed == false)
                {
                    lifeUsed++;
                    PlayGameView.setPicture(photos[lifeUsed]);
                }
                m_letter.Visibility = Visibility.Hidden;
                PlayGameView.label.Content = newText;
                if (newText == word)
                {
                    MessageBox.Show("You won one game!");
                }
                if (lifeUsed == lives)
                    MessageBox.Show("Game lost!\nThe word was: " + word);
            }
        }

        public void social(object parater)
        {
            string title=m_item.Header.ToString();
            switch(title){
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
            string title = m_item.Header.ToString();
            switch (title)
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
            PlayGameView.label.Content = Tool.getTextFirstTime(word);
        }

        public ICommand PressLetter
        {
            get {
                if (m_pressLetter == null)
                    m_pressLetter = new RelayCommand(pressLetter);
                return m_pressLetter;
            }
        } 
        
        public ICommand Social
        {
            get
            {
                if (m_social == null)
                    m_social= new RelayCommand(social);
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
