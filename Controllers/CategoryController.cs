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
    public static class CategoryController
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Category> RetrieveAllCategories()
        {
            string query = "SELECT * FROM wpf_shop.categories;";
            cmd = DbConnection.RunQueryNoParameters(query);
            List<Category> allCategories = new List<Category>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string title = dr["title"].ToString();
                    string description = dr["description"].ToString();
                    string active = dr["active"].ToString();
                    allCategories.Add(new Category(id, title, description, active));
                }
            }
            return allCategories;
        }

        public static Category RetrieveCategoryByID(int catID)
        {
            string query = "SELECT * FROM wpf_shop.categories WHERE ID = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, catID);
            Category category = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string title = dr["title"].ToString();
                    string description = dr["description"].ToString();
                    string active = dr["active"].ToString();
                    category = new Category(id, title, description, active);
                }
            }
            return category;
        }

        public static bool AddCategory(
            string title,
            string description,
            string active
            )
        {
            string query = "INSERT INTO wpf_shop.categories " +
                "(title, description, active)" +
                " VALUES (@Category_title, @Category_description, @Category_active);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Category_title", title);
            parameters.Add("@Category_description", description);
            parameters.Add("@Category_active", active);
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool RemoveCategory(int id)
        {
            string query = "DELETE FROM wpf_shop.categories WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool EditCategory(
            string title, 
            string description, 
            string active,
            int id
            )
        {
            string query = "UPDATE wpf_shop.categories SET " +
                "title=@Category_title, " +
                "description=@Category_description, " +
                "active=@Category_active WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Category_title", title);
            parameters.Add("@Category_description", description);
            parameters.Add("@Category_active", active);
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }
    }
}
