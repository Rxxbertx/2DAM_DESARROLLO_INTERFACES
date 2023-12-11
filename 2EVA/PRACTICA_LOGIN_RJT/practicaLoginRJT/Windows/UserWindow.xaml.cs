using MySqlConnector;
using practicaLoginRJT.database;
using System;
using System.Windows;
using System.Windows.Input;

namespace practicaLoginRJT.Windows
{
    /// <summary>
    /// Lógica de interacción para UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private uint userID;
        private MySqlConnection? mySqlConnection;

        // Constructor
        public UserWindow(uint userID)
        {
            this.userID = userID;
            InitializeComponent();
            InitializeConnection();
            ShowUserData();
        }

        // Cierra la conexión a la base de datos
        private void CloseConnection() => DBConnection.CloseConnection(DBConnection.DBInit());

        // Muestra los datos del usuario en la ventana
        private void ShowUserData()
        {
            // Verifica si la conexión a la base de datos está establecida
            if (mySqlConnection == null) { return; }

            // Query para obtener datos del usuario
            String query = "SELECT id,usuario,nombre,contraseña FROM usuario WHERE id = @UserID";

            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                command.Parameters.AddWithValue("@UserID", userID);

                // Ejecuta la consulta y lee los resultados
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Muestra los datos del usuario en los elementos de la interfaz gráfica
                        id.Content = reader.GetUInt16(0);
                        username.Content = reader.GetString(1);
                        name.Content = reader.GetString(2);
                        password.Content = reader.GetString(3);
                    }
                }
            }
        }

        // Inicializa la conexión a la base de datos
        private void InitializeConnection() => mySqlConnection = DBConnection.OpenConnection(DBConnection.DBInit());

        // Maneja el evento de salida (Cerrar ventana)
        private void Exit(object sender, MouseButtonEventArgs e) => Close();
    }
}

