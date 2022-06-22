using System;

namespace WPF_CMS_Ecommerce.Model
{
    public class User
    {
        public User(string id, string login, string password, string name, string surname, string country, string city, string email, string admin)
        {
            int id_;
            Int32.TryParse(id, out id_);
            Id = id_;
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            Country = country;
            City = city;
            Email = email;
            int admin_;
            Int32.TryParse(admin, out admin_);
            Admin = admin_;
        }

        private int id;
        private string login;
        private string password;
        private string name;
        private string surname;
        private string country;
        private string city;
        private string email;
        private int admin;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public int Admin { get => admin; set => admin = value; }

        public override string ToString()
        {
            return Login +"  : " + Id.ToString();
        }
    }
}
