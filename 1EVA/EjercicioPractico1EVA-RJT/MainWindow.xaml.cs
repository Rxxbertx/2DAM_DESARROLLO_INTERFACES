using System;

using System.Windows;

namespace EjercicioPractico1EVA_RJT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //al hacer click en el boton calcular se ejecuta el codigo
        private void calcular_Click(object sender, RoutedEventArgs e)
        {

            //calcular el tiempo en funcion de la distancia y el medio de transporte seleccionado
            
            decimal distanciaDecimal;
            double tiempoDecimal;
            

            if (!decimal.TryParse(distancia.Text, out distanciaDecimal))
                
            {
                MessageBox.Show("La distancia debe ser un número");
                return;
            }



            distanciaDecimal = Decimal.Round(distanciaDecimal, 2);

          

            if (andando.IsChecked == true)
            {

                tiempoDecimal = (double)distanciaDecimal / constantes.VELOCIDAD_ANDANDO;

            }
            else if (patinete.IsChecked == true)
            {
                tiempoDecimal = (double)distanciaDecimal / constantes.VELOCIDAD_PATINETE;
                
            }
            else if (bicicleta.IsChecked == true)
            {
                tiempoDecimal = (double)distanciaDecimal / constantes.VELOCIDAD_BICICLETA;
               
            }
            else if (coche.IsChecked == true)
            {
                tiempoDecimal = (double)distanciaDecimal / constantes.VELOCIDAD_COCHE;
                
            }
            else
            {
                MessageBox.Show("Selecciona un medio de transporte");
                return;

            }



            //aqui se muestra el tiempo en formato horas:minutos:segundos

             TimeSpan ts = TimeSpan.FromHours(tiempoDecimal);
            tiempoText.Text = string.Format("TIEMPO HORAS:MINUTOS:SEGUNDOS: {0}", new DateTime(ts.Ticks).ToString("HH:mm:ss"));




        }

    }
}
