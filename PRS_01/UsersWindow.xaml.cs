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

namespace PRS_01
{
    public partial class UsersWindow : Window
    {
        public List<User> DatabaseData { get; private set; }

        public UsersWindow()
        {
            DataContext = new UsersWindowVM();
            InitializeComponent();
        }

        public void Create()
        {
            using(DataContext context = new DataContext())
            {
                var name=NameTextBox.Text;
                var password=PasswordTextBox.Text;

                if ( name!=null && password!=null)
                {
                    context.Users.Add(new User() { User_Name = name, Password = password });
                    context.SaveChanges();
                }

            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseData= context.Users.ToList();
                ItemList.ItemsSource= DatabaseData;
            }

        }
        public void Update()
        {
                using (DataContext context = new DataContext())
                {


                    User selectedUser = ItemList.SelectedItem as User;
                    var name = NameTextBox.Text;
                    var password = PasswordTextBox.Text;

                    if (name != null && password != null)
                    {

                         User user = context.Users.Single(x => x.User_Id == selectedUser.User_Id);
                         user.User_Name=name;
                         user.Password=password;
                          context.SaveChanges();

                    } 
                }

        }
        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                User? selectedUser = ItemList.SelectedItem as User;

                if (selectedUser != null)
                {

                    User user = context.Users.Single(x=>x.User_Id==selectedUser.User_Id);

                    context.Remove(user);
                    context.SaveChanges();

                }

            }
        }
       

        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            var Window = new MainWindow();
            Window.Show();
            this.Close();
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            var Window = new AdminWindow();
            Window.Show();
            this.Close();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
    }
}
