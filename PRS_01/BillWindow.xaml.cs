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
   
    public partial class BillWindow : Window
    {
        public List<Bill> DatabaseData { get; private set; }
       
        public BillWindow()
        {
            DataContext = new BillWindowVM();
            InitializeComponent();
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                string name = NameTextBox.Text;
                var adddate=AdateTextBox.Text;
                var disdate=DdateTextBox.Text;
                int no_days; 
                no_days = int.Parse(No_DaysTextBox.Text);
                float total, ser_charge, doc_charge;
                ser_charge=float.Parse(ServiceTextBox.Text);
                doc_charge=float.Parse(DocChargeTextBox.Text);
                total=(ser_charge*no_days) + (doc_charge*no_days);
               
                TotalTextBox.Text = "" + total;


                if (name != null && adddate != null && disdate != null && no_days != null && doc_charge != null && ser_charge != null && total != null)
                {

                    context.Bills.Add(new Bill() { Name = name, Add_Date = adddate, Dis_Date = disdate, Total = total, No_Days = no_days, Doctor_Charge = doc_charge, Service_Charge = ser_charge });

                    context.SaveChanges();
                }

            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseData = context.Bills.ToList();
                ItemList2.ItemsSource = DatabaseData;
            }

        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {

                Bill selectedBill = ItemList2.SelectedItem as Bill;

    
                string name = NameTextBox.Text;
                var adddate = AdateTextBox.Text;
                var disdate = DdateTextBox.Text;
                int no_days;
                no_days = int.Parse(No_DaysTextBox.Text);
                float total, ser_charge, doc_charge;
                ser_charge=float.Parse(ServiceTextBox.Text);
                doc_charge=float.Parse(DocChargeTextBox.Text);
                total=(ser_charge* no_days) + (doc_charge* no_days);
              
                TotalTextBox.Text = "" + total;


                if (name != null && adddate != null && disdate != null && no_days != null && total != null && doc_charge != null && ser_charge != null)

                {

                    Bill bill = context.Bills.Single(x => x.Id == selectedBill.Id);
                    bill.Name = name;
                    bill.Total = total;
                    bill.Add_Date = adddate;
                    bill.Dis_Date = disdate;
                    bill.No_Days = no_days;
                    bill.Doctor_Charge = doc_charge;
                    bill.Service_Charge = ser_charge;

                    context.SaveChanges();

                }
            }

        }

        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Bill selectedBill = ItemList2.SelectedItem as Bill;

                if (selectedBill != null)
                {

                    Bill bill = context.Bills.Single(x => x.Id == selectedBill.Id);

                    context.Remove(bill);
                    context.SaveChanges();

                }

            }
        }
        private void ItemList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit2_Button(object sender, RoutedEventArgs e)
        {
            var Window = new LoginWindow();
            Window.Show();
            this.Close();
        }

        private void Back2_Button(object sender, RoutedEventArgs e)
        {
            var Window = new MainWindow();
            Window.Show();
            this.Close();
        }
        private void Create2Button_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();

        }

        private void Read2Button_Click(object sender, RoutedEventArgs e)
        {
            Read();

        }

        private void Update2Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();

        }

        private void Delete2Button_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();

        }
        private void Menu2Item_Click(object sender, RoutedEventArgs e)
        {
            ItemList2.Items.Clear();
        }


    }
}
