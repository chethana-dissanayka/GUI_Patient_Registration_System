
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
    public partial class PatientsWindow : Window
    {
        public List<Patient> DatabaseData { get; private set; }
        
        public PatientsWindow()
        {
            DataContext = new PatientsWindowVM();
            InitializeComponent();
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var fname = FirstNameTextBox.Text;
                var lname = LastNameTextBox.Text;
                var age = AgeTextBox.Text;
                var address = AddressTextBox.Text;
                var nic = NICTextBox.Text;
                var dob = DOBTextBox.Text;
                var doctor = DoctorTextBox.Text;
                var gender = GenderTextBox.Text;


                if (fname != null && lname != null && address != null && nic != null && dob != null && doctor != null && age != null && gender != null)
                {
                    context.Patients.Add(new Patient() { First_Name = fname, Last_Name = lname, Address = address, NIC_Number = nic, DOB = dob, Doctor = doctor, Age = age, Gender = gender });

                    context.SaveChanges();
                }

            }
        }
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                DatabaseData = context.Patients.ToList();
                ItemList1.ItemsSource = DatabaseData;
            }
        }
        public void Update()
        {
            using (DataContext context = new DataContext())
            {

                Patient selectedPatient = ItemList1.SelectedItem as Patient;

                var fname = FirstNameTextBox.Text;
                var lname = LastNameTextBox.Text;
                var address = AddressTextBox.Text;
                var nic = NICTextBox.Text;
                var dob = DOBTextBox.Text;
                var doctor = DoctorTextBox.Text;
                var age = AgeTextBox.Text;
                var gender = GenderTextBox.Text;



                if (fname != null && lname != null && address != null && nic != null && dob != null && doctor != null && age != null && gender != null)
                {

                    Patient patient = context.Patients.Single(x => x.Patient_Id == selectedPatient.Patient_Id);
                    patient.First_Name = fname;
                    patient.Last_Name = lname;
                    patient.Address = address;
                    patient.NIC_Number = nic;
                    patient.DOB = dob;
                    patient.Doctor = doctor;
                    patient.Age = age;
                    patient.Gender = gender;
                    context.SaveChanges();

                }
            }

        }

        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Patient selectedPatient = ItemList1.SelectedItem as Patient;

                if (selectedPatient != null)
                {

                    Patient patient = context.Patients.Single(x => x.Patient_Id == selectedPatient.Patient_Id);

                    context.Remove(patient);
                    context.SaveChanges();

                }

            }
        }
        private void ItemList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Exit1_Button(object sender, RoutedEventArgs e)
        {
            var Window = new LoginWindow();
            Window.Show();
            this.Close();
        }

        
        
        private void Back1_Button(object sender, RoutedEventArgs e)
        {
           

            var Window = new MainWindow();
            Window.Show();
            this.Close();
        }
    

        private void Create1Button_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Read();

        }

        private void Read1Button_Click(object sender, RoutedEventArgs e)
        {
            Read();

        }

        private void Update1Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();

        }

        private void Delete1Button_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();

        }
        private void Menu1Item_Click(object sender, RoutedEventArgs e)
        {
            ItemList1.Items.Clear();
        }

    }
}












