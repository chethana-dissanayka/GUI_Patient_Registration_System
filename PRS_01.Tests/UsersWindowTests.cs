using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_01.Tests
{
    public class UsersWindowTests
    {
        [Fact]
        public void Create_ValidData_AddsUserToDatabase()
        {
            var usersWindow = new UsersWindow();
            usersWindow.NameTextBox.Text = "John";
            usersWindow.PasswordTextBox.Text = "password";
            usersWindow.Create();
            usersWindow.Read();
            Assert.Contains(usersWindow.DatabaseData, u => u.User_Name == "John");
        }

        [Fact]
        public void Update_ValidData_UpdatesUserInDatabase()
        {
            var usersWindow = new UsersWindow();
            usersWindow.ItemList.SelectedItem = new User { User_Id = 1, User_Name = "John" };
            usersWindow.NameTextBox.Text = "Jane";
            usersWindow.PasswordTextBox.Text = "newpassword";
            usersWindow.Update();
            usersWindow.Read();
            Assert.Contains(usersWindow.DatabaseData, u => u.User_Name == "Jane");
        }

        [Fact]
        public void Delete_SelectedItem_RemovesUserFromDatabase()
        {
            var usersWindow = new UsersWindow();
            var userToDelete = new User { User_Id = 1, User_Name = "John" };
            usersWindow.ItemList.SelectedItem = userToDelete;
            usersWindow.Delete();
            usersWindow.Read();
            Assert.DoesNotContain(usersWindow.DatabaseData, u => u.User_Id == userToDelete.User_Id);
        }
    }
}
