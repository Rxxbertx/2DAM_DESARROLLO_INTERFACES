using System.Windows.Controls;
using System.Windows.Input;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Page, StateMethods
    {

        Game game;
        public Menu(Game game)
        {
            InitializeComponent();
            this.game = game;
        }


        public void update()
        {
            // throw new NotImplementedException();
        }

        public void render()
        {
            //throw new NotImplementedException();
        }











        //inputs

        private void Jugar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            game.tutorial.Focusable = true;
            game.MainFrame.Navigate(game.tutorial);

            GameManager.state = GameState.TUTORIAL;

        }

        private void Salir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ventanaPrinicipal.Effect = new System.Windows.Media.Effects.BlurEffect();
            salir();

        }

        private void salir()
        {
            Exit ventanaSalir = new GameStates.Exit(game);
            ventanaSalir.ShowDialog();
            if (ventanaSalir.status == 0)
            {
                GameManager.state = GameState.QUIT;
            }
            else
            {
                ventanaSalir.Close();
                ventanaPrinicipal.Effect = null;
            }
        }

        private void Ayuda_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            salirX.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }
    }
}
