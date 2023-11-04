using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates;
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Diagnostics;
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
        private Stopwatch stopwatch = new Stopwatch();
        public static double DeltaTime { get; private set; }


        public static GameManager GameManager { get; private set; }

        public Menu Menu;
        public Tutorial Tutorial;
        public Playing Playing;

        public Taller Taller;

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
            Taller = new Taller(this);
            Playing = new Playing(Player, this);
            MainFrame.Navigate(Menu);

        }

        private void GameLoop(object sender, EventArgs e)
        {

            long elapsedTicks = stopwatch.ElapsedTicks;
            double elapsedSeconds = (double)elapsedTicks / Stopwatch.Frequency;

            DeltaTime = elapsedSeconds;
            stopwatch.Restart(); // Reiniciar el temporizador

            Update();
            Render();
        }

        private void Render()
        {


            switch (GameManager.State)
            {
                case GameState.MENU:

                    Menu.Render();

                    break;
                case GameState.TUTORIAL:
                    Tutorial.Render();
                    break;
                case GameState.TALLER:
                    Taller.Render();
                    break;
                case GameState.PLAYING:
                    Playing.Render();
                    break;

            }


        }

        public void Update()
        {
            switch (GameManager.State)
            {
                case GameState.MENU:
                    Menu.Update();
                    break;
                case GameState.TUTORIAL:
                    Tutorial.Update();
                    break;
                case GameState.TALLER:
                    Taller.Update();
                    break;
                case GameState.PLAYING:
                    Playing.Update();
                    break;

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Exit ventanaSalir = new GameStates.Exit(this);
            ventanaSalir.ShowDialog();
            if (ventanaSalir.status == 0)
            {
                e.Cancel = false;
            }
            else
            {
                ventanaSalir.Close();
                e.Cancel = true;
            }

        }

    }
}
