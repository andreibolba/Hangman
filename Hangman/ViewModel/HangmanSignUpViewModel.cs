﻿using Hangman.Tools;
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
            path = Tool.profileImages();
            index = 0;
            imagePath = path[index];
            nextVisibility = true;
            prevVisibility = false;
        }

        public bool nextVisibility { get; set; }
        public bool prevVisibility { get; set; }

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
            if(index==path.Count-1)
            {
                MessageBox.Show("Ultima imagine");
            }
            else
            {
                index++;
                imagePath = path[index];
                //to add to setter
                OnPropertyChanged("imagePath");
            }
        }

        public void prev(object paramater)
        {
            if (index == 0)
            {
                MessageBox.Show("Prima imagine");
            }
            else
            {
                index--;
                imagePath = path[index];
                OnPropertyChanged("imagePath");
            }
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
