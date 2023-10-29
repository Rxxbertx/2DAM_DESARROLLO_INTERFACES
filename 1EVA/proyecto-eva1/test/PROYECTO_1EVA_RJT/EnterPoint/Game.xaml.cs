using PROYECTO_1EVA_RJT.GameStates;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PROYECTO_1EVA_RJT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        private DispatcherTimer gameLoopTimer;

        GameStates.Menu menu;

        public Game()
        {
            InitializeComponent();
            
            InitializeGame();
        }

        private void InitializeGame()
        {

            menu = new GameStates.Menu(this);
            MainFrame.Navigate(menu);

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / 60); // 60 FPS por defecto
            gameLoopTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            double deltaTime = gameLoopTimer.Interval.TotalMilliseconds / 1000.0; // Calcula el delta time

            Update(deltaTime);
            Render();
        }

        private void Render()
        {
            // throw new NotImplementedException();
        }

        public void Update(double deltaTime)
        {
            switch (GameManager.state)
            {
                case GameState.MENU:
                    // menu.Update();
                    break;
                case GameState.PAUSE:
                    // Código para el estado de pausa
                    break;

                    break;
                case GameState.WIN:
                    // Código para el estado de victoria
                    break;
                case GameState.PLAYING:
                    // playing.Update();
                    break;
                case GameState.QUIT:

                    Close();

                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MainFrame.Effect = new System.Windows.Media.Effects.BlurEffect();
            Exit ventanaSalir = new GameStates.Exit(this);
            ventanaSalir.ShowDialog();
            if (ventanaSalir.status == 0)
            {
                e.Cancel = false;
            }
            else
            {
                ventanaSalir.Close();
                MainFrame.Effect = null;
                e.Cancel = true;
            }

        }

    }
}
