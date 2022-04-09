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
using Color = StaemDatabaseApp.Model.Color;

namespace StaemDatabaseApp.Views
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
