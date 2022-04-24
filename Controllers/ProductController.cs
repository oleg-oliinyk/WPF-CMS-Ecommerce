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
    public class ProductController
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Product> RetrieveAllProducts()
        {
            string query = "SELECT * FROM wpf_shop.products;";
            cmd = DbConnection.RunQueryNoParameters(query);
            List<Product> allProducts = new List<Product>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string category_id = dr["category_id"].ToString();
                    string title = dr["title"].ToString();
                    string description = dr["description"].ToString();
                    string photo = dr["photo"].ToString();
                    string cena_netto = dr["cena_netto"].ToString();
                    string cena_brutto = dr["cena_brutto"].ToString();
                    string amount = dr["amount"].ToString();
                    string color_id = dr["color_id"].ToString();
                    string active = dr["active"].ToString();
                    int _id = Int32.Parse(id);
                    string size_id = SizeController.RetrieveProduct2sizeByID(_id);
                    allProducts.Add(new Product(id, category_id, title, description, photo, cena_netto, cena_brutto, amount, color_id, active, size_id));
                }
            }
            return allProducts;
        }

        public static Product RetrieveProductByID(int productID)
        {
            string query = "SELECT * FROM wpf_shop.products WHERE ID = (@ID) limit 1;";
            cmd = DbConnection.RunQueryWithID(query, productID);
            Product product = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["id"].ToString();
                    string category_id = dr["category_id"].ToString();
                    string title = dr["title"].ToString();
                    string description = dr["description"].ToString();
                    string photo = dr["photo"].ToString();
                    string cena_netto = dr["cena_netto"].ToString();
                    string cena_brutto = dr["cena_brutto"].ToString();
                    string amount = dr["amount"].ToString();
                    string color_id = dr["color_id"].ToString();
                    string active = dr["active"].ToString();
                    int _id = Int32.Parse(id);
                    string size_id = SizeController.RetrieveSizeByID(_id).ToString();
                    product = new Product(id, category_id, title, description, photo, cena_netto, cena_brutto, amount, color_id, active, size_id);
                }
            }
            return product;
        }

        public static bool AddProduct(
            int category_id,
            int color_id,
            int size_id,
            string title,
            string description,
            double cena_netto,
            double cena_brutto,
            string amount,
            string active
            )
        {
            string query = "INSERT INTO wpf_shop.products " +
                "(category_id, title, description, cena_netto, cena_brutto, amount, color_id, active)" +
                " VALUES (@Product_category, @Product_title, @Product_description, @Product_netto, @Product_brutto, @Product_amount, " +
                "@Product_color, @Product_active);";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Product_category", category_id.ToString());
            parameters.Add("@Product_color", color_id.ToString());
            parameters.Add("@Product_title", title);
            parameters.Add("@Product_description", description);
            parameters.Add("@Product_netto", cena_netto.ToString());
            parameters.Add("@Product_brutto", cena_brutto.ToString());
            parameters.Add("@Product_amount", amount);
            parameters.Add("@Product_active", active);
            cmd = DbConnection.RunQueryWithParamList(query, parameters);
            int product_id = (int)cmd.LastInsertedId;
            SizeController.InsertProduct2Size(product_id, size_id, Int32.Parse(amount));

            return cmd != null;
        }

        public static bool EditProduct(
            int category_id,
            int color_id,
            int size_id,
            string title, 
            string description, 
            double cena_netto,
            double cena_brutto, 
            string amount,
            int id
            )
        {
            string query = "UPDATE wpf_shop.products SET " +
                "category_id=@Product_category, color_id=@Product_color, title =@Product_title, description=@Product_description, " +
                "cena_netto=@Product_netto, cena_brutto=@Product_brutto, " +
                "amount=@Product_amount WHERE id=@Id;";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Product_category", category_id.ToString());
            parameters.Add("@Product_color", color_id.ToString());
            parameters.Add("@Product_title", title);
            parameters.Add("@Product_description", description);
            parameters.Add("@Product_netto", cena_netto.ToString());
            parameters.Add("@Product_brutto", cena_brutto.ToString());
            parameters.Add("@Product_amount", amount);
            parameters.Add("@Id", id.ToString());
            cmd = DbConnection.RunQueryWithParamList(query, parameters);
            SizeController.UpdateProduct2Size(id, size_id, Int32.Parse(amount));

            return cmd != null;
        }
        public static bool RemoveProduct(int id)
        {
            string query = "DELETE FROM wpf_shop.products WHERE ID = (@ID);";
            cmd = DbConnection.RunQueryWithID(query, id);
            return cmd != null;
        }

    }
}
