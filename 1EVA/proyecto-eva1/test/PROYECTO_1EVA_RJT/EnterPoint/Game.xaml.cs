using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates;
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
        private DispatcherTimer gameLoopTimer;
        public static double deltaTime { get; private set; }


        public static GameManager gameManager { get; private set; }

        public GameStates.Menu menu;
        public GameStates.Tutorial tutorial { get; private set; }

        public GameStates.Playing playing;

        public Player player { get; set; }


        public Game()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void InitializeGame()
        {

            gameManager = new();
            player = new Player(null,null,null,null,null);
            menu = new GameStates.Menu(this);
            tutorial = new GameStates.Tutorial(player);
            playing = new GameStates.Playing(this,player);

            

            MainFrame.Navigate(menu);

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(1000 / 30); // 60 FPS por defecto
            gameLoopTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {

            deltaTime = gameLoopTimer.Interval.TotalMilliseconds / 1000.0; // Calcula el delta time
            Update();
            Render();
        }

        private void Render()
        {


            switch (GameManager.state)
            {
                case GameState.MENU:

                    menu.render();

                    break;
                case GameState.TUTORIAL:

                    tutorial.render();

                    break;
                case GameState.PAUSE:
                    // Código para el estado de pausa
                    break;
                case GameState.WIN:
                    // Código para el estado de victoria
                    break;
                case GameState.PLAYING:
                    playing.render();
                    break;
                case GameState.QUIT:
                    // Código para el estado de victoria
                    break;
            }


        }

        public void Update()
        {
            switch (GameManager.state)
            {
                case GameState.MENU:
                    menu.update();
                    break;
                case GameState.TUTORIAL:
                    tutorial.update();
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
