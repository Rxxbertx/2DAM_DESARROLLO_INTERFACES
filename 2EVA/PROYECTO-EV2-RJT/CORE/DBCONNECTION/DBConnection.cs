using MySqlConnector;
using PROYECTO_EV2_RJT.MODEL;
using System;
using System.Windows;

namespace practicaLoginRJT.database
{
    public class DBConnection
    {
        // Campos privados para las propiedades de conexión a la base de datos
        private MySqlConnectionStringBuilder? builder;
        private MySqlConnection? connection;

        // Propiedades de conexión a la base de datos
        private string? server;
        private string? database;
        private string? uid;
        private string? password;
        private uint? port;

        // Instancia única de DBConnection (patrón Singleton)
        private static DBConnection? instance;

        // Propiedades para acceder a las propiedades de conexión a la base de datos
        public string? Server { get => server; set => server = value; }
        public string? Database { get => database; set => database = value; }
        public string? Uid { get => uid; set => uid = value; }
        public string? Password { set => password = value; }
        public uint? Port { get => port; set => port = value; }

        // Constructor privado para aplicar el patrón Singleton y establecer valores predeterminados
        private DBConnection()
        {
            Server = "127.0.0.1";
            Uid = "admin";
            Password = "dam2t";
            Database = "mydb";
            Port = 3306;
        }

        // Método de creación de la instancia Singleton
        public static DBConnection DBInit()
        {
            instance ??= new DBConnection();

            return instance;
        }

        // Método para crear o recuperar el constructor MySqlConnectionStringBuilder
        private MySqlConnectionStringBuilder Builder()
        {
            if (builder != null) return builder;

            builder = new MySqlConnectionStringBuilder();
            return builder;
        }

        // Método para crear o recuperar la conexión MySqlConnection
        private MySqlConnection Connection()
        {
            if (connection != null) return connection;

            MySqlConnectionStringBuilder builder = Builder();

            builder.Server = Server;
            builder.UserID = Uid;
            builder.Password = password;
            builder.Database = Database;
            builder.Port = (uint)Port;

            connection = new MySqlConnection(builder.ConnectionString);
            return connection;
        }

        // Método para abrir una conexión a la base de datos
        public static MySqlConnection? OpenConnection(DBConnection instance)
        {
            MySqlConnection connection = instance.Connection();

            if (connection == null)
            {
                
                return null;
            }

            if (connection.State == System.Data.ConnectionState.Open)
            {
               
                return connection;
            }

            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    connection.Open();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }

            return connection;
        }

        // Método para cerrar una conexión a la base de datos
        public static void CloseConnection(DBConnection instance)
        {
            MySqlConnection? connection = instance.Connection();

            if (connection == null)
            {
                Console.WriteLine("No se puede cerrar la conexión, la conexión es nula");
                return;
            }
            else
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    try
                    {
                        connection.Close();
                        instance.connection = null;
                        Console.WriteLine("Conexión cerrada");
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
        }



        // Método para modificar la conexión
        public DBConnection ModifyConnection()
        {
            if (User.GetInstance().SpecialRole)
            {

                Uid = "admin";
                Password = "dam2t";
            }
            else
            {
                Uid = "basic";
                Password = "basic";
            }
            return this;
        }

        public void Commit()
        {

            connection = null;

            connection = Connection();

            if (connection == null)
            {
                Console.WriteLine("No se puede hacer commit, la conexión es nula");
                return;
            }

            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("No se puede hacer commit, la conexión no está abierta");
                return;
            }

            try
            {
                connection.Close();
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
