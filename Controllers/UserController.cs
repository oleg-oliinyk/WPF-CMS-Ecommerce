using MySql.Data.MySqlClient;
using StaemDatabaseApp.DataBaseConnection;
using StaemDatabaseApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaemDatabaseApp.Controllers
{
    public static class UserController
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<User> RetrieveAllUsers()
        {
            string query = "SELECT * FROM wpf_shop.users;";
            cmd = DbConnection.RunQueryNoParameters(query);
            List<User> allUsers = new List<User>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string login = dr["login"].ToString();
                    string password = dr["password"].ToString();
                    string name = dr["name"].ToString();
                    string surname = dr["surname"].ToString();
                    string country = dr["country"].ToString();
                    string city = dr["city"].ToString();
                    string email = dr["email"].ToString();
                    string admin = dr["admin"].ToString();
                    allUsers.Add(new User(id, login, password, name, surname, country, city, email, admin));
                }
            }
            return allUsers;
        }

        public static User RetrieveUserByID(int userID)
        {
            string query = "SELECT * FROM wpf_shop.users WHERE ID = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, userID);
            User user = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string login = dr["login"].ToString();
                    string password = dr["password"].ToString();
                    string name = dr["name"].ToString();
                    string surname = dr["surname"].ToString();
                    string country = dr["country"].ToString();
                    string city = dr["city"].ToString();
                    string email = dr["email"].ToString();
                    string admin = dr["admin"].ToString();
                    user = new User(id, login, password, name, surname, country, city, email, admin);
                }
            }
            return user;
        }

        public static bool LogIn(string login, string password, int admin)
        {
            string query = "SELECT * FROM `wpf_shop`.`users` WHERE `login`='" + login + "' AND `password`='" + password + "' AND admin='" + admin.ToString() + "';";
            cmd = DbConnection.RunQueryNoParameters(query);
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);

                if (sda.Fill(dt) == 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            else return false;
        }

        public static bool AddUser(
            string login, 
            string password, 
            string name, 
            string surname, 
            string country, 
            string city, 
            string email, 
            string admin
            )
        {
            string query = "INSERT INTO wpf_shop.users (login, password, `name`, surname, country, city, email, admin)" +
                " VALUES (@User_login, @User_password, @User_name, @User_surname, @User_country, @User_city, @User_email, @User_admin);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@User_login", login);
            parameters.Add("@User_password", password);
            parameters.Add("@User_name", name);
            parameters.Add("@User_surname", surname);
            parameters.Add("@User_country", country);
            parameters.Add("@User_city", city);
            parameters.Add("@User_email", email);
            parameters.Add("@User_admin", admin.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool RemoveUser(int id)
        {
            string query = "DELETE FROM wpf_shop.users WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool EditUser(
            string login, 
            string password, 
            string name, 
            string surname, 
            string country, 
            string city,
            string email,
            string admin,
            int id
            )
        {
            string query = "UPDATE wpf_shop.users SET login=@User_login, password=@User_password, `name`=@User_name, surname=@User_surname, country=@User_country, city=@User_city, email=@User_email, admin=@User_admin WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@User_login", login);
            parameters.Add("@User_password", password);
            parameters.Add("@User_name", name);
            parameters.Add("@User_surname", surname);
            parameters.Add("@User_country", country);
            parameters.Add("@User_city", city);
            parameters.Add("@User_email", email);
            parameters.Add("@User_admin", admin.ToString());
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }
    }
}
