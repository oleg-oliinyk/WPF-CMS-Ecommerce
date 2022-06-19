using WPF_CMS_Ecommerce.Controllers;
using System.Windows;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class AddColorWindow : Window
    {
        public AddColorWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                titleTextBox.Text.Length == 0 &&
                descriptionTextBox.Text.Length == 0 &&
                activeTextBox.Text.Length == 0
                )
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool answer = ColorController.AddColor(
                titleTextBox.Text,
                descriptionTextBox.Text,
                activeTextBox.Text
                );
            if (answer)
            {
                MessageBox.Show("Color was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
