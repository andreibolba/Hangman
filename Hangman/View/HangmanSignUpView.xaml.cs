using Hangman.Tools;
using Hangman.ViewModel;
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

namespace Hangman.View
{
    /// <summary>
    /// Interaction logic for HangmanSignUp.xaml
    /// </summary>
    public partial class HangmanSignUp : Window
    {
        public static Image image { get; set; }
        public static TextBox user { get; set; }
        public static Button nextBtn { get; set; }
        public static Button prevBtn { get; set; }
        public HangmanSignUp()
        {
            InitializeComponent();
            prev.Visibility= Visibility.Hidden;
            HangmanViewModel.profilePhotos = Tool.profileImages();
            HangmanViewModel.imgIndex = 0;
            image = profilePicture;
            nextBtn = next;
            prevBtn = prev;
            user = inputName;
        }

        public static void setPicture(string path)
        {
            Uri resourceUri = new Uri(path, UriKind.Relative);
            image.Source = new BitmapImage(resourceUri);
        }

    }
}
