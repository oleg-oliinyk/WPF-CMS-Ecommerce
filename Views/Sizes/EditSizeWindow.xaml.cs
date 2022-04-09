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
using Size = StaemDatabaseApp.Model.Size;

namespace StaemDatabaseApp.Views
{
    public partial class EditSizeWindow : Window
    {
        private Size size;
        public EditSizeWindow(Size size)
        {
            InitializeComponent();

            this.size = size;

            sizeTextBox.Text = size.Size_;
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
