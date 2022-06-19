using WPF_CMS_Ecommerce.Controllers;
using System.Windows;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                loginTextBox.Text.Length == 0 &&
                passwordTextBox.Text.Length == 0
                )
            {
                MessageBox.Show("login and password cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }else if (
                nameTextBox.Text.Length == 0 &&
                surnameTextBox.Text.Length == 0
            )
            {
                MessageBox.Show("name and surname cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (
                countryTextBox.Text.Length == 0 &&
                cityTextBox.Text.Length == 0
            )
            {
                MessageBox.Show("country and city cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (
            emailTextBox.Text.Length == 0 &&
            adminTextBox.Text.Length == 0
            )
            {
                MessageBox.Show("email and admin cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool answer = UserController.AddUser(
                loginTextBox.Text,
                passwordTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                countryTextBox.Text,
                cityTextBox.Text,
                emailTextBox.Text,
                adminTextBox.Text
                );
            if (answer)
            {
                MessageBox.Show("User was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
