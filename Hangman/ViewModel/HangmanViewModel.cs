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
        
        private ICommand m_pressLetter;


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

        public ICommand PressLetter
        {
            get {
                if (m_pressLetter == null)
                    m_pressLetter = new RelayCommand(pressLetter);
                return m_pressLetter;
            }
        }                                                                                                                                                                                                                             
    }
}                                                                       
