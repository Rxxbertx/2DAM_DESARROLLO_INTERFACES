using System.Windows;

namespace WpfAppLogin;

public partial class VentanaConfirmacionCerrar : Window
{
    public VentanaConfirmacionCerrar()
    {
        InitializeComponent();
    }

    public bool Confirmacion { get; private set; }

    private void Si_Click(object sender, RoutedEventArgs e)
    {
        Confirmacion = true;
        Close();
    }

    private void No_Click(object sender, RoutedEventArgs e)
    {
        Confirmacion = false;
        Close();
    }
}