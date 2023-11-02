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
            
            game.MainFrame.Navigate(game.Tutorial);

            GameManager.State = GameState.TUTORIAL;

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


        public void saveElements()
        {
            throw new System.NotImplementedException();
        }

        public bool loadElements()
        {
            throw new System.NotImplementedException();
        }

        public void addElements()
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
