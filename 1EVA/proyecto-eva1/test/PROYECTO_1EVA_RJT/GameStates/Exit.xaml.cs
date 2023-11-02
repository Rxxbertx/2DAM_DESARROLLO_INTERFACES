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

        Game game;

        public Exit(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.Owner = game;
            game.MainFrame.Effect = new System.Windows.Media.Effects.BlurEffect();
            game.Player.TurnOff();
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

        private void cerrarX_MouseLeave(object sender, MouseEventArgs e)
        {



            cerrarX.Effect = null;



        }

        private void cerrarX_MouseEnter(object sender, MouseEventArgs e)
        {
            cerrarX.Effect = new System.Windows.Media.Effects.DropShadowEffect();
        }

        private void No_MouseEnter(object sender, MouseEventArgs e)
        {

            No.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void No_MouseLeave(object sender, MouseEventArgs e)
        {

            No.Effect = null;
        }

        private void Si_MouseEnter(object sender, MouseEventArgs e)
        {

            Si.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void Si_MouseLeave(object sender, MouseEventArgs e)
        {

            Si.Effect = null;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            
            
            game.MainFrame.Effect = null;
            game.Player.TurnOn();
            

        }
    }
}
