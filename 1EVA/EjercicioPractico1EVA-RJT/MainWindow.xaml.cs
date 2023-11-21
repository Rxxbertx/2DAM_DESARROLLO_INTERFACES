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

            //ts.seconds ts.hours ts.minutes




            // Asegurarse de que los minutos y segundos estén en el rango correcto
            // Calcular horas, minutos y segundos
            int horas = (int)tiempoDecimal;
            int minutos = (int)((tiempoDecimal - horas) * 60);
            int segundos = (int)Math.Round(((tiempoDecimal - minutos) * 60));

            // Ajustar los minutos si los segundos han redondeado a 60
            if (segundos == 60)
            {
                segundos = 0;
                minutos++;
            }

            // Ajustar las horas si los minutos han redondeado a 60
            if (minutos == 60)
            {
                minutos = 0;
                horas++;
            }
            MessageBox.Show($"{horas},{minutos},{segundos}");





        }

    }
}
