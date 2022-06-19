using WPF_CMS_Ecommerce.Controllers;
using WPF_CMS_Ecommerce.Model;
using System.Windows;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class EditCategoryWindow : Window
    {
        private Category category;
        public EditCategoryWindow(Category category)
        {
            InitializeComponent();

            this.category = category;

            titleTextBox.Text = category.Title;
            descriptionTextBox.Text = category.Description;

            activeTextBox.Text = category.Active.ToString();

        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                titleTextBox.Text.Length == 0 &&
                descriptionTextBox.Text.Length == 0
                )
            {
                MessageBox.Show("title and description cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            bool answer = CategoryController.EditCategory(
                titleTextBox.Text, 
                descriptionTextBox.Text,
                activeTextBox.Text, 
                category.Id);
            if (answer)
            {
                MessageBox.Show("Category was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
