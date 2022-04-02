using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hangman.ViewModel;

namespace Hangman.View
{
    /// <summary>
    /// Interaction logic for PlayGameView.xaml
    /// </summary>
    public partial class PlayGameView : Window
    {
        public PlayGameView()
        {
            InitializeComponent();
        }

        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            HangmanViewModel.m_letter=sender as Button;
            
        }
    }
}
