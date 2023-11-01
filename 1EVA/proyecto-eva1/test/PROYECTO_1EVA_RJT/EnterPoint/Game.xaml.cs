using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates;
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Windows;
using System.Windows.Threading;

namespace PROYECTO_1EVA_RJT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Game : Window
    {
        public  DispatcherTimer gameLoopTimer;
        public static double DeltaTime { get; private set; }


        public static GameManager GameManager { get; private set; }

        public Menu Menu;
        public Tutorial Tutorial;

        public Playing Playing;

        public Player Player;

        


        public Game()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void InitializeGame()
        {


            GameManager = new();
            

            gameLoopTimer = new DispatcherTimer();
            
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS); // 60 FPS por defecto
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();


            
            Player = new Player(null, null, null, null, null);
            Menu = new Menu(this);
            Tutorial = new Tutorial(Player, this);
            Playing = new Playing(this, Player);

            MainFrame.Navigate(Menu);

        }

        private void GameLoop(object sender, EventArgs e)
        {

            DeltaTime = gameLoopTimer.Interval.TotalMilliseconds / 1000; // Calcula el delta time
            Update();
            Render();
        }

        private void Render()
        {


            switch (GameManager.State)
            {
                case GameState.MENU:

                    Menu.render();

                    break;
                case GameState.TUTORIAL:

                    Tutorial.render();

                    break;
                case GameState.PAUSE:
                    // Código para el estado de pausa
                    break;
                case GameState.WIN:
                    // Código para el estado de victoria
                    break;
                case GameState.PLAYING:
                    Playing.render();
                    break;
                case GameState.QUIT:
                    // Código para el estado de victoria
                    break;
            }


        }

        public void Update()
        {
            switch (GameManager.State)
            {
                case GameState.MENU:
                    Menu.update();
                    break;
                case GameState.TUTORIAL:
                    Tutorial.update();
                    break;
                case GameState.PAUSE:
                    // Código para el estado de pausa
                    break;
                case GameState.WIN:
                    // Código para el estado de victoria
                    break;
                case GameState.PLAYING:
                    // playing.Update();
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
