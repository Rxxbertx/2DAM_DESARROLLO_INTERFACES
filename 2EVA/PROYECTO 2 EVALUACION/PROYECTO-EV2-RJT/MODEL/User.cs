using MySqlConnector;
using practicaLoginRJT.database;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;

namespace PROYECTO_EV2_RJT.MODEL
{
    // es una clase que se encarga de gestionar el usuario que se ha logeado en la aplicación
    class User
    {
        // campos privados para la instancia de la clase y la contraseña del usuario
        private static User? instance;
        private readonly string password;
        private bool specialRole;

        public string Username { get; set; }
        public string Name { get; set; }
        public bool SpecialRole
        {
            get { return specialRole; }
            private set { specialRole = value; }
        }

        private User(string username, string password, string name)
        {
            Username = username;
            this.password = password;
            Name = name;
        }

        // método para crear la instancia de la clase User es un patrón Singleton
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

        // método para comprobar si el usuario existe en la base de datos
        public static int AuthenticateUser(string username, string password)
        {
            DBConnection db = DBConnection.DBInit();
            string query = "SELECT * FROM users WHERE username_user = @username AND password_user = @password";

            using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int id = -1;
                            while (reader.Read())
                            {
                                string name = reader.GetString(2);
                                id = reader.GetInt32(0);
                                // instancia de la clase User si no existe se crea
                                GetInstance(username, password, name);
                            }

                            command.Dispose();
                            reader.Close();

                            // comprobamos si el usuario es un usuario especial
                            CheckAdminUsername(id);
                            return LoginConstants.SUCCESS;
                        }
                        // si no existe entonces comprobamos si el nombre de usuario existe en la base de datos
                        else
                        {
                            command.Dispose();
                            reader.Close();
                            // comprobamos si el nombre de usuario existe en la base de datos
                            return CheckUsername(username, db);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return LoginConstants.ERROR;
                }
                finally
                {
                    DBConnection.CloseConnection(db);
                }

            }
        }

        // método para comprobar si el usuario es un usuario especial
        private static void CheckAdminUsername(int id)
        {
            DBConnection db = DBConnection.DBInit();
            string query = "SELECT special_users_users FROM special_users WHERE special_users_users = @id";

            using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
            {
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // si el usuario es un usuario especial se le asigna el rol de administrador
                        if (reader.HasRows)
                        {
                            GetInstance().SpecialRole = true;
                        }
                        else
                        {
                            GetInstance().SpecialRole = false;
                        }
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            // si el usuario es un usuario especial se abre una conexión a la base de datos modificada con permisos de administrador
            if (GetInstance().SpecialRole) DBConnection.DBInit().ModifyConnection().Commit();


        }

        // método para comprobar si el nombre de usuario existe en la base de datos
        private static int CheckUsername(string username, DBConnection db)
        {
            string query = "SELECT * FROM users WHERE username_user = @username";

            using (MySqlCommand command = new(query, DBConnection.OpenConnection(db)))
            {
                command.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        //si existe entonces la contraseña es incorrecta
                        return LoginConstants.PASSWORD_INCORRECT;
                    }
                    else
                    {
                        // si no existe entonces el usuario no existe
                        return LoginConstants.USER_NOT_FOUND;
                    }
                }
            }
        }
    }
}
