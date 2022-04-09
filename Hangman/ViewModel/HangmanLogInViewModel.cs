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

        public void newProfile(object parameter)
        {
            HangmanSignUp signUp=new HangmanSignUp();
            signUp.Show();
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
