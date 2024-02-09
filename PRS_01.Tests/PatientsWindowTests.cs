using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_01.Tests
{
    public class PatientsWindowTests
    {
        [Fact]
        public void Create_ValidData_AddsPatientToDatabase()
        {
            var patientsWindow = new PatientsWindow();
            patientsWindow.FirstNameTextBox.Text = "John";
            patientsWindow.LastNameTextBox.Text = "Doe";
            patientsWindow.AddressTextBox.Text = "123 Main St";
            patientsWindow.NICTextBox.Text = "123456789";
            patientsWindow.DOBTextBox.Text = "1990-01-01";
            patientsWindow.DoctorTextBox.Text = "Dr. Smith";
            patientsWindow.AgeTextBox.Text = "30";
            patientsWindow.GenderTextBox.Text = "Male";
            patientsWindow.Create();
            patientsWindow.Read();
           Assert.Contains(patientsWindow.DatabaseData, p => p.First_Name == "John");
        }

        [Fact]
        public void Update_ValidData_UpdatesPatientInDatabase()
        {
            var patientsWindow = new PatientsWindow();
            patientsWindow.ItemList1.SelectedItem = new Patient { Patient_Id = 1, First_Name = "John" };
            patientsWindow.FirstNameTextBox.Text = "Jane";
            patientsWindow.LastNameTextBox.Text = "Smith";
            patientsWindow.AddressTextBox.Text = "456 Oak Ave";
            patientsWindow.NICTextBox.Text = "987654321";
            patientsWindow.DOBTextBox.Text = "1992-05-10";
            patientsWindow.DoctorTextBox.Text = "Dr. Johnson";
            patientsWindow.AgeTextBox.Text = "29";
            patientsWindow.GenderTextBox.Text = "Female";
            patientsWindow.Update();
            patientsWindow.Read();
            Assert.Contains(patientsWindow.DatabaseData, p => p.First_Name == "Jane");
        }

        [Fact]
        public void Delete_SelectedItem_RemovesPatientFromDatabase()
        {
            var patientsWindow = new PatientsWindow();
            var patientToDelete = new Patient { Patient_Id = 1, First_Name = "John" };
            patientsWindow.ItemList1.SelectedItem = patientToDelete;
            patientsWindow.Delete();
            patientsWindow.Read();
            Assert.DoesNotContain(patientsWindow.DatabaseData, p => p.Patient_Id == patientToDelete.Patient_Id);
        }
    }
}
