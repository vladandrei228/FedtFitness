using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedtFitness.Model
{
    public class RegisterAndLogin
    {
        private int _idregister;
        private string _username;
        private string _password;
        private string _email;

       public RegisterAndLogin()
        {

        }

        public RegisterAndLogin(int idregister,string usn, string pass, string email)
        {
            _idregister = idregister;
            _username = usn;
            _password = pass;
            _email = email;
        }

        public int Idregister
        {
            get { return _idregister; }
            set { _idregister = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
