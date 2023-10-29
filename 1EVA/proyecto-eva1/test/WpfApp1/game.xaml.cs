using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Lógica de interacción para game.xaml
    /// </summary>
    public partial class game : Window
    {

        private double playerX;
        private double playerY;
        private double canvas1Width;
        private double canvas1Height;
        private double canvas2Width;
        private double canvas2Height;
        private double viewportWidth;
        private double viewportHeight;
        private TranslateTransform cameraTransformCanvas1 = new TranslateTransform();
        private TranslateTransform cameraTransformCanvas2 = new TranslateTransform();
        private bool isMoving = false;

        public game()
        {
            InitializeComponent();

            // Obtiene el tamaño de Canvas 1 (el principal)
            canvas1Width = canvas1.Width;
            canvas1Height = canvas1.Height;

            // Obtiene el tamaño de Canvas 2 (donde se encuentra el rectángulo)
            canvas2Width = canvas2.Width;
            canvas2Height = canvas2.Height;


            // Inicializa al jugador en el centro de Canvas 2
            playerX = (canvas2Width - player.Width) / 2;
            playerY = (canvas2Height - player.Height) / 2;

            // Posiciona al jugador en Canvas 2
            Canvas.SetLeft(player, playerX);
            Canvas.SetTop(player, playerY);

            canvas1.RenderTransform = cameraTransformCanvas1;
            canvas2.RenderTransform = cameraTransformCanvas2;
            CompositionTarget.Rendering += UpdateGame;

            // Agrega el manejo de eventos para las teclas
            KeyDown += MainWindow_KeyDown;
            KeyUp += MainWindow_KeyUp;
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            if (isMoving)
            {
                double playerSpeed = 5;
                double deltaX = 0;
                double deltaY = 0;

                // Mueve al jugador en función de la dirección
                if (Keyboard.IsKeyDown(Key.W) && playerY > 0)
                {
                    deltaY -= playerSpeed;
                }
                if (Keyboard.IsKeyDown(Key.S) && playerY + player.ActualHeight < canvas2Height)
                {
                    deltaY += playerSpeed;
                }
                if (Keyboard.IsKeyDown(Key.A) && playerX > 0)
                {
                    deltaX -= playerSpeed;
                }
                if (Keyboard.IsKeyDown(Key.D) && playerX + player.ActualWidth < canvas2Width)
                {
                    deltaX += playerSpeed;
                }

                // Calcula la posición del jugador en relación con los bordes de Canvas 2
                double playerRight = playerX + player.ActualWidth;
                double playerBottom = playerY + player.ActualHeight;

                // Comprueba si el jugador está cerca del 80% de Canvas 1
                if (playerX < canvas1Width * 0.2 || playerRight > canvas1Width * 0.8
                    || playerY < canvas1Height * 0.2 || playerBottom > canvas1Height * 0.8)
                {
                    // Mueve Canvas 2 en lugar del jugador (ajustando la transformación de Canvas 2)
                    cameraTransformCanvas2.X -= deltaX;
                    cameraTransformCanvas2.Y -= deltaY;
                }
                else
                {
                    // Mueve al jugador libremente dentro de Canvas 2
                    playerX += deltaX;
                    playerY += deltaY;
                    Canvas.SetLeft(player, playerX);
                    Canvas.SetTop(player, playerY);
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            isMoving = true;
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            isMoving = false;
        }



    }

}
