using Hangman.Model;
using Hangman.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class HangmanLogInViewModel:BaseVM
    {
        public HangmanLogInViewModel()
        {
            usernames = Tool.getUsernames();
            itemIndex = -1;
            picPath = null;
        }

        public static ObservableCollection<string> usernames { get; set; }
        public string picPath { get; set; }
        private int ItemIndex;
        public int itemIndex {
            get
            {
                return ItemIndex;
            }
            set
            {
                ItemIndex = value;
                if(itemIndex!=-1)
                    picPath = Tool.getUserByUsername(usernames[itemIndex]).PicPath;
                OnPropertyChanged("picPath");
            }
        }

        private ICommand m_newProfile;
        private ICommand m_deleteProfile;
        private ICommand m_play;

        public void newProfile(object parameter)
        {
            HangmanSignUp signUp=new HangmanSignUp();
            signUp.Show();
        }

        public void play(object parameter)
        {
            if (itemIndex == -1)
                MessageBox.Show("No user selected!","Uselected user!");
            else
            {
                PlayGameView gameView = new PlayGameView(Tool.getUserByUsername(usernames[itemIndex]));
                gameView.Show();
            }

        }

        public void deleteProfile(object parameter)
        {
            if (itemIndex == -1)
                MessageBox.Show("Select a user","No user selected");
            else
            {
                Tool.deleteUser(Tool.getUserByUsername(usernames[itemIndex]));
                usernames.RemoveAt(itemIndex);
                MessageBox.Show("Users deleted succesfully","Delete succesfully");
            }
        }

        public ICommand Play
        {
            get
            {
                if(m_play == null)
                    m_play = new RelayCommand(play);
                return m_play;
            }
        }

        public ICommand DeleteProfile
        {
            get
            {
                if(m_deleteProfile == null)
                    m_deleteProfile = new RelayCommand(deleteProfile);
                return m_deleteProfile;
            }
        }

        public ICommand NewProfile
        {
            get
            {
                if (m_newProfile == null)
                    m_newProfile = new RelayCommand(newProfile);
                return m_newProfile;
            }
        }

    }
}
