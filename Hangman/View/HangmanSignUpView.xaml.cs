﻿using Hangman.Tools;
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
        public HangmanSignUp()
        {
            InitializeComponent();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
