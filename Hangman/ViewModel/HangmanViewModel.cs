using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    public class HangmanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand m_pressLetter;

        public void pressLetter(object parameter)
        {
            MessageBox.Show("Merge");
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
