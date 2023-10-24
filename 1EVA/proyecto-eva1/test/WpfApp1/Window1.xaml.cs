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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    public partial class Window1 : Window
    {
       
        private DispatcherTimer gameLoopTimer;
        private TextBlock fpsCounter;
        private Stopwatch fpsTimer = new Stopwatch();
        private DateTime lastUpdateTime;
        private DateTime timeMonigoteReachedEnd = DateTime.Now;
        bool toco;
        int contador=0;
        private double deltaTime;
        private Rectangle character;
        private double characterX;
        private double characterY;
        private double moveSpeed = 200; // Pixeles por segundo

        public Window1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            character = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Blue
            };
            gameCanvas.Children.Add(character);
            Canvas.SetLeft(character, (gameCanvas.ActualWidth - character.Width) / 2);
            Canvas.SetTop(character, (gameCanvas.ActualHeight - character.Height) / 2);

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Interval = TimeSpan.FromMicroseconds(1000000 / 60); // 60 FPS por defecto
            gameLoopTimer.Start();

            fpsCounter = FindName("fpsCounter1") as TextBlock;

            fpsTimer.Start();
            lastUpdateTime = DateTime.Now;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            deltaTime = (now - lastUpdateTime).TotalMilliseconds / 1000.0; // Calcula el delta time
            lastUpdateTime = now;

            ProcessInput();
            UpdateGame();
            RenderGame();
            UpdateFPSCounter();
        }

        private void ProcessInput()
        {
            // Maneja la entrada del jugador, como las teclas pulsadas
        }

        private void UpdateGame()
        {
            // Actualiza la lógica del juego, como colisiones, movimientos, etc.
            // Utiliza deltaTime para que las operaciones sean proporcionales al tiempo transcurrido

            // Mueve el personaje en función de moveSpeed y deltaTime
            characterX += moveSpeed * deltaTime;
            if (characterX + character.Width >= gameCanvas.ActualWidth && contador==0)
            {
                toco = true;
            }
        }

        private void RenderGame()
        {
            // Actualiza la representación visual del juego
            character.Margin = new Thickness(characterX, 0, 0, 0);

            // Muestra un mensaje si el monigote ha llegado al extremo de la ventana
            if (toco && contador==0)
            {
                TimeSpan timeElapsed = DateTime.Now - timeMonigoteReachedEnd;
                if (timeElapsed.TotalSeconds > 0)
                {
                    MessageBox.Show($"El monigote llegó al extremo. Tiempo: {timeElapsed.TotalSeconds} segundos", "¡Logro desbloqueado!");
                    contador++;
                }
            }
        }

        private void UpdateFPSCounter()
        {
            var fps = 1.0 / deltaTime;
            fpsCounter.Text = "FPS: " + fps.ToString("F0");
        }
    }

}
