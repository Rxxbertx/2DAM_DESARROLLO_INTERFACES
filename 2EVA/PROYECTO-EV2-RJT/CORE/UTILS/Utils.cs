using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PROYECTO_EV2_RJT.CORE.UTILS
{
    public static class Utils
    {
        private static CancellationTokenSource? messageCancellation;

        public static void ShowMessage(TextBlock textBlock, string message, Brush foreground, int seconds)
        {

            messageCancellation?.Cancel();


            messageCancellation = new CancellationTokenSource();
            ShowMessageForSeconds(textBlock, message, foreground, seconds, messageCancellation.Token);
        }

        private static async void ShowMessageForSeconds(TextBlock textBlock, string message, Brush foreground, int seconds, CancellationToken cancellationToken)
        {
            textBlock.Text = message;
            textBlock.Foreground = foreground;
            textBlock.Visibility = System.Windows.Visibility.Visible;

            try
            {
                // Espera el tiempo especificado antes de ocultar el mensaje
                await Task.Delay(TimeSpan.FromSeconds(seconds), cancellationToken);
                textBlock.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (TaskCanceledException)
            {


            }
            finally
            {


            }
        }

        public static void SuccessMessage(TextBlock textBlock, string message)
        {
            ShowMessage(textBlock, message, Brushes.Green, 5);
        }

        public static void ErrorMessage(TextBlock textBlock, string message)
        {
            ShowMessage(textBlock, message, Brushes.Red, 5);
        }

        public static void WarningMessage(TextBlock textBlock, string message)
        {
            ShowMessage(textBlock, message, Brushes.Orange, 5);
        }



    }

    public static class WindowAnimationUtils
    {
        public static async Task FadeIn(Window window, double durationInSeconds)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(durationInSeconds)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);

            Storyboard.SetTarget(opacityAnimation, window);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            storyboard.Begin();
        }

        public static async Task FadeOut(Window window, double durationInSeconds)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(durationInSeconds)
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);

            Storyboard.SetTarget(opacityAnimation, window);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            storyboard.Begin();

            // Espera a que la animación se complete antes de continuar
            await Task.Delay(TimeSpan.FromSeconds(durationInSeconds));
        }

    }

    public static class PageNavigationUtils
    {
        public static void NavigateWithFadeOut(Page currentPage, Page nextPage)
        {
            if (currentPage == null || nextPage == null)
            {
                return;
            }
            // Create a DoubleAnimation to fade out the current page
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = AnimationConstants.FadeOutDuration
            };

            // Create a Storyboard and add the fade out animation
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeOutAnimation);

            // Set the target of the fade out animation to the current page
            Storyboard.SetTarget(fadeOutAnimation, currentPage);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the fade out animation
            storyboard.Begin();

            // Wait for the fade out animation to complete
            Task.Delay(AnimationConstants.FadeOutDuration);

         

            // Create a DoubleAnimation to fade in the next page
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = AnimationConstants.FadeOutDuration
            };

            // Create a Storyboard and add the fade in animation
            storyboard = new Storyboard();
            storyboard.Children.Add(fadeInAnimation);

            // Set the target of the fade in animation to the next page
            Storyboard.SetTarget(fadeInAnimation, nextPage);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the fade in animation
            storyboard.Begin();
        }
    }
}
