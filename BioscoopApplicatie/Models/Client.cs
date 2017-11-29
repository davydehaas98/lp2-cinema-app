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
        public Client(int id, string firstname, string lastname, DateTime birthday, string gender, string email)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.gender = gender;
            this.email = email;
        }
    }
}
