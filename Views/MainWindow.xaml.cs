using StaemDatabaseApp.Controllers;
using StaemDatabaseApp.DataBaseConnection;
using StaemDatabaseApp.Model;
using StaemDatabaseApp.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = StaemDatabaseApp.Model.Color;
using Size = StaemDatabaseApp.Model.Size;

namespace StaemDatabaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showUsersButton_Click(object sender, RoutedEventArgs e)
        {
            usersDataGrid.ItemsSource = UserController.RetrieveAllUsers();
        }

        private void showProductsButton_Click(object sender, RoutedEventArgs e)
        {
            productsDataGrid.ItemsSource = ProductController.RetrieveAllProducts();
        }

        private void showCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            categoriesDataGrid.ItemsSource = CategoryController.RetrieveAllCategories();
        }

        private void showColorsButton_Click(object sender, RoutedEventArgs e)
        {
            colorsDataGrid.ItemsSource = ColorController.RetrieveAllColors();
        }

        private void showSizesButton_Click(object sender, RoutedEventArgs e)
        {
            sizesDataGrid.ItemsSource = SizeController.RetrieveAllSizes();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            Window addUserWindow = new AddUserWindow();
            addUserWindow.Owner = this;
            addUserWindow.ShowDialog();
            usersDataGrid.Items.Refresh();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddProductWindow = new AddProductWindow();
            AddProductWindow.Owner = this;
            AddProductWindow.ShowDialog();
            usersDataGrid.Items.Refresh();
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddCategoryWindow = new AddCategoryWindow();
            AddCategoryWindow.Owner = this;
            AddCategoryWindow.ShowDialog();
            usersDataGrid.Items.Refresh();
        }

        private void addColorButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddColorWindow = new AddColorWindow();
            AddColorWindow.Owner = this;
            AddColorWindow.ShowDialog();
            usersDataGrid.Items.Refresh();
        }

        private void addSizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddSizeWindow = new AddSizeWindow();
            AddSizeWindow.Owner = this;
            AddSizeWindow.ShowDialog();
            sizesDataGrid.Items.Refresh();
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            User user = (User)usersDataGrid.SelectedItem;

            if (user == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select user first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + user.Id + "\n");
            sb.Append("Login: " + user.Login + "\n");
            sb.Append("Password: " + user.Password + "\n");
            sb.Append("Admin: " + user.Admin + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = UserController.RemoveUser(user.Id);
                if (deleted)
                {
                    MessageBox.Show("User was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void removeProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Product product = (Product)productsDataGrid.SelectedItem;

            if (product == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select product first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + product.Id + "\n");
            sb.Append("Title: " + product.Title + "\n");
            sb.Append("Description: " + product.Description + "\n");
            sb.Append("Cena netto: " + product.CenaNetto + "\n");
            sb.Append("Cena brutto: " + product.CenaBrutto + "\n");
            sb.Append("Amount: " + product.Amount + "\n");
            sb.Append("Active: " + product.Active + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = ProductController.RemoveProduct(product.Id);
                if (deleted)
                {
                    MessageBox.Show("Product was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void removeCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Category category = (Category)categoriesDataGrid.SelectedItem;

            if (category == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select product first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + category.Id + "\n");
            sb.Append("Title: " + category.Title + "\n");
            sb.Append("Description: " + category.Description + "\n");
            sb.Append("Active: " + category.Active + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = CategoryController.RemoveCategory(category.Id);
                if (deleted)
                {
                    MessageBox.Show("Category was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void removeColorButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Color color = (Color)colorsDataGrid.SelectedItem;

            if (color == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select color first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + color.Id + "\n");
            sb.Append("Title: " + color.Title + "\n");
            sb.Append("Description: " + color.Description + "\n");
            sb.Append("Active: " + color.Active + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = ColorController.RemoveColor(color.Id);
                if (deleted)
                {
                    MessageBox.Show("Category was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void removeSizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Size size_ = (Size)colorsDataGrid.SelectedItem;

            if (size_ == null)
            { // Typ wiadomosci i ikonka?
                MessageBox.Show("Select color first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("This action will delete following customer from database!\n");
            sb.Append("ID: " + size_.Id + "\n");
            sb.Append("Title: " + size_.Size_ + "\n");
            sb.Append("Active: " + size_.Active + "\n");
            sb.Append("\nThis action may not be reversable. Do you want to continue?");

            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = SizeController.RemoveSize(size_.Id);
                if (deleted)
                {
                    MessageBox.Show("Size was removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //customersDataGrid.Items.Remove(customersDataGrid.SelectedItem);
                }
                else
                {
                    MessageBox.Show("An error occuried during this action.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            User user = (User)usersDataGrid.SelectedItem;

            if (user == null)
            { 
                MessageBox.Show("Select user first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editUserWindow = new EditUserWindow(user);
            editUserWindow.Owner = this;
            editUserWindow.ShowDialog();
            usersDataGrid.Items.Refresh();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Product product = (Product)productsDataGrid.SelectedItem;

            if (product == null)
            {
                MessageBox.Show("Select product first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editProductWindow = new EditProductWindow(product);
            editProductWindow.Owner = this;
            editProductWindow.ShowDialog();
            productsDataGrid.Items.Refresh();
        }

        private void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Category category = (Category)categoriesDataGrid.SelectedItem;

            if (category == null)
            {
                MessageBox.Show("Select category first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editCategoryWindow = new EditCategoryWindow(category);
            editCategoryWindow.Owner = this;
            editCategoryWindow.ShowDialog();
            categoriesDataGrid.Items.Refresh();
        }

        private void EditColorButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Color color = (Color)colorsDataGrid.SelectedItem;

            if (color == null)
            {
                MessageBox.Show("Select color first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editColorWindow = new EditColorWindow(color);
            editColorWindow.Owner = this;
            editColorWindow.ShowDialog();
            colorsDataGrid.Items.Refresh();
        }

        private void EditSizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected index from grid

            Size size_ = (Size)sizesDataGrid.SelectedItem;

            if (size_ == null)
            {
                MessageBox.Show("Select size first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Window editSizeWindow = new EditSizeWindow(size_);
            editSizeWindow.Owner = this;
            editSizeWindow.ShowDialog();
            colorsDataGrid.Items.Refresh();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            switch (tabItem)
            {
                case "Users":
                    usersDataGrid.ItemsSource = UserController.RetrieveAllUsers();
                    break;

                case "Products":
                    productsDataGrid.ItemsSource = ProductController.RetrieveAllProducts();
                    break;

                case "Categories":
                    categoriesDataGrid.ItemsSource = CategoryController.RetrieveAllCategories();
                    break;

                case "Colors":
                    colorsDataGrid.ItemsSource = ColorController.RetrieveAllColors();
                    break;

                case "Sizes":
                    sizesDataGrid.ItemsSource = SizeController.RetrieveAllSizes();
                    break;

                default:
                    usersDataGrid.ItemsSource = UserController.RetrieveAllUsers();
                    return;
            }

        }
    }
}
