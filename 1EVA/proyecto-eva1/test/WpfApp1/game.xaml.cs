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
        double _playerSize;

        Rectangle _playerRect;
        System.Windows.Vector _playerPosition;

        public game()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeSizes();
            InitializePlayerRect();
        }

        private void InitializeSizes()
        {
            _playerSize = 30;
            Canvas.Width = 2000;
            Canvas.Height = 2000;

            CanvasViewer.Width = 400;
            CanvasViewer.Height = 400;
        }

        private void InitializePlayerRect()
        {
            _playerRect = new Rectangle
            {
                Fill = Brushes.LightPink,
                Width = _playerSize,
                Height = _playerSize,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            Canvas.Children.Add(_playerRect);
            _playerPosition = new System.Windows.Vector(1000, 1000); // Posición inicial en el centro del Canvas
            UpdatePlayerPositionAndCamera();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: MovePlayerLeft(); break;
                case Key.Up: MovePlayerUp(); break;
                case Key.Right: MovePlayerRight(); break;
                case Key.Down: MovePlayerDown(); break;
            }
        }

        private void MovePlayerLeft()
        {
            var newX = _playerPosition.X - _playerSize;
            _playerPosition.X = Math.Max(0, newX);
            UpdatePlayerPositionAndCamera();
        }

        private void MovePlayerUp()
        {
            var newY = _playerPosition.Y - _playerSize;
            _playerPosition.Y = Math.Max(0, newY);
            UpdatePlayerPositionAndCamera();
        }

        private void MovePlayerRight()
        {
            var newX = _playerPosition.X + _playerSize;
            _playerPosition.X = Math.Min(Canvas.Width - _playerSize, newX);
            UpdatePlayerPositionAndCamera();
        }

        private void MovePlayerDown()
        {
            var newY = _playerPosition.Y + _playerSize;
            _playerPosition.Y = Math.Min(Canvas.Height - _playerSize, newY);
            UpdatePlayerPositionAndCamera();
        }

        private void UpdatePlayerPositionAndCamera()
        {
            UpdatePlayerPosition();
            UpdateCamera();
        }

        private void UpdatePlayerPosition()
        {
            _playerRect.Margin = new Thickness(_playerPosition.X, _playerPosition.Y, 0, 0);
        }

        private void UpdateCamera()
        {
            var offsetX = _playerPosition.X - CanvasViewer.Width / 2;
            var offsetY = _playerPosition.Y - CanvasViewer.Height / 2;
            CanvasViewer.ScrollToHorizontalOffset(offsetX);
            CanvasViewer.ScrollToVerticalOffset(offsetY);
        }
    }

}
