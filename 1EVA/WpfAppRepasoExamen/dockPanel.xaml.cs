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

namespace WpfAppRepasoExamen
{
    /// <summary>
    /// Lógica de interacción para dockPanel.xaml
    /// </summary>
    public partial class dockPanel : Window
    {
        public dockPanel()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int num1=0;
            int num2=0;
            int resultado;

            try
            {

                num1 = int.Parse(n1.Text);
                num2= int.Parse(n2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }







            switch (((MenuItem)sender).Header)
            {

                case "Suma":

                    resultado = num1 + num2;
                    nr.Text = resultado.ToString();


                    break;

                case "Resta":

                    resultado = num1 - num2;
                    nr.Text = resultado.ToString();

                    break;

                case "Multiplicacion":

                    resultado = num1 * num2;
                    nr.Text = resultado.ToString();

                    break;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult resultado = MessageBox.Show("Quiers salir?","SALIR",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                this.Close();
            }
          

        }




    }
}
