using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }

        private void comprobarGameState()
        {
           

            if(GameManager.State == GameState.MENU)
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

        }

        private void _30fps_Checked(object sender, RoutedEventArgs e)
        {
            Constantes.FPS = 30;
            game.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS);
        }

        private void _120fps_Checked(object sender, RoutedEventArgs e)
        {
            Constantes.FPS = 120;
            game.gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS);
        }



        private void Cerrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Close();
            



        }   

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GameManager.State = GameState.MENU;
            game.MainFrame.NavigationService.Navigate(game.Menu);
            
            Close();
        }


        private void SoundImageOn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            SoundImageOn.Visibility = Visibility.Hidden;
            SoundImageOff.Visibility = Visibility.Visible;

        }

        private void SoundImageOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            SoundImageOn.Visibility = Visibility.Visible;
            SoundImageOff.Visibility = Visibility.Hidden;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            game.MainFrame.Effect = null;
            game.Player.TurnOn();
            
        }
    }
}
