using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public class Player
    {
        private double x;
        private double y;
        private double speed = 5;
        private System.Windows.Shapes.Rectangle playerRect;

        public double X => x;
        public double Y => y;

        public Player(System.Windows.Shapes.Rectangle playerRect)
        {
            this.playerRect = playerRect;
            x = Canvas.GetLeft(playerRect);
            y = Canvas.GetTop(playerRect);
        }

        public void Update()
        {
            Canvas.SetLeft(playerRect, x);
            Canvas.SetTop(playerRect, y);
        }

        public void HandleInput(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    y -= speed;
                    break;
                case Key.Down:
                    y += speed;
                    break;
                case Key.Left:
                    x -= speed;
                    break;
                case Key.Right:
                    x += speed;
                    break;
            }
        }
    }
}
