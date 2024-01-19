using MySqlConnector;
using practicaLoginRJT.database;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;

namespace PROYECTO_EV2_RJT.MODEL
{
    class User
    {
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
                                GetInstance(username, password, name);
                            }

                            command.Dispose();
                            reader.Close();
                            CheckAdminUsername(id);
                            return LoginConstants.SUCCESS;
                        }
                        else
                        {
                            command.Dispose();
                            reader.Close();
                            return CheckUsername(username, db);
                        }
                    }
                }
                catch (MySqlException e)
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


            if (GetInstance().SpecialRole) DBConnection.DBInit().ModifyConnection().Commit();


        }

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
                        return LoginConstants.PASSWORD_INCORRECT;
                    }
                    else
                    {
                        return LoginConstants.USER_NOT_FOUND;
                    }
                }
            }
        }
    }
}
