using WPF_CMS_Ecommerce.Controllers;
using System.Windows;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
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
                MessageBox.Show("title and description cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool answer = CategoryController.AddCategory(
                titleTextBox.Text,
                descriptionTextBox.Text,
                activeTextBox.Text
                );
            if (answer)
            {
                MessageBox.Show("Category was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
