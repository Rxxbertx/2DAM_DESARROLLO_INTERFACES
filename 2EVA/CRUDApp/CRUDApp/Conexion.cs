using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp
{ /*
     * Devuelve una conexión MySQL abierta, por patrón singleton.
     * Si la conexión es null, la crea y, si está cerrada, la abre.
     */
    public class Conexion
    {
        /* Define variables que se van a utilizar dentro de la clase */
        private static MySqlConnectionStringBuilder builder = null;
        private static MySqlConnection conn = null;
        private static String SERVIDOR = "localhost";
        private static uint PUERTO = 3306;
       // private static String BD = "bazar";
        private static String USUARIO = "root";
        private static String PASSWORD = "1234";

        private static MySqlConnectionStringBuilder getBuilder()
        {
            if (builder == null)
            {
                try
                {
                    builder = new MySqlConnectionStringBuilder();
                }
                catch (Exception)
                {
                    builder = null;
                }
            }
            return builder;
        }

        public static MySqlConnection obtenerConexionAbierta(string nombreBD)
        {
            if (conn == null)
            {
                if (getBuilder() == null)
                {
                    return null;
                }
                builder.Server = SERVIDOR;
                builder.Port = PUERTO;
                builder.UserID = USUARIO;
                builder.Password = PASSWORD;
                builder.Database = nombreBD;
                try
                {
                    conn = new MySqlConnection(builder.ToString());
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            else if (conn.State != ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }

            if (conn.State == ConnectionState.Open)
            {
                Console.Write("Conexión a la BD establecida\n");
            }
            return conn;
        }

        public static void cerrarConexion()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();

                    if (conn.State == ConnectionState.Closed)
                    {
                        Console.Write("BD desconectada\n");
                    }
                }
                catch (Exception)
                {
                    Console.Write("Error al desconectar la BD\n");
                }
            }
        }
    }
}
