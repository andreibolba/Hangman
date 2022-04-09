using Hangman.Tools;
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
        }

        public static ObservableCollection<string> usernames { get; set; }

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
            PlayGameView gameView=new PlayGameView();
            gameView.Show();
        }

        public void deleteProfile(object parameter)
        {
            MessageBox.Show("Delete Profile");
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
