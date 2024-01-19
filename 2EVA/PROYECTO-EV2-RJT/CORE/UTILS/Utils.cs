using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PROYECTO_EV2_RJT.CORE.UTILS
{
    public static class Utils
    {
        private static CancellationTokenSource? messageCancellation;

        public static void ShowMessage(TextBlock textBlock, string message, Brush foreground, int seconds)
        {
            if (messageCancellation != null)
            {
                // Cancela el temporizador anterior
                messageCancellation.Cancel();
            }

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



    }
}
