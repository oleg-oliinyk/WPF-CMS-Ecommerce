using WPF_CMS_Ecommerce.Controllers;
using System.Windows;
using Size = WPF_CMS_Ecommerce.Model.Size;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class EditSizeWindow : Window
    {
        private Size size;
        public EditSizeWindow(Size size)
        {
            InitializeComponent();

            this.size = size;

            sizeTextBox.Text = size.Name;
            activeTextBox.Text = size.Active.ToString();

        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                sizeTextBox.Text.Length == 0
                )
            {
                MessageBox.Show("title and description cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            bool answer = SizeController.EditSize(
                sizeTextBox.Text, 
                activeTextBox.Text, 
                size.Id);
            if (answer)
            {
                MessageBox.Show("Color was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
