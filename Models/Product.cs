using WPF_CMS_Ecommerce.Controllers;
using System;

namespace WPF_CMS_Ecommerce.Model
{
    public class Product
    {
        public Product(string id, string category_id, string title, string description, string photo, string cena_netto, string cena_brutto, string amount, string color_id, string active, string size_id)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;

            Title = title;
            Description = description;
            Photo = photo;

            double cena_netto_;
            Double.TryParse(cena_netto, out cena_netto_);
            CenaNetto = cena_netto_;

            double cena_brutto_;
            Double.TryParse(cena_brutto, out cena_brutto_);
            CenaBrutto = cena_brutto_;

            int amount_;
            Int32.TryParse(amount, out amount_);
            Amount = amount_;

            int active_;
            Int32.TryParse(active, out active_);
            Active = active_;

            int categoryID;
            Int32.TryParse(category_id, out categoryID);
            Category = CategoryController.RetrieveCategoryByID(categoryID);

            int colorID;
            Int32.TryParse(color_id, out colorID);
            Color = ColorController.RetrieveColorByID(colorID);

            int sizeID;
            Int32.TryParse(size_id, out sizeID);
            Size = SizeController.RetrieveSizeByID(sizeID);
        }

        public Product(int id, int category_id, string title, string description, string photo, double cena_netto, double cena_brutto, int amount, int color_id, int active, int size_id)
        {
            Id = id;
            Title = title;
            Description = description;
            Photo = photo;
            CenaNetto = cena_netto;
            CenaBrutto = cena_brutto;
            Amount = amount;
            Active = active;
            Category = category;
            Color = color;
            Size = size;
        }

        private int id;
        private string title;
        private string description;
        private string photo;
        private double cena_netto;
        private double cena_brutto;
        private int amount;
        private int active;
        private Category category;
        private Color color;
        private Size size;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
        public double CenaNetto { get => cena_netto; set => cena_netto = value; }
        public double CenaBrutto { get => cena_brutto; set => cena_brutto = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Active { get => active; set => active = value; }

        internal Category Category { get => category; set => category = value; }
        internal Color Color { get => color; set => color = value; }
        internal Size Size { get => size; set => size = value; }

        public override string ToString()
        {
            return Title +"  : " + Id.ToString();
        }
    }
}
