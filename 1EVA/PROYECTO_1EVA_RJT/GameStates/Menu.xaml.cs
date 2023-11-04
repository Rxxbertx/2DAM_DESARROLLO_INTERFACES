using System.Windows;
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


        public void Update()
        {
            // throw new NotImplementedException();
        }

        public void Render()
        {
            //throw new NotImplementedException();
        }











        //inputs

        private void Jugar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            if (GameManager.PreviousState == GameState.TUTORIAL)
            {
                game.MainFrame.Navigate(game.Tutorial);
                GameManager.ChangeState(GameState.TUTORIAL);
                game.Tutorial.checkHouse();

                return;
            }
            else if (GameManager.PreviousState == GameState.PLAYING)
            {
                game.MainFrame.Navigate(game.Playing);
                GameManager.ChangeState(GameState.PLAYING);

                return;
            }else if (GameManager.PreviousState == GameState.TALLER)
            {

                game.MainFrame.Navigate(game.Taller);
                GameManager.ChangeState(GameState.TALLER);
                return;

            }



            game.MainFrame.Navigate(game.Tutorial);
            GameManager.ChangeState(GameState.TUTORIAL);
            game.Tutorial.checkHouse();
            return;


        }

        private void Salir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            game.Close();

        }



        private void Ayuda_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void Jugar_MouseEnter(object sender, MouseEventArgs e)
        {
            jugar.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void Jugar_MouseLeave(object sender, MouseEventArgs e)
        {
            jugar.Effect = null;
        }

        private void Ayuda_MouseEnter(object sender, MouseEventArgs e)
        {
            ayuda.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void Ayuda_MouseLeave(object sender, MouseEventArgs e)
        {
            ayuda.Effect = null;
        }

        private void Salir_MouseEnter(object sender, MouseEventArgs e)
        {
            salir.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void Salir_MouseLeave(object sender, MouseEventArgs e)
        {
            salir.Effect = null;
        }

        private void SalirX_MouseEnter(object sender, MouseEventArgs e)
        {
            salirX.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void SalirX_MouseLeave(object sender, MouseEventArgs e)
        {
            salirX.Effect = null;
        }


        public void SaveElements()
        {
            throw new System.NotImplementedException();
        }

        public bool LoadElements()
        {
            throw new System.NotImplementedException();
        }

        public void AddElements()
        {
            throw new System.NotImplementedException();
        }

        private void Settings_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            PauseSettings temp = new PauseSettings(game);
            temp.Owner = game;
            temp.ShowDialog();



        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {


            Settings.Effect = new System.Windows.Media.Effects.DropShadowEffect();



        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {


            Settings.Effect = null;

        }
    }
}
