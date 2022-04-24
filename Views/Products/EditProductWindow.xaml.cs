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
using Size = StaemDatabaseApp.Model.Size;

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

            categoryComboBox.ItemsSource = CategoryController.RetrieveAllCategories();
            for (int i = 0; i < categoryComboBox.Items.Count; i++)
            {
                if (((Category)categoryComboBox.Items.GetItemAt(i)).Id == product.Category.Id)
                {
                    categoryComboBox.SelectedIndex = i;
                    break;
                }
            }

            colorComboBox.ItemsSource = ColorController.RetrieveAllColors();
            for (int i = 0; i < colorComboBox.Items.Count; i++)
            {
                if (((Color)colorComboBox.Items.GetItemAt(i)).Id == product.Color.Id)
                {
                    colorComboBox.SelectedIndex = i;
                    break;
                }
            }

            sizeComboBox.ItemsSource = SizeController.RetrieveAllSizes();
            for (int i = 0; i < sizeComboBox.Items.Count; i++)
            {
                if (((Size)sizeComboBox.Items.GetItemAt(i)).Id == product.Size.Id)
                {
                    sizeComboBox.SelectedIndex = i;
                    break;
                }
            }

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

            Category category = (Category)categoryComboBox.SelectedItem;
            Color color = (Color)colorComboBox.SelectedItem;
            Size size = (Size)sizeComboBox.SelectedItem;

            bool answer = ProductController.EditProduct(
                category.Id,
                color.Id,
                size.Id,
                titleTextBox.Text, 
                descriptionTextBox.Text,
                cena_netto,
                cena_brutto,
                amountTextBox.Text,
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
