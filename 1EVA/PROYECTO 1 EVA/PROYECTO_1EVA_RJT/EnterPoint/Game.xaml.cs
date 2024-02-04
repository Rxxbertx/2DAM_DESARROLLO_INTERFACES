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
    public partial class Game : Window // Clase principal del juego
    {
        public DispatcherTimer gameLoopTimer; // Temporizador del juego
        private Stopwatch stopwatch = new Stopwatch(); // Temporizador de precisión alta
        public static double DeltaTime { get; private set; } 


        public static GameManager GameManager { get; private set; } // Gestor de estados del juego

        public Menu Menu; // Menú principal
        public Tutorial Tutorial; // Tutorial
        public Playing Playing; // Juego

        public Taller Taller; // Taller

        public Player Player; // Jugador




        public Game() 
        {
            InitializeComponent(); // Inicializar componentes de la ventana

            InitializeGame(); // Inicializar el juego
        }

        private void InitializeGame()
        {



            GameManager = new(); // Inicializar el gestor de estados
            Sounds.InitMusic(); // Inicializar la música

            gameLoopTimer = new DispatcherTimer // Inicializar game loop timer (temporizador del juego)
            {
                Interval = TimeSpan.FromMilliseconds(1000 / Constantes.FPS) // 60 FPS por defecto
            };
            gameLoopTimer.Tick += GameLoop; // Añadir el evento GameLoop al temporizador
            gameLoopTimer.Start(); // Iniciar el temporizador



            Player = new Player(null, null, null, null, null);
            Menu = new Menu(this);
            Tutorial = new Tutorial(Player, this);
            Taller = new Taller(this);
            Playing = new Playing(Player, this);
            MainFrame.Navigate(Menu); // Navegar al menú principal

        }

        private void GameLoop(object sender, EventArgs e) 
        {

            long elapsedTicks = stopwatch.ElapsedTicks; // Obtener el tiempo transcurrido
            double elapsedSeconds = (double)elapsedTicks / Stopwatch.Frequency; // Convertirlo a segundos

            DeltaTime = elapsedSeconds; // Establecer el tiempo transcurrido como DeltaTime
            stopwatch.Restart(); // Reiniciar el temporizador

            Update(); // Actualizar el juego
            Render(); // Renderizar el juego
        }

        private void Render()
        {

             
            switch (GameManager.State) // Renderizar el estado actual del juego
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
            switch (GameManager.State) // Actualizar el estado actual del juego
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // Evento de cierre de la ventana
        {

            Exit ventanaSalir = new GameStates.Exit(this); // Mostrar ventana de confirmación de salida
            ventanaSalir.ShowDialog(); // Mostrar ventana de confirmación de salida
            if (ventanaSalir.status == 0) // Si se ha pulsado el botón de salir, cerrar la ventana
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
