using WPF_CMS_Ecommerce.Controllers;
using System.Windows;
using Color = WPF_CMS_Ecommerce.Model.Color;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class EditColorWindow : Window
    {
        private Color color;
        public EditColorWindow(Color color)
        {
            InitializeComponent();

            this.color = color;

            titleTextBox.Text = color.Title;
            descriptionTextBox.Text = color.Description;
            activeTextBox.Text = color.Active.ToString();

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


            bool answer = ColorController.EditColor(
                titleTextBox.Text, 
                descriptionTextBox.Text,
                activeTextBox.Text, 
                color.Id);
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
