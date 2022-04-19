using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class HangmanSignUpViewModel : BaseVM
    {

        public HangmanSignUpViewModel()
        {
            path = Tool.profileImages();
            index = 0;
            imagePath = path[index];
            nextVisibility = "Visible";
            prevVisibility = "Hidden";
        }

        public string nextVisibility { get; set; }
        public string prevVisibility { get; set; }

        public List<string> path { get; set; }
        public int index;
        public string imagePath { get; set; }

        public string inputName { get; set; }

        private ICommand m_create;
        private ICommand m_next;
        private ICommand m_prev;

        public void create(object parameter)
        {
            if (string.IsNullOrEmpty(inputName))
                MessageBox.Show("No name entered!");
            else
            {
                if (Tool.isUsernameValid(inputName))
                {
                    HangmanLogInViewModel.usernames.Add(inputName);
                    Tool.addUser(new User(Tool.getId(), inputName, imagePath));
                }
                else
                {
                    MessageBox.Show("Username already exists!","Duplicate username");
                }
            }
        }

        public void next(object paramater)
        {
            if (index + 1 == path.Count - 1)
            {
                nextVisibility = "Hidden";
                OnPropertyChanged("nextVisibility");
            }

            index++;
            imagePath = path[index];
            prevVisibility = "Visible";
            OnPropertyChanged("imagePath");
            OnPropertyChanged("prevVisibility");

        }

        public void prev(object paramater)
        {
            if (index - 1 == 0)
            {
                prevVisibility = "Hidden";

                OnPropertyChanged("prevVisibility");
            }
            index--;
            imagePath = path[index];
            nextVisibility = "Visible";
            OnPropertyChanged("imagePath");
            OnPropertyChanged("nextVisibility");

        }


        public ICommand Next
        {
            get
            {
                if (m_next == null)
                    m_next = new RelayCommand(next);
                return m_next;
            }
        }

        public ICommand Prev
        {
            get
            {
                if (m_prev == null)
                    m_prev = new RelayCommand(prev);
                return m_prev;
            }
        }

        public ICommand Create
        {
            get
            {
                if (m_create == null)
                    m_create = new RelayCommand(create);
                return m_create;
            }
        }
    }
}
