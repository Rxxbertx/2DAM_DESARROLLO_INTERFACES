using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_RJT.MODEL
{
    class User
    {
        private static User instance;
        private string password;
        internal readonly bool SpecialRole;

        public string Username { get; set; }
        public string Name { get; set; }

        private User(string username, string password, string name)
        {
            Username = username;
            this.password = password;
            Name = name;
        }

        public static User GetInstance(string username, string password, string name)
        {
            if (instance == null)
            {
                instance = new User(username, password, name);
            }
            return instance;
        }

        public static User GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("La instancia de User no ha sido creada.");
            }
            return instance;
        }

        public static int AuthenticateUser(string username, string password)
        {

            return 0;

        }
        
    }
}
