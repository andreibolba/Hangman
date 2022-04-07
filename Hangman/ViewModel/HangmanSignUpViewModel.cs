using Hangman.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    class HangmanSignUpViewModel:BaseVM
    {

        public HangmanSignUpViewModel()
        {
            path = Tool.images();
            index = 0;
        }

        public List<string> path { get; set; }
        public int index;
        public string imagePath { get; set; }
        public string inputName { get; set; }

        private ICommand m_create;
        private ICommand m_next;
        private ICommand m_prev;

        public void create(object parameter)
        {
            MessageBox.Show(inputName);
        }

        public void next(object paramater)
        {

        }

        public void prev(object paramater)
        {

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
                if(m_prev == null)
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
