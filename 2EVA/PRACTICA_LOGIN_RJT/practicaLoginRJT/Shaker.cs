using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ShakeAnimationExample
{
    public class Shaker
    {
        private UIElement element;
        private Thickness originalMargin;

        public Shaker(UIElement element)
        {
            this.element = element;
            InitializeShakeAnimation();
        }

        private void InitializeShakeAnimation()
        {
            // Guardar el margen original del objeto
            originalMargin = new Thickness(0);
        }

        public void Shake()
        {
            const int numberOfShakes = 10;
            const double shakeDistance = 10;

            // Crear una animación de vaivén para el margen izquierdo
            ThicknessAnimation shakeAnimation = new ThicknessAnimation
            {
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(numberOfShakes),
                Duration = TimeSpan.FromMilliseconds(100),
                AccelerationRatio = 0.2, // Ajustar según sea necesario
                From = new Thickness(originalMargin.Left - shakeDistance, 0, 0, 0),
                To = new Thickness(originalMargin.Left + shakeDistance, 0, 0, 0),
            };

            // Manipular el objeto mediante ThicknessAnimation para simular el efecto de temblor
            shakeAnimation.Completed += (sender, e) =>
            {
                // Restaurar el margen original con otra animación
                ThicknessAnimation restoreAnimation = new ThicknessAnimation
                {
                    Duration = TimeSpan.FromMilliseconds(0), // Sin duración para aplicar instantáneamente
                    To = originalMargin
                };

                (element as FrameworkElement)?.BeginAnimation(FrameworkElement.MarginProperty, restoreAnimation);
            };

            (element as FrameworkElement)?.BeginAnimation(FrameworkElement.MarginProperty, shakeAnimation);
        }
    }
}

