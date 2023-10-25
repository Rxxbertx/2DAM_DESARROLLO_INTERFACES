using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public class Camera
    {
        private double xLvlOffset;
        private double leftBorder;
        private double rightBorder;
        private double maxLvlOffsetX;

        public Camera(double leftBorder, double rightBorder, double maxLvlOffsetX)
        {
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.maxLvlOffsetX = maxLvlOffsetX;
        }

        public void Update(double playerX)
        {
            double diff = playerX - xLvlOffset;

            if (diff > rightBorder)
            {
                xLvlOffset += diff - rightBorder;
            }
            else if (diff < leftBorder)
            {
                xLvlOffset += diff - leftBorder;
            }

            if (xLvlOffset > maxLvlOffsetX)
            {
                xLvlOffset = maxLvlOffsetX;
            }
            else if (xLvlOffset < 0)
            {
                xLvlOffset = 0;
            }
        }

        public double GetCameraOffset()
        {
            return -xLvlOffset;
        }
    }


}
