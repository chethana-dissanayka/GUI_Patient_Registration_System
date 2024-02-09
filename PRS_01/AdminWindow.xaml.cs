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
   
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
          
            InitializeComponent();
        }
        private void SR_1(object sender, RoutedEventArgs e)
        {
            var Window = new UsersWindow();
            Window.Show();
            this.Close();
        }
        private void PR_1(object sender, RoutedEventArgs e)
        {
            var Window = new PatientsWindow();
            Window.Show();
            this.Close();
        }

        private void BC_1(object sender, RoutedEventArgs e)
        {
            var Window = new BillWindow();
            Window.Show();
            this.Close();
        }

        private void Back_1(object sender, RoutedEventArgs e)
        {
            var Window = new MainWindow();
            Window.Show();
            this.Close();
        }

        private void E_1(object sender, RoutedEventArgs e)
        {
            var Window = new LoginWindow();
            Window.Show();
            this.Close();
        }
    }
}
