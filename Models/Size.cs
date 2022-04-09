using StaemDatabaseApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaemDatabaseApp.Model
{
    public class Size
    {
        public Size(string id, string size, string active)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;

            Size_ = size;

            int active_;
            Int32.TryParse(active, out active_);
            Active = active_;
        }

        public Size(int id, string size, int active)
        {
            Id = id;
            Size_ = size;
            Active = active;
        }

        private int id;
        private int active;
        private string size;

        public int Id { get => id; set => id = value; }
        public string Size_ { get; set; }
        public int Active { get => active; set => active = value; }

        public override string ToString()
        {
            return Size_ + "  : " + Id.ToString();
        }
    }
}
