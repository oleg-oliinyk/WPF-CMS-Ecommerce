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
    public partial class EditProductWindow : Window
    {
        private Product product;
        public EditProductWindow(Product product)
        {
            InitializeComponent();

            this.product = product;

            titleTextBox.Text = product.Title;
            descriptionTextBox.Text = product.Description;
            cenaNettoTextBox.Text = product.CenaNetto.ToString();
            cenaBruttoTextBox.Text = product.CenaBrutto.ToString();
            amountTextBox.Text = product.Amount.ToString();
            activeTextBox.Text = product.Active.ToString();

            //categoryComboBox.ItemsSource = DevelopersDA.RetrieveAllDevelopers();
            //for (int i = 0; i < developerComboBox.Items.Count; i++)
            //{
            //    if (((Developer)developerComboBox.Items.GetItemAt(i)).Id == game.Developer.Id)
            //    {
            //        developerComboBox.SelectedIndex = i;
            //        break;
            //    }
            //}

            //colorComboBox.ItemsSource = DevelopersDA.RetrieveAllDevelopers();
            //for (int i = 0; i < developerComboBox.Items.Count; i++)
            //{
            //    if (((Developer)developerComboBox.Items.GetItemAt(i)).Id == game.Developer.Id)
            //    {
            //        developerComboBox.SelectedIndex = i;
            //        break;
            //    }
            //}

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

            if (
                cenaNettoTextBox.Text.Length == 0 &&
                cenaBruttoTextBox.Text.Length == 0
            )
            {
                MessageBox.Show("netto and brutto cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (
                amountTextBox.Text.Length == 0
            )
            {
                MessageBox.Show("amount cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //if (
            //categoryComboBox.Text.Length == 0 &&
            //colorComboBox.Text.Length == 0
            //)
            //{
            //    MessageBox.Show("Please select category and color", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            double cena_netto, cena_brutto;
            try
            {
                cena_netto = Double.Parse(cenaNettoTextBox.Text);
                cena_brutto = Double.Parse(cenaBruttoTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while converting cena netto and brutto.\nTry again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            bool answer = ProductController.EditProduct(
                titleTextBox.Text, 
                descriptionTextBox.Text,
                cena_netto,
                cena_brutto,
                amountTextBox.Text,
                categoryComboBox.Text,
                colorComboBox.Text, 
                product.Id);
            if (answer)
            {
                MessageBox.Show("Product was edited successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
