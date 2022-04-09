using StaemDatabaseApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Product
    {
        public Product(string id, string category_id, string title, string description, string photo, string cena_netto, string cena_brutto, string amount, string color_id, string active)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;

            //int category_id_;
            //Int32.TryParse(category_id, out category_id_);
            //CategoryId = category_id;

            Title = title;
            Description = description;
            Photo = photo;

            double cena_netto_;
            Double.TryParse(cena_netto, out cena_netto_);
            CenaNetto = cena_netto_;

            double cena_brutto_;
            Double.TryParse(cena_brutto, out cena_brutto_);
            CenaNetto = cena_brutto_;

            Amount = amount;

            //int color_id_;
            //Int32.TryParse(color_id, out color_id_);
            //ColorId = color_id_;

            int active_;
            Int32.TryParse(active, out active_);
            Active = active_;
        }

        public Product(int id, int category_id, string title, string description, string photo, double cena_netto, double cena_brutto, int amounrt, int active)
        {
            Id = id;
            //CategoryId = category_id;
            Title = title;
            Description = description;
            Photo = photo;
            CenaNetto = cena_netto;
            CenaBrutto = cena_brutto;
            Amount = amount;
            //ColorId = color_id;
            Active = active;
        }

        private int id;
        //private int category_id;
        private string title;
        private string description;
        private string photo;
        private double cena_netto;
        private double cena_brutto;
        private string amount;
        //private string color_id;
        private int active;

        public int Id { get => id; set => id = value; }
        //public string CategoryId { get => category_id; set => category_id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
        public double CenaNetto { get => cena_netto; set => cena_netto = value; }
        public double CenaBrutto { get => cena_brutto; set => cena_brutto = value; }
        public string Amount { get => amount; set => amount = value; }
        //public string ColorId { get => color_id; set => color_id = value; }
        public int Active { get => active; set => active = value; }

        public override string ToString()
        {
            return Title +"  : " + Id.ToString();
        }
    }
}
