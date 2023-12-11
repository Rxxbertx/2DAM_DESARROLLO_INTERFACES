using Microsoft.Win32;
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
using MySqlConnector;

namespace CRUD_DespegableImagenFechaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String BD = "bazar2";
        
        private String idProductoAnterior = "";
        private String codProductoAnterior = "";
        private String nombreAnterior = "";
        private String descripcionAnterior = "";
        private byte[] imagenAnterior = null;
        private DateTime fechaAltaAnterior = new DateTime();
        private String precioAnterior = "";
        private String existenciasAnterior = "";
        private String idCategoriaAnterior = "";

        private byte[] imagenActual = null;

        List<Categoria> lCategorias = new List<Categoria>();

        public MainWindow()
        {
            InitializeComponent();
            cargarCategorias();
            dpFechaAlta.SelectedDate = DateTime.Today;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            // No permitir guardar registros con datos vacios
            if (txtCodProducto.Text != "" && txtNombre.Text != "" &&
                txtDescripcion.Text != "" && txtPrecio.Text != "" &&
                txtExistencias.Text != "" && txtIdCategoria.Text != "")
            {
                // No podemos dar de alta un registro con el mismo campo clave
                if (txtCodProducto.Text != codProductoAnterior)
                {
                    try
                    {
                        try
                        {
                            if (!existeProducto(txtCodProducto.Text))
                            {

                                // Obtener una conexión abierta a la BD
                                MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                                if (conexionBD == null)
                                {
                                    Console.WriteLine("Error en Conexion a BD");
                                }
                                else
                                {
                                    try
                                    {
                                        string sql = "INSERT INTO productos (codigoProducto, " +
                                            "nombre, descripcion, imagen, fechaAlta, precio, existencias, " +
                                            "idCategoria) VALUES (@codigoProducto, @nombre, @descripcion, " +
                                            "@imagen, @fechaAlta, @precio, @existencias, @idCategoria)";

                                        // comando a ejecutar en la BD
                                        using var comando = new MySqlCommand(sql, conexionBD);
                                        comando.Parameters.AddWithValue("@codigoProducto", txtCodProducto.Text);
                                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                        comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                                        comando.Parameters.AddWithValue("@imagen", imagenActual);
                                        comando.Parameters.AddWithValue("@fechaAlta", DateTime.Parse(dpFechaAlta.Text));
                                        comando.Parameters.AddWithValue("@precio", txtPrecio.Text.Replace(',', '.'));
                                        comando.Parameters.AddWithValue("@existencias", int.Parse(txtExistencias.Text));
                                        comando.Parameters.AddWithValue("@idCategoria", int.Parse(txtIdCategoria.Text));
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
                            else
                            {
                                MessageBox.Show("Imposible guardar - Producto ya existe");
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
                    Console.WriteLine("Error en Conexion a BD: " +BD);
                }
                else
                {
                    try
                    {
                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT idProducto, codigoProducto, " +
                                 "nombre, descripcion, imagen, fechaAlta, precio, " +
                                 "existencias, idCategoria " +
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

                                if (reader.GetValue(4) != DBNull.Value)
                                {
                                    imgProducto.Source =
                                        Utils.ConvertByteArrayToBitmapImage((byte[])reader.GetValue(4));
                                    // imgProducto.Source =
                                    //     Utils.ConvertByteArrayToBitmapImage((byte[])reader["imagen"]);
                                    imagenAnterior = (byte[])reader.GetValue(4);
                                    imagenActual = (byte[])reader.GetValue(4);
                                }

                                dpFechaAlta.SelectedDate = reader.GetDateTime(5);
                                fechaAltaAnterior = reader.GetDateTime(5);
                                txtPrecio.Text = reader.GetDecimal(6).ToString();
                                precioAnterior = reader.GetDecimal(6).ToString();
                                txtExistencias.Text = reader.GetInt32(7).ToString();
                                existenciasAnterior = reader.GetInt32(7).ToString();
                                txtIdCategoria.Text = reader.GetInt32(8).ToString();
                                // seleccionar categoria en combobox.
                                asignarCategoria(reader.GetInt32(8));
                                idCategoriaAnterior = reader.GetInt32(8).ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos");
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
                txtExistencias.Text != "" && txtIdCategoria.Text != "" &&
                dpFechaAlta.Text != "")
            {
                // Modificar datos si no son identicos a los que existen en la BD.
                if (txtCodProducto.Text != codProductoAnterior ||
                    txtNombre.Text != nombreAnterior ||
                    txtDescripcion.Text != descripcionAnterior ||
                    txtPrecio.Text != precioAnterior ||
                    txtExistencias.Text != existenciasAnterior ||
                    txtIdCategoria.Text != idCategoriaAnterior ||
                    Convert.ToDateTime(dpFechaAlta.Text) != fechaAltaAnterior ||
                    Utils.ByteArrayCompare(imagenActual, imagenAnterior) == false)
                {
                    try
                    {
                        try
                        {
                            if (existeProducto(txtCodProducto.Text))
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
                                        "nombre=@nombre, descripcion=@descripcion, " +
                                        "imagen=@imagen, fechaAlta=@fechaAlta, " +
                                        "precio=@precio, " +
                                        "existencias=@existencias, " +
                                        "idCategoria=@idCategoria " +
                                        "WHERE codigoProducto=@codigoProducto;";

                                        // comando a ejecutar en la BD
                                        using var comando = new MySqlCommand(sql, conexionBD);

                                        comando.Parameters.AddWithValue("@codigoProducto", txtCodProducto.Text);
                                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                        comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                                        comando.Parameters.AddWithValue("@imagen", imagenActual);
                                        comando.Parameters.AddWithValue("@fechaAlta", DateTime.Parse(dpFechaAlta.Text));
                                        comando.Parameters.AddWithValue("@precio", txtPrecio.Text.Replace(',', '.'));
                                        comando.Parameters.AddWithValue("@existencias", int.Parse(txtExistencias.Text));
                                        comando.Parameters.AddWithValue("@idCategoria", int.Parse(txtIdCategoria.Text));
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
                            else
                            {
                                MessageBox.Show("Imposible modificación - Producto no existe");
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
            // No permitir eliminar registros si codProducto está vacío
            if (txtCodProducto.Text != "")
            {
                if (existeProducto(txtCodProducto.Text))
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
                                string sql = "DELETE FROM productos " +
                                    "WHERE codigoProducto=@codigoProducto;";
                                // comando a ejecutar en la BD
                                using var comando = new MySqlCommand(sql, conexionBD);

                                comando.Parameters.AddWithValue("@codigoProducto", txtCodProducto.Text);
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
                    MessageBox.Show("Imposible eliminación - Producto no existe");
                }
            }
            else
            {
                MessageBox.Show("Datos vacios. No se puede eliminar producto");
            }
        }

        private void btnCargarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Imagenes| *.jpg; *.jpeg; *.png; *.gif";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgProducto.Source = new BitmapImage(fileUri);

                imagenActual = Utils.ConvertBitmapSourceToByteArray(new BitmapImage(new Uri(openFileDialog.FileName)));
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void cbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox categorias = (ComboBox)sender;

            if (categorias.SelectedIndex != 0)
            {
                txtIdCategoria.Text = lCategorias[categorias.SelectedIndex - 1].Id.ToString();
            }
            else
            {
                txtIdCategoria.Text = "";
            }
        }

        private void limpiar()
        {
            txtIdProducto.Text = "";
            txtCodProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtExistencias.Text = "";
            txtIdCategoria.Text = "";
            cbCategoria.SelectedIndex = 0;
            imgProducto.Source = null;
            imagenAnterior = null;
            imagenActual = null;
            fechaAltaAnterior = DateTime.Today;
            dpFechaAlta.SelectedDate = DateTime.Today;
        }

        private void cargarCategorias()
        {
            // limpiar el combobox
            cbCategoria.Items.Clear();
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
                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT id, nombre FROM categorias ORDER BY nombre ASC;";

                        using var comando = new MySqlCommand(consulta, conexionBD);

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Obtención del cursor con el resultado de una consulta
                            while (reader.Read())
                            {
                                lCategorias.Add(new Categoria()
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1)
                                });
                            }

                            // la primera categoria estará vacia.
                            ComboBoxItem nuevaCategoriaVacia = new ComboBoxItem();
                            TextBlock contenidoVacio = new TextBlock();
                            contenidoVacio.Text = "";
                            nuevaCategoriaVacia.Content = contenidoVacio;
                            cbCategoria.Items.Add(nuevaCategoriaVacia);

                            foreach (var i in lCategorias)
                            {
                                // Añadir las categorias a items del ComboBox
                                ComboBoxItem nuevaCategoria = new ComboBoxItem();
                                TextBlock contenido = new TextBlock();
                                contenido.Text = i.Nombre;
                                nuevaCategoria.Content = contenido;
                                cbCategoria.Items.Add(nuevaCategoria);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron categorías");
                            lCategorias = null;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error al cargar las categorías: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al buscar categorías: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
        }

        private void asignarCategoria(int idCat)
        {
            // Recorrer el combobox y seleccionar la categoria que coincida con
            // la categoria pasada por parámetro.
            int indice = 1;
            foreach (var i in lCategorias)
            {
                if (i.Id == idCat)
                {
                    cbCategoria.SelectedIndex = indice;
                }
                indice++;
            }
        }

        private bool existeProducto(string codProd)
        {
            bool existe = false;

            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection conexionBD = Conexion.obtenerConexionAbierta(BD);

                if (conexionBD == null)
                {
                    Console.WriteLine("Error en Conexion a BD: " + BD);
                    existe = false;
                    return existe;
                }
                else
                {
                    try
                    {
                        // Para modificar, verificar primero que exista el producto.
                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT idProducto " +
                                 "FROM productos WHERE codigoProducto = " +
                                 "@codigoProducto LIMIT 1";

                        using var comando = new MySqlCommand(consulta, conexionBD);

                        comando.Parameters.AddWithValue("@codigoProducto", codProd);
                        comando.Prepare();

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            existe = true;
                        }
                        else
                        {
                            existe = false;
                        }
                        return existe;
                    }

                    catch (InvalidOperationException ex)
                    {
                        existe = false;
                        Console.WriteLine("Error en busqueda producto: " + ex.Message);
                        return existe;
                    }
                    finally
                    {

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al buscar producto: " + ex.Message);
                existe = false;
                return existe;
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
        }
    }
}