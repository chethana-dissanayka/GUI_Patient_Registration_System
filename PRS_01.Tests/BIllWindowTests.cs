using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PRS_01.Tests;
using PRS_01;

namespace PRS_01.Tests
{
    public class BIllWindowTests
    {
        [Fact]
        public void Create_ValidData_AddsBillToDatabase()
        {
            var billWindow = new BillWindow();
            billWindow.NameTextBox.Text = "John Doe";
            billWindow.AdateTextBox.Text = "2023-07-16";
            billWindow.DdateTextBox.Text = "2023-07-20";
            billWindow.No_DaysTextBox.Text = "4";
            billWindow.ServiceTextBox.Text = "10";
            billWindow.DocChargeTextBox.Text = "5";
            billWindow.Create();
            billWindow.Read();
            Assert.Contains(billWindow.DatabaseData, b => b.Name == "John Doe");
        }

        [Fact]
        public void Update_ValidData_UpdatesBillInDatabase()
        {
            var billWindow = new BillWindow();
            billWindow.ItemList2.SelectedItem = new Bill { Id = 1, Name = "John Doe" };
            billWindow.NameTextBox.Text = "Jane Smith";
            billWindow.AdateTextBox.Text = "2023-07-16";
            billWindow.DdateTextBox.Text = "2023-07-20";
            billWindow.No_DaysTextBox.Text = "4";
            billWindow.ServiceTextBox.Text = "10";
            billWindow.DocChargeTextBox.Text = "5";
            billWindow.Update();
            billWindow.Read();
            Assert.Contains(billWindow.DatabaseData, b => b.Name == "Jane Smith");
        }

        [Fact]
        public void Delete_SelectedItem_RemovesBillFromDatabase()
        {
            var billWindow = new BillWindow();
            var billToDelete = new Bill { Id = 1, Name = "John Doe" };
            billWindow.ItemList2.SelectedItem = billToDelete;
            billWindow.Delete();
            billWindow.Read();
            Assert.DoesNotContain(billWindow.DatabaseData, b => b.Id == billToDelete.Id);
        }
    }
}
    