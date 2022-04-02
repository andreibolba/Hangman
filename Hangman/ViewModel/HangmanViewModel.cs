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

namespace Hangman.ViewModel
{
    public class HangmanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Button m_letter { get; set; }
        public static MenuItem m_item { get; set; }
        
        private ICommand m_pressLetter;
        private ICommand m_social;


        public void pressLetter(object parameter)
        {
            string text=m_letter.Content.ToString();
            if (string.IsNullOrEmpty(text))
                MessageBox.Show("Tapa");
            else
            {
                MessageBox.Show(text);
                m_letter.Visibility = Visibility.Hidden;
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
    }
}                                                                       
