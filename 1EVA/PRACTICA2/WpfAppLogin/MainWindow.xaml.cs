using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace WpfAppLogin;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{


    #region VARIABLES

    // Arreglo de letras para validar el DNI
    private static readonly char[] Letras =
    {
        'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X',
        'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'
    };

    // Arreglo de edades
    private static readonly int[] Edad = new int[110];

    // Cargar un documento XML
    private static readonly XDocument Doc = XDocument.Load("strings.xml");

    // Arreglo de errores para los campos del formulario
    private static bool[] error = new bool[5];


    #endregion

    public MainWindow()
    {
        InitializeComponent();
        Init();
    }

    // Método de inicialización
    private void Init()
    {
        // Asignar la lista de elementos al ComboBox
        LlenarCombos();

        // Inicializar el arreglo de errores a true por defecto
        Array.Fill(error, true);
    }

    // Método para llenar los ComboBox
    private void LlenarCombos()
    {
        comboBoxLetraDni.ItemsSource = Letras;

        for (var i = 0; i < Edad.Length; i++) Edad[i] = i + 1;
        comboBoxEdad.ItemsSource = Edad;
    }

    // Evento de clic en el botón
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender.Equals(btnCompletar))
        {
            if (error.All(item => item == false))
            {
                // Ventana de advertencia en caso de éxito
                var ventanaAdvertencia = new VentanaAdvertencia(msg: Doc.Descendants("registroExitoso").FirstOrDefault().Value,mail.Text,nombre.Text,comboBoxEdad.SelectedValue,apellido1.Text,apellido2.Text,dniN.Text,comboBoxLetraDni.SelectedValue);
                ventanaAdvertencia.Owner = this;
                ventanaAdvertencia.ShowDialog();
                
            }
            else
            {
                // Ventana de advertencia en caso de errores en el formulario
                var ventanaAdvertencia = new VentanaAdvertencia(msg: Doc.Descendants("errorFormulario").FirstOrDefault().Value);
                ventanaAdvertencia.Owner = this;
                ventanaAdvertencia.ShowDialog();
                comprobarCampos();
            }
        }

        if (sender.Equals(btnSalir))
        {
            Close(); // Cerrar la ventana principal
        }
    }

    // Evento de cierre de la ventana
    private void MainWindow_Closing(object sender, CancelEventArgs e)
    {
        e.Cancel = cerrarVentana(e);
    }

    // Método para mostrar una ventana de confirmación antes de cerrar
    private bool cerrarVentana(CancelEventArgs e)
    {
        VentanaConfirmacionCerrar _ventanaConfirmacion = new();
        _ventanaConfirmacion.Owner = this;
        _ventanaConfirmacion.ShowDialog();

        return !_ventanaConfirmacion.Confirmacion; // Cancela el cierre de la ventana principal
    }


    #region COMPROBACIONES

    // Evento de pérdida de enfoque en los controles
    private void NewLostFocus(object sender, RoutedEventArgs e)
    {
        if (sender.Equals(mail)) error[0] = ComprobarMail();
        if (sender.Equals(dniN)) error[1] = ComprobarDni();
        if (sender.Equals(comboBoxLetraDni)) error[1] = ComprobarDni();
        if (sender.Equals(nombre)) error[2] = ComprobarNombre();
        if (sender.Equals(apellido1)) error[3] = ComprobarApellido();
        if (sender.Equals(apellido2)) ComprobarApellido2();
        if (sender.Equals(comboBoxEdad)) error[4] = ComprobarEdad();
    }

    // Método para comprobar el segundo apellido
    private void ComprobarApellido2()
    {
        if (Regex.IsMatch(apellido2.Text, "\\D") || apellido2.Text.Length == 0)
            apellido2.BorderBrush = Brushes.Green;
    }

    // Método para comprobar el DNI
    private bool ComprobarDni()
    {
        if (Regex.IsMatch(dniN.Text, @"^\d{8}$"))
        {
            dniN.BorderBrush = Brushes.Green;

            if (comboBoxLetraDni.SelectedValue is char)
            {
                if ((char)comboBoxLetraDni.SelectedValue == Letras[int.Parse(dniN.Text) % 23])
                {
                    dniLetterCheck.Stroke = Brushes.Green;
                    return false;
                }
                else
                {
                    dniLetterCheck.Stroke = Brushes.Red;
                    return true;
                }
            }
            else
            {
                dniLetterCheck.Stroke = Brushes.Red;
            }
        }
        else
        {
            dniN.BorderBrush = Brushes.Red;
            dniLetterCheck.Stroke = Brushes.Red;
        }

        return true;
    }

    // Método para comprobar la dirección de correo electrónico
    private bool ComprobarMail()
    {
        if (Regex.IsMatch(mail.Text, "([\\w\\.]+)@([\\w\\.]+)\\.(\\w+)"))
        {
            mail.BorderBrush = Brushes.Green;
            return false;
        }

        mail.BorderBrush = Brushes.Red;
        return true;
    }

    // Método para comprobar la edad
    private bool ComprobarEdad()
    {
        if (comboBoxEdad.SelectedIndex != -1)
        {
            edadCheck.Stroke = Brushes.Green;
            return false;
        }

        edadCheck.Stroke = Brushes.Red;
        return true;
    }

    // Método para comprobar el primer apellido
    private bool ComprobarApellido()
    {
        if (Regex.IsMatch(apellido1.Text, "\\D"))
        {
            apellido1.BorderBrush = Brushes.Green;
            return false;
        }

        apellido1.BorderBrush = Brushes.Red;
        return true;
    }

    // Método para comprobar el nombre
    private bool ComprobarNombre()
    {
        if (Regex.IsMatch(nombre.Text, "\\D"))
        {
            nombre.BorderBrush = Brushes.Green;
            return false;
        }

        nombre.BorderBrush = Brushes.Red;
        return true;
    }

    // Método para comprobar todos los campos
    private void comprobarCampos()
    {
        error[0] = ComprobarMail();
        error[1] = ComprobarDni();
        error[2] = ComprobarNombre();
        error[3] = ComprobarApellido();
        ComprobarApellido2();
        error[4] = ComprobarEdad();
    }

    #endregion
}

