using StaemDatabaseApp.Controllers;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class AddSizeWindow : Window
    {
        public AddSizeWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                sizeTextBox.Text.Length == 0 &&
                activeTextBox.Text.Length == 0
                )
            {
                MessageBox.Show("Fields cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool answer = SizeController.AddSize(
                sizeTextBox.Text,
                activeTextBox.Text
                );
            if (answer)
            {
                MessageBox.Show("Size was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
