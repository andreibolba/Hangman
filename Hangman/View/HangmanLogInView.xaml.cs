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
        public static List<User> users { get; set; }

        public static ListView usersListView { get; set; }

        public static ListViewItem selectedItem { get; set; }

        public static bool isSelected { get; set; }

        public HangmanView()
        {
            InitializeComponent();
            users=Tool.readUsers();
            usersListView = usernames;
            foreach (User user in users)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = user.ID.ToString();
                listViewItem.Content = user.UserName;
                listViewItem.MouseDoubleClick += listViewDoubleClick;
                usersListView.Items.Add(listViewItem);
            }
            selectedItem=new ListViewItem();
            isSelected=false;
        }

        private void listViewDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item=sender as ListViewItem;
            string id=item.Tag as string;
            int ID = Int32.Parse(id);
            //MessageBox.Show(ID.ToString());
            string path = Tool.getPath(users, ID);
            Uri resourceUri = new Uri(path, UriKind.Relative);
            picture.Source = new BitmapImage(resourceUri);
            selectedItem = item;
            isSelected=true;
        }
    }
}
