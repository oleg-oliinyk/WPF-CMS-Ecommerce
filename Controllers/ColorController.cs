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
    public static class ColorController
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Color> RetrieveAllColors()
        {
            string query = "SELECT * FROM wpf_shop.colors;";
            cmd = DbConnection.RunQueryNoParameters(query);
            List<Color> allColors = new List<Color>();
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
                    allColors.Add(new Color(id, title, description, active));
                }
            }
            return allColors;
        }

        public static Color RetrieveColorByID(int userID)
        {
            string query = "SELECT * FROM wpf_shop.colors WHERE ID = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, userID);
            Color color = null;
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
                    color = new Color(id, title, description, active);
                }
            }
            return color;
        }

        public static bool AddColor(
            string title,
            string description,
            string active
            )
        {
            string query = "INSERT INTO wpf_shop.colors " +
                "(title, description, active)" +
                " VALUES (@Color_title, @Color_description, @Color_active);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Color_title", title);
            parameters.Add("@Color_description", description);
            parameters.Add("@Color_active", active);
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool RemoveColor(int id)
        {
            string query = "DELETE FROM wpf_shop.colors WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool EditColor(
            string title, 
            string description, 
            string active,
            int id
            )
        {
            string query = "UPDATE wpf_shop.colors SET " +
                "title=@Color_title, " +
                "description=@Color_description, " +
                "active=@Color_active WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Color_title", title);
            parameters.Add("@Color_description", description);
            parameters.Add("@Color_active", active);
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }
    }
}
