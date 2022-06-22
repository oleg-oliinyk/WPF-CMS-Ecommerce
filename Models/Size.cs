using System;

namespace WPF_CMS_Ecommerce.Model
{
    public class Size
    {
        public Size(string id, string name, string active)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;

            Name = name;

            int active_;
            Int32.TryParse(active, out active_);
            Active = active_;
        }

        private int id;
        private int active;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get; set; }
        public int Active { get => active; set => active = value; }

        public override string ToString()
        {
            return Name + "  : " + Id.ToString();
        }
    }
}
