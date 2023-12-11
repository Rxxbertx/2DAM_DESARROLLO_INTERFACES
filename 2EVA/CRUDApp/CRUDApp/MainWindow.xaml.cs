using MySqlConnector;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String BD = "bazar";

        private String idProductoAnterior = "";
        private String codProductoAnterior = "";
        private String nombreAnterior = "";
        private String descripcionAnterior = "";
        private String precioAnterior = "";
        private String existenciasAnterior = "";

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // No permitir guardar registros con datos vacios
            if (txtCodProducto.Text != "" && txtNombre.Text != "" &&
                txtDescripcion.Text != "" && txtPrecio.Text != "" &&
                txtExistencias.Text != "")
            {
                // No podemos dar de alta un registro con el mismo campo clave
                if (txtCodProducto.Text != codProductoAnterior)
                {
                    try
                    {
                        try
                        {
                            // Obtener una conexión abierta a la BD
                            MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                            if (conexionBD == null)
                            {
                                Console.WriteLine("Error en Conexion a BD: " + BD);
                            }
                            else
                            {
                                try
                                {
                                    string sql = "INSERT INTO productos (codigoProducto," +
                                        "nombre, descripcion, precio, existencias) VALUES " +
                                        "(@codigoProducto, @nombre, @descripcion, " +
                                        "@precio, @existencias)";

                                    // comando a ejecutar en la BD
                                    using var comando = new MySqlCommand(sql, conexionBD);
                                    comando.Parameters.AddWithValue("@codigoProducto", txtCodProducto.Text);
                                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                    comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                                    comando.Parameters.AddWithValue("@precio", txtPrecio.Text.Replace(',', '.'));
                                    comando.Parameters.AddWithValue("@existencias", int.Parse(txtExistencias.Text));

                                    comando.Prepare();

                                    // Ejecución del comando
                                    comando.ExecuteNonQuery();

                                    MessageBox.Show("Producto guardado");

                                    limpiar();

                                }
                                catch (MySqlException ex)
                                {
                                    MessageBox.Show("Error al guardar producto: " + ex.Message);
                                }
                            }
                        }

                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        finally
                        {
                            // siempre se cierra la conexion
                            Conexion.cerrarConexion();
                        }

                    }
                    catch (FormatException fex)
                    {
                        MessageBox.Show("Datos incorrectos: " + fex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Producto no creado. Producto ya existe." +
                        " Para modificar producto utilizar botón Actualizar");
                }
            }
            else
            {
                MessageBox.Show("Algunos datos vacios. Introducir todos los datos");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD: " + BD);
                }
                else
                {
                    try
                    {
                        // Variable para tratar cada linea del cursor devuelto en la consulta
                        String data = null;

                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT idProducto, codigoProducto, " +
                                 "nombre, descripcion, precio, existencias " +
                                 "FROM productos WHERE codigoProducto = " +
                                 "@codProducto LIMIT 1";

                        using var comando = new MySqlCommand(consulta, conexionBD);

                        comando.Parameters.AddWithValue("@codProducto", txtCodProducto.Text);
                        comando.Prepare();

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Obtención del cursor con el resultado de una consulta
                            while (reader.Read())
                            {
                                txtIdProducto.Text = reader.GetInt32(0).ToString();
                                idProductoAnterior = reader.GetInt32(0).ToString();
                                txtCodProducto.Text = reader.GetString(1);
                                codProductoAnterior = reader.GetString(1);
                                txtNombre.Text = reader.GetString(2);
                                nombreAnterior = reader.GetString(2);
                                txtDescripcion.Text = reader.GetString(3);
                                descripcionAnterior = reader.GetString(3);
                                txtPrecio.Text = reader.GetDecimal(4).ToString();
                                precioAnterior = reader.GetDecimal(4).ToString();
                                txtExistencias.Text = reader.GetInt32(5).ToString();
                                existenciasAnterior = reader.GetInt32(5).ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros");
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error en busqueda productos: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al buscar productos: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            // No permitir modificar registros con datos vacios
            if (txtCodProducto.Text != "" && txtNombre.Text != "" &&
                txtDescripcion.Text != "" && txtPrecio.Text != "" &&
                txtExistencias.Text != "")
            {
                // Modificar datos si no son identicos a los que existen en la BD.
                if (txtIdProducto.Text != idProductoAnterior ||
                    txtCodProducto.Text != codProductoAnterior ||
                    txtNombre.Text != nombreAnterior ||
                    txtDescripcion.Text != descripcionAnterior ||
                    txtPrecio.Text != precioAnterior ||
                    txtExistencias.Text != existenciasAnterior)
                {
                    try
                    {
                        try
                        {
                            // Obtener una conexión abierta a la BD
                            MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                            if (conexionBD == null)
                            {
                                Console.WriteLine("Error en Conexion a BD: " + BD);
                            }
                            else
                            {
                                try
                                {
                                    string sql = "UPDATE productos SET " +
                                    "codigoProducto=@codigoProducto, " +
                                    "nombre=@nombre, descripcion=@descripcion, " +
                                    "precio=@precio, existencias=@existencias " +
                                    "WHERE idProducto=@idProducto;";

                                    // comando a ejecutar en la BD
                                    using var comando = new MySqlCommand(sql, conexionBD);

                                    comando.Parameters.AddWithValue("@idProducto", int.Parse(txtIdProducto.Text));
                                    comando.Parameters.AddWithValue("@codigoProducto", txtCodProducto.Text);
                                    comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                    comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                                    comando.Parameters.AddWithValue("@precio", txtPrecio.Text.Replace(',', '.'));
                                    comando.Parameters.AddWithValue("@existencias", int.Parse(txtExistencias.Text));

                                    comando.Prepare();

                                    // Ejecución del comando
                                    comando.ExecuteNonQuery();

                                    MessageBox.Show("Producto modificado");
                                    limpiar();

                                }
                                catch (MySqlException ex)
                                {
                                    MessageBox.Show("Error al modificar producto: " + ex.Message);
                                }
                            }
                        }

                        catch (MySqlException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        finally
                        {
                            // siempre se cierra la conexion
                            Conexion.cerrarConexion();
                        }
                    }
                    catch (FormatException fex)
                    {
                        MessageBox.Show("Datos incorrectos: " + fex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Producto no modificado. Mismos datos en Base de Datos");
                }
            }
            else
            {
                MessageBox.Show("Datos vacios. No se puede modificar producto");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // No permitir eliminar registros si idProducto
            if (txtIdProducto.Text != "")
            {
                try
                {
                    // Obtener una conexión abierta a la BD
                    MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                    if (conexionBD == null)
                    {
                        Console.WriteLine("Error en Conexion a BD: " + BD);
                    }
                    else
                    {
                        try
                        {
                            string sql = "DELETE FROM productos WHERE idProducto=@idProducto;";
                            // comando a ejecutar en la BD
                            using var comando = new MySqlCommand(sql, conexionBD);

                            comando.Parameters.AddWithValue("@idProducto", int.Parse(txtIdProducto.Text));
                            comando.Prepare();

                            // Ejecución del comando
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Producto eliminado");
                            limpiar();

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Error al eliminar producto: " + ex.Message);
                        }
                    }
                }

                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // siempre se cierra la conexion
                    Conexion.cerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("Datos vacios. No se puede eliminar producto");
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtIdProducto.Text = "";
            txtCodProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencias.Text = "";
        }
    }
}