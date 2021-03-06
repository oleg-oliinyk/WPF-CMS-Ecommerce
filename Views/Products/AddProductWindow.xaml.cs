using WPF_CMS_Ecommerce.Controllers;
using WPF_CMS_Ecommerce.Model;
using System;
using System.Windows;
using Color = WPF_CMS_Ecommerce.Model.Color;
using Size = WPF_CMS_Ecommerce.Model.Size;

namespace WPF_CMS_Ecommerce.Views
{
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();

            categoryComboBox.ItemsSource = CategoryController.RetrieveAllCategories();
            categoryComboBox.SelectedIndex = 0;

            colorComboBox.ItemsSource = ColorController.RetrieveAllColors();
            colorComboBox.SelectedIndex = 0;

            sizeComboBox.ItemsSource = SizeController.RetrieveAllSizes();
            sizeComboBox.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
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
            string category_id = category.Id.ToString();

            Color color = (Color)colorComboBox.SelectedItem;
            string color_id = color.Id.ToString();

            Size size = (Size)sizeComboBox.SelectedItem;
            string size_id = size.Id.ToString();

            bool answer = ProductController.AddProduct(
                category.Id,
                color.Id,
                size.Id,
                titleTextBox.Text,
                descriptionTextBox.Text,
                cena_netto,
                cena_brutto,
                amountTextBox.Text,
                activeTextBox.Text
                );
            if (answer)
            {
                MessageBox.Show("Product was added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
