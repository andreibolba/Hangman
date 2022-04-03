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
        public static List<string> profilePhotos { get; set; }

        private string word=null;
        private const int lives = 7;
        private int lifeUsed = 0;
        public static int imgIndex { get; set; }

        public static Button m_letter { get; set; }
        public static MenuItem m_item { get; set; }
        
        private ICommand m_pressLetter;
        private ICommand m_social;
        private ICommand m_catrories;
        private ICommand m_exit;
        private ICommand m_newPorfile;
        private ICommand m_prev;
        private ICommand m_next;


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

        public void closeApp(object parater)
        {
            MessageBox.Show("Tapa nu se inchide");
        }

        public void nextBtn(object parater)
        {
            if(imgIndex == 0)
                HangmanSignUp.prevBtn.Visibility= Visibility.Visible;
            if(imgIndex==profilePhotos.Count-2)
                HangmanSignUp.nextBtn.Visibility= Visibility.Hidden;
            imgIndex++;
            HangmanSignUp.setPicture(profilePhotos[imgIndex]);
        }

        public void prevBtn(object parater)
        {
            if (imgIndex == profilePhotos.Count - 2)
                HangmanSignUp.nextBtn.Visibility = Visibility.Visible;
            if(imgIndex==1)
                HangmanSignUp.prevBtn.Visibility = Visibility.Hidden;
            imgIndex--;
            HangmanSignUp.setPicture(profilePhotos[imgIndex]);
        }

        public void newProfile(object parater)
        {
            HangmanSignUp hangman=  new HangmanSignUp();
            hangman.Show();
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

        public ICommand Exit
        {
            get
            {
                if (m_exit == null)
                    m_exit = new RelayCommand(closeApp);
                return m_exit;
            }
        }

        public ICommand NewProfile
        {
            get
            {
                if (m_newPorfile == null)
                    m_newPorfile = new RelayCommand(newProfile);
                return m_newPorfile;
            }
        }

        public ICommand Next
        {
            get
            {
                if (m_next == null)
                    m_next = new RelayCommand(nextBtn);
                return m_next;
            }
        }

        public ICommand Prev
        {
            get
            {
                if (m_prev == null)
                    m_prev = new RelayCommand(prevBtn);
                return m_prev;
            }
        }
    }
}                                                                       
