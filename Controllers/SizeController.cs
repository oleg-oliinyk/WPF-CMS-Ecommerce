using MySql.Data.MySqlClient;
using WPF_CMS_Ecommerce.DataBaseConnection;
using System.Collections.Generic;
using System.Data;
using Size = WPF_CMS_Ecommerce.Model.Size;

namespace WPF_CMS_Ecommerce.Controllers
{
    public class SizeController
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
                    string name = dr["name"].ToString();
                    string active = dr["active"].ToString();
                    allSize.Add(new Size(id, name, active));
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
                    string name = dr["name"].ToString();
                    string active = dr["active"].ToString();
                    size = new Size(id, name, active);
                }
            }
            return size;
        }

        public static string RetrieveProduct2sizeByID(int product_id)
        {
            string query = "SELECT * FROM wpf_shop.product2size WHERE product_id = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, product_id);
            string size_id = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    size_id = dr["size_id"].ToString();
                }
            }
            return size_id;
        }

        public static bool AddSize(
            string name,
            string active
            )
        {
            string query = "INSERT INTO wpf_shop.size " +
                "(name, active)" +
                " VALUES (@Size_name, @Size_active);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Size_name", name);
            parameters.Add("@Size_active", active);
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool EditSize(
            string size, 
            string active,
            int id
            )
        {
            string query = "UPDATE wpf_shop.size SET " +
                "name=@Size_name, " +
                "active=@Size_active WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Size_name", size);
            parameters.Add("@Size_active", active);
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

        public static bool RemoveSize(int id)
        {
            string query = "DELETE FROM wpf_shop.size WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool InsertProduct2Size(
            int product_id,
            int size_id,
            int amount
        )
        {
            string query = "INSERT INTO wpf_shop.product2size " +
                "(product_id, size_id, amount)" +
                " VALUES (@product_id, @size_id, @amount);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@product_id", product_id.ToString());
            parameters.Add("@size_id", size_id.ToString());
            parameters.Add("@amount", amount.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }
        public static bool UpdateProduct2Size(
            int product_id,
            int size_id,
            int amount
        )
        {
            string query = "UPDATE wpf_shop.product2size SET " +
                "size_id=@size_id, amount=@amount WHERE product_id=@product_id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@size_id", size_id.ToString());
            parameters.Add("@amount", amount.ToString());
            parameters.Add("@product_id", product_id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);

            return cmd != null;
        }

    }
}
