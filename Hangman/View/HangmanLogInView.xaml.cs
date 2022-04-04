using Hangman.Tools;
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
    /// Interaction logic for HangmanView.xaml
    /// </summary>
    public partial class HangmanView : Window
    {
        public List<User> users { get; set; }
        public HangmanView()
        {
            InitializeComponent();
            users=Tool.readUsers();
            foreach (User user in users)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = user.ID;
                listViewItem.Content = user.UserName;
                listViewItem.MouseDoubleClick += listViewDoubleClick;
                usernames.Items.Add(listViewItem);
            }
        }

        private void listViewDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item=sender as ListViewItem;
            string id=item.Tag as string;
            string path = Tool.getPath(users, id);
            Uri resourceUri = new Uri(path, UriKind.Relative);
            picture.Source = new BitmapImage(resourceUri);
        }
    }
}
