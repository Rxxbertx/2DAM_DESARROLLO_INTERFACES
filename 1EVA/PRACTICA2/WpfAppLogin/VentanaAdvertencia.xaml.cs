using System.Windows;

namespace WpfAppLogin;

public partial class VentanaAdvertencia : Window
{
    private string mail;
    private string nombre;
    private int edad;
    private string apellido1;
    private string apellido2;
    private string dni;
    private char letraDni;
    private bool success = false;

    public VentanaAdvertencia(string msg)
    {
        InitializeComponent();
        Texto.Text = msg;
    }

    public VentanaAdvertencia(string msg, string mail, string nombre, object edad, string apellido1, string apellido2, string dni, object letraDni) : this(msg)
    {
        this.mail = mail;
        this.nombre = nombre;
        this.edad = (int)edad;
        this.apellido1 = apellido1;
        this.apellido2 = apellido2;
        this.dni = dni;
        this.letraDni = (char)letraDni;
        success = true;
    }

    private void Aceptar_Click(object sender, RoutedEventArgs e)
    {
        Close(); // Cierra la ventana de advertencia al hacer clic en el botón "Aceptar"
       
        if (success)
        {
            new VentanaDatos(mail, nombre, edad, apellido1, apellido2, dni, letraDni).ShowDialog(); // Abre la ventana de datos

        }

    }
}