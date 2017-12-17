using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        private int id;
        private string firstname;
        private string lastname;
        private DateTime birthday;
        private string gender;
        private string email;
        private string password;
        private string salt;
        private bool admin;
        public int Id { get { return this.id; } }
        public string FirstName { get { return this.firstname; } }
        public string LastName { get { return this.lastname; } }
        public DateTime Birthday { get { return this.birthday; } }
        public string Gender { get { return this.gender; } }
        public string Email { get { return this.email; } }
        public string Password { get { return this.password; } }
        public string Salt { get { return this.salt; } }
        public bool Admin { get { return this.admin; } }
        public Client(int id, string firstname, string lastname, DateTime birthday, string gender, string email)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.gender = gender;
            this.email = email;
        }
        public Client(int id, string firstname, string lastname, DateTime birthday, string gender, string email, string password, string salt, bool admin)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.gender = gender;
            this.email = email;
            this.password = password;
            this.salt = salt;
            this.admin = admin;
        }
    }
}
