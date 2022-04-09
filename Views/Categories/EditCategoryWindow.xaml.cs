using StaemDatabaseApp.Controllers;
using StaemDatabaseApp.DataBaseConnection;
using StaemDatabaseApp.Model;
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

namespace StaemDatabaseApp.Views
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
