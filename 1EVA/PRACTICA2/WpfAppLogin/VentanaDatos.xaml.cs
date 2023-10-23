using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppLogin
{
    /// <summary>
    /// Lógica de interacción para VentanaDatos.xaml
    /// </summary>
    public partial class VentanaDatos : Window
    {
        public VentanaDatos(string mail_, string nombre_, int edad_, string apellido1_, string apellido2_, string dni_, char letraDni_)
        {
            InitializeComponent();
            mail.Text = mail_;
            nombre.Text = nombre_;
            edad.Text = edad_.ToString();
            apellido1.Text = apellido1_;
            apellido2.Text = apellido2_;
            dniN.Text = $"{dni_}-{letraDni_}";
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            // Puedes agregar aquí la lógica para procesar la información si es necesario
            this.Close();
        }

        
    }
}
