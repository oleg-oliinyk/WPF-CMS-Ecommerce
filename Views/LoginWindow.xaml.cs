using StaemDatabaseApp.Controllers;
using StaemDatabaseApp.DataBaseConnection;
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

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DbConnection.EstablishConnection();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            if (UserController.LogIn(login, password, 1))
            {
                Window mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
