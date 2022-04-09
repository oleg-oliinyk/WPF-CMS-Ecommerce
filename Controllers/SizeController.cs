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
using Size = StaemDatabaseApp.Model.Size;

namespace StaemDatabaseApp.Controllers
{
    public static class SizeController
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Size> RetrieveAllSizes()
        {
            string query = "SELECT * FROM wpf_shop.size;";
            cmd = DbConnection.RunQueryNoParameters(query);
            List<Size> allSize = new List<Size>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string size = dr["size"].ToString();
                    string active = dr["active"].ToString();
                    allSize.Add(new Size(id, size, active));
                }
            }
            return allSize;
        }

        public static Size RetrieveSizeByID(int sizeID)
        {
            string query = "SELECT * FROM wpf_shop.size WHERE ID = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, sizeID);
            Size size = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string sizeName = dr["size"].ToString();
                    string active = dr["active"].ToString();
                    size = new Size(id, sizeName, active);
                }
            }
            return size;
        }

        public static bool AddSize(
            string size,
            string active
            )
        {
            string query = "INSERT INTO wpf_shop.size " +
                "(size, active)" +
                " VALUES (@Size_size, @Size_active);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Size_size", size);
            parameters.Add("@Size_active", active);
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool RemoveSize(int id)
        {
            string query = "DELETE FROM wpf_shop.size WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool EditSize(
            string size, 
            string active,
            int id
            )
        {
            string query = "UPDATE wpf_shop.size SET " +
                "size=@Size_size, " +
                "active=@Size_active WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Size_size", size);
            parameters.Add("@Size_active", active);
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }
    }
}
