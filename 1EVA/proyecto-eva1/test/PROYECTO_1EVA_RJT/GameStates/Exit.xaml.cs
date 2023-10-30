using System.Windows;
using System.Windows.Input;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Exit.xaml
    /// </summary>
    public partial class Exit : Window
    {
        public int status { get; private set; }


        public Exit(Game game)
        {
            InitializeComponent();
            this.Owner = game;
        }

        private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            status = 1;
            Close();


        }

        private void Salir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            status = 0;
            Close();

        }


    }
}
