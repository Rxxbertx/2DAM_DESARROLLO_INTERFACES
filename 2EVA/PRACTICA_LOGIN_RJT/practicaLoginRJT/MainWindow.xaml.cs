using MySqlConnector;
using practicaLoginRJT.database;
using practicaLoginRJT.Windows;
using ShakeAnimationExample;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace practicaLoginRJT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection? MySqlConnection;
        private uint userID;
        private const int loginMaxAttempts = 3;
        private int loginAttempts = loginMaxAttempts;
        private string username_var_old;

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection = InitializeConnection();
        }

        // Inicializa la conexión a la base de datos
        private MySqlConnection? InitializeConnection()
        {
            DBConnection connection = DBConnection.DBInit();
            return DBConnection.OpenConnection(connection);
        }

        // Maneja el clic en el botón de inicio de sesión
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUsernamePassword())
                LoginDB();
        }

        // Verifica el nombre de usuario y la contraseña
        private bool CheckUsernamePassword()
        {
            string username_var = username.Text.ToString();
            string password_var = password.Password.ToString();

            if (username_var.Length <= 0 || password_var.Length <= 0)
            {
                ShowErrorMessage(infoText, "Ingrese un nombre de usuario y una contraseña");
                return false;
            }

            if (username_var_old != username_var)
            {
                loginAttempts = loginMaxAttempts;
            }
            username_var_old = username_var;
            return true;
        }

        // Inicia sesión en la base de datos
        private void LoginDB()
        {
            if (MySqlConnection == null) return;

            String query = "SELECT id FROM usuario WHERE usuario = @User";
            using (MySqlCommand command = new MySqlCommand(query, MySqlConnection))
            {
                command.Parameters.AddWithValue("@User", username.Text);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userID = reader.GetUInt32(0);
                        }
                    }
                    else
                    {
                        ShowErrorMessage(infoText, "El usuario ingresado no existe en la base de datos.");
                        return;
                    }
                }
            }

            if (!CheckDisabledAccounts(userID))
            {
                if (CheckPassword(userID))
                {
                    if (CheckAdmin(userID))
                        new AdminWindow(userID).Show();
                    else
                        new UserWindow(userID).Show();
                }
            }
        }

        // Verifica si el usuario es un administrador
        private bool CheckAdmin(uint userID)
        {
            String query = "SELECT admin FROM usuario WHERE id = @UserID";

            using (MySqlCommand command = new MySqlCommand(query, MySqlConnection))
            {
                command.Parameters.AddWithValue("@UserID", userID);

                using (var reader = command.ExecuteReader())
                {
                    bool temp = false;

                    while (reader.Read())
                    {
                        temp = reader.GetBoolean(0);
                    }

                    return temp;
                }
            }
        }

        // Verifica la contraseña del usuario
        private bool CheckPassword(uint userID)
        {
            StringBuilder sb = new StringBuilder();
            String query = "SELECT contraseña FROM usuario WHERE id = @UserID";
            using (MySqlCommand command = new MySqlCommand(query, MySqlConnection))
            {
                command.Parameters.AddWithValue("@UserID", userID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sb.Append(reader.GetString(0));
                        }
                    }
                    else
                    {
                        ShowErrorMessage(infoText, "Esta cuenta necesita una verificación de administrador. Código de error: NPW");
                        return false;
                    }
                }
            }

            if (password.Password.Equals(sb.ToString()))
            {
                infoText.Content = "Conexión exitosa";
                loginAttempts = loginMaxAttempts;
                return true;
            }
            else
            {
                loginAttempts--;
                if (loginAttempts <= 0)
                {
                    BlockAccount(userID);
                    return false;
                }
                ShowErrorMessage(infoText, $"Contraseña incorrecta. Intentos restantes: {loginAttempts}");
                return false;
            }
        }

        // Bloquea la cuenta del usuario
        private void BlockAccount(uint userID)
        {
            String query = $"INSERT INTO bloqueo (usuario_id) VALUES ({userID});";

            using (MySqlCommand command = new MySqlCommand(query, MySqlConnection))
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    ShowErrorMessage(infoText, "Cuenta bloqueada. Contacta a un administrador para desbloquearla.");
                    loginAttempts = loginMaxAttempts;
                }
                else
                {
                    ShowErrorMessage(infoText, "Contacta a un administrador. Código de error: NOBA");
                }
            };
        }

        // Muestra un mensaje de error en la interfaz
        private void ShowErrorMessage(Label infoText, string v)
        {
            infoText.Content = v;
            infoText.Margin = new Thickness(0);
            new Shaker(infoText).Shake();
        }

        // Verifica si la cuenta del usuario está bloqueada
        private bool CheckDisabledAccounts(uint userID)
        {
            String query = $"SELECT id FROM bloqueo WHERE usuario_id={userID}";

            using (MySqlCommand command = new MySqlCommand(query, MySqlConnection))
            {
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ShowErrorMessage(infoText, "Cuenta bloqueada. Contacta a un administrador para desbloquearla.");
                    return true;
                }
            }

            return false;
        }

        // Maneja el evento de cierre de la ventana
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DBConnection.CloseConnection(DBConnection.DBInit());
            Application.Current.Shutdown();
        }

        // Maneja el evento de salida (cerrar ventana)
        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
