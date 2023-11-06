using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Pause.xaml
    /// </summary>
    public partial class PauseSettings : Window
    {


        Game game;

        public PauseSettings(Game game)
        {
            InitializeComponent();
            volumeSlider.Value = Constantes.SoundLvl;
            this.game = game;
            this.Owner = game;
            game.MainFrame.Effect = new System.Windows.Media.Effects.BlurEffect();
            game.Player.TurnOff();
            comprobarFPS();
            comprobarSonido();
            comprobarGameState();

        }

        private void comprobarSonido()
        {
            volumeSlider.Value = Constantes.SoundLvl;

            if (!Constantes.MUTED)
            {
                SoundImageOn.Visibility = Visibility.Visible;
                SoundImageOff.Visibility = Visibility.Hidden;
            }
            else
            {
                SoundImageOn.Visibility = Visibility.Hidden;
                SoundImageOff.Visibility = Visibility.Visible;
                
            }

            Sounds.UpdateMusic();


        }

        private void comprobarGameState()
        {


            if (GameManager.State == GameState.MENU)
            {
                slrMenu.Visibility = Visibility.Hidden;
                slrMenu0.Visibility = Visibility.Hidden;

            }



        }

        private void comprobarFPS()
        {


            switch (Constantes.FPS)
            {

                case 30:
                    _30fps.IsChecked = true;
                    break;
                case 60:
                    _60fps.IsChecked = true;
                    break;
                case 120:
                    _120fps.IsChecked = true;
                    break;
                default:
                    break;
            }

        }

        private void _60fps_Checked(object sender, RoutedEventArgs e)
        {
            Constantes.FPS = 60;
            game.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS);
            Sounds.boton.Play();

        }

        private void _30fps_Checked(object sender, RoutedEventArgs e)
        {
            Constantes.FPS = 30;
            game.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS);
            Sounds.boton.Play();
        }

        private void _120fps_Checked(object sender, RoutedEventArgs e)
        {
            Constantes.FPS = 120;
            game.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS);
            Sounds.boton.Play();
        }



        private void Cerrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sounds.boton.Play();
            Close();




        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GameManager.ChangeState(GameState.MENU);
            game.MainFrame.NavigationService.Navigate(game.Menu);
            game.Menu.playMusic();
            Sounds.boton.Play();
            Close();
        }


        private void SoundImageOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            SoundImageOn.Visibility = Visibility.Hidden;
            SoundImageOff.Visibility = Visibility.Visible;
            Constantes.MUTED = true;
            Sounds.boton.Play();
            comprobarSonido();

        }

        private void SoundImageOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            SoundImageOn.Visibility = Visibility.Visible;
            SoundImageOff.Visibility = Visibility.Hidden;
            Constantes.MUTED = false;
            Sounds.boton.Play();
            comprobarSonido();

        }



        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Ajusta el volumen en función del valor del Slider
            

            Constantes.SoundLvl = volumeSlider.Value;

            Sounds.UpdateMusic();

        }





        private void cerrarX_MouseLeave(object sender, MouseEventArgs e)
        {



            cerrarX.Effect = null;



        }

        private void cerrarX_MouseEnter(object sender, MouseEventArgs e)
        {
            cerrarX.Effect = new System.Windows.Media.Effects.DropShadowEffect();
        }



        private void cerrar_MouseLeave(object sender, MouseEventArgs e)
        {



            btnCerrar.Effect = null;



        }

        private void cerrar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCerrar.Effect = new System.Windows.Media.Effects.DropShadowEffect();
        }




        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {



            slrMenu0.Effect = null;



        }

        private void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            slrMenu0.Effect = new System.Windows.Media.Effects.DropShadowEffect();
        }
















        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            game.MainFrame.Effect = null;
            game.Player.TurnOn();

        }
    }
}
