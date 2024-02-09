using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;


namespace PRS_01
{

    public partial class MainWindow : Window
    {
        
        public string[] names { get; set; }
        
        public MainWindow()
        {

            InitializeComponent();
            names = new string[] { "Admin User", "Normal User" };
            DataContext = this;
            
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          using(DataContext context=new DataContext()) { 
                if ((UsertypeBox.Text == "Admin User") && (UsernameTextBox.Text == "Admin") && (PasswordBox.Text == "admin"))
                {
                    var Window = new AdminWindow();
                    Window.Show();
                    this.Close();
                }

            else if ((UsertypeBox.Text == "Normal User") && (context.Users.Any(Users=> Users.User_Name== UsernameTextBox.Text && PasswordBox.Text == Users.Password)))
            {
                var Window = new NormalUsersWindow();
                    Window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect User name or Password");
                    PasswordBox.Clear();
                }

          }
                
        }
    }
}
