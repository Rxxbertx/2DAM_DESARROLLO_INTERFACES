using MySqlConnector;
using practicaLoginRJT.database;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace practicaLoginRJT.Windows
{
    /// <summary>
    /// Lógica de interacción para AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ObservableCollection<ItemTabla>? Items { get; set; }
        private MySqlConnection? mySqlConnection;

        // Constructor
        public AdminWindow(uint userID)
        {
            InitializeComponent();
            InitializeConnection();
            InitializeData();
        }

        // Inicializa los datos de la ventana
        private void InitializeData()
        {
            Items = new ObservableCollection<ItemTabla>();

            // Query para obtener datos de usuarios y bloqueos
            string query = @"
                            SELECT 
                                u.id,u.usuario,u.nombre,u.contraseña,u.admin,
                                CASE 
                                    WHEN b.usuario_id IS NOT NULL THEN 1
                                    ELSE 0
                                END AS bloqueado
                            FROM 
                                usuario u
                            LEFT JOIN 
                                bloqueo b ON u.id = b.usuario_id";

            using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Agrega elementos a la colección
                        Items.Add(new ItemTabla
                        {
                            Id = reader.GetUInt16(0),
                            UserName = reader.GetString(1),
                            Name = reader.GetString(2),
                            Password = reader.GetString(3),
                            Admin = reader.GetBoolean(4),
                            Blocked = reader.GetBoolean(5)
                        });
                    }
                }
            }

            // Establece la fuente de datos para el DataGrid
            dataGrid.ItemsSource = Items;
        }

        // Inicializa la conexión a la base de datos
        private void InitializeConnection() => mySqlConnection = DBConnection.OpenConnection(DBConnection.DBInit());

        // Cierra la conexión a la base de datos
        private void CloseConnection() => DBConnection.CloseConnection(DBConnection.DBInit());

        // Maneja el evento Checked del CheckBox (Bloquear usuario)
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var item = dataGrid.SelectedValue as ItemTabla;

            if (item != null)
            {
                // Query para insertar un bloqueo
                String query = "INSERT INTO bloqueo (usuario_id) VALUES (@UserID)";

                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@UserID", item.Id);

                    int i = command.ExecuteNonQuery();

                    if (i == 0) { MessageBox.Show("ERROR AL BLOQUEAR USUARIO"); }

                    MessageBox.Show("USUARIO BLOQUEADO");
                }
            }
        }

        // Maneja el evento Unchecked del CheckBox (Desbloquear usuario)
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var item = dataGrid.SelectedValue as ItemTabla;

            if (item != null)
            {
                // Query para eliminar un bloqueo
                String query = "DELETE FROM bloqueo WHERE usuario_id = @UserID";

                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@UserID", item.Id);

                    int i = command.ExecuteNonQuery();

                    if (i == 0) MessageBox.Show("ERROR AL DESBLOQUEAR USUARIO");

                    MessageBox.Show("USUARIO DESBLOQUEADO");
                }
            }
        }

        // Maneja el evento de salida (Cerrar ventana)
        private void Exit(object sender, MouseButtonEventArgs e) => Close();

        // Clase interna para representar los elementos en el DataGrid
        private class ItemTabla
        {
            public UInt16 Id { get; set; }
            public string Name { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool Admin { get; set; }
            public bool Blocked { get; set; }
        }
    }
}

