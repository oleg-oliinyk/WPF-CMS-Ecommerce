using WPF_CMS_Ecommerce.Controllers;
using WPF_CMS_Ecommerce.DataBaseConnection;
using System.Windows;

namespace WPF_CMS_Ecommerce.Views
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
