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
using Hangman.Tools;

namespace Hangman.View
{
    /// <summary>
    /// Interaction logic for PlayGameView.xaml
    /// </summary>
    public partial class PlayGameView : Window
    {
        //posibil sa fie schimbata
        public static Label label { get; set; } 
        public static Image progresPic { get; set; }

        public PlayGameView()
        {
            InitializeComponent();
            HangmanViewModel.allCategories = Tool.readWords("allCategories.txt");
            HangmanViewModel.cars = Tool.readWords("cars.txt");
            HangmanViewModel.movies = Tool.readWords("movies.txt");
            HangmanViewModel.city = Tool.readWords("city.txt");
            HangmanViewModel.country = Tool.readWords("country.txt");
            HangmanViewModel.photos = Tool.images();
            currentUser.Content = "Hello " + HangmanViewModel.currentUser.UserName.ToString();
            label = linesWord;
            progresPic = progressPicture;
        }

        private void Letter_Click(object sender, RoutedEventArgs e)
        {
            HangmanViewModel.m_letter = sender as Button;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HangmanViewModel.m_item = sender as MenuItem;
        }

        public static void setPicture(string path)
        {
            Uri resourceUri = new Uri(path, UriKind.Relative);
            progresPic.Source = new BitmapImage(resourceUri);
        }
    }
}
