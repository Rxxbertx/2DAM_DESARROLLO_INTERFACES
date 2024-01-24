using MySqlConnector;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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



        public static void UpdateDataGridToNextPosition(DataGrid grid, int i)
        {
            if (i > 0)
            {
                grid.SelectedIndex = i - 1;
            }
            else
            {
                grid.SelectedIndex = i;

            }
            if (grid.SelectedIndex != -1)
            {
                grid.ScrollIntoView(grid.SelectedItem);
            }


        }







        public static byte[] ImageToBytes(BitmapSource image)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (MemoryStream stream = new MemoryStream())
            {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        public static BitmapImage BytesToImage(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }



        public static BitmapImage? SelectImage()
        {
            // Crear un cuadro de diálogo para seleccionar archivos
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            // Configurar el cuadro de diálogo para seleccionar imágenes
            dialog.Filter = "Imágenes (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Todos los archivos (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // Mostrar el cuadro de diálogo y obtener el resultado
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                // Si el usuario seleccionó un archivo, cargar la imagen
                var image = new BitmapImage(new Uri(dialog.FileName));
                return image;
            }
            else
            {
                // Si el usuario canceló el cuadro de diálogo, devolver null
                return null;
            }
        }


    }

    public static class WindowAnimationUtils
    {
        public static void FadeIn(Window window)
        {
            DoubleAnimation opacityAnimation = new()
            {
                From = 0.0,
                To = 1.0,
                Duration = AnimationConstants.FadeInDuration
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);

            Storyboard.SetTarget(opacityAnimation, window);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            storyboard.Begin();
        }

        public static async Task FadeOutAndClose(Window window)
        {
            DoubleAnimation opacityAnimation = new()
            {
                From = 1.0,
                To = 0.0,
                Duration = AnimationConstants.FadeOutDuration
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);

            Storyboard.SetTarget(opacityAnimation, window);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            storyboard.Begin();

            // Espera a que la animación se complete antes de continuar
            await Task.Delay(AnimationConstants.FadeOutDuration);

            window.Close();
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
            DoubleAnimation fadeOutAnimation = new()
            {
                From = 1.0,
                To = 0.0,
                Duration = AnimationConstants.FadeOutDuration
            };

            // Create a Storyboard and add the fade out animation
            Storyboard storyboard = new();
            storyboard.Children.Add(fadeOutAnimation);

            // Set the target of the fade out animation to the current page
            Storyboard.SetTarget(fadeOutAnimation, currentPage);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the fade out animation
            storyboard.Begin();

            // Wait for the fade out animation to complete
            Task.Delay(AnimationConstants.FadeOutDuration);



            // Create a DoubleAnimation to fade in the next page
            DoubleAnimation fadeInAnimation = new()
            {
                From = 0.0,
                To = 1.0,
                Duration = AnimationConstants.FadeInDuration
            };

            // Create a Storyboard and add the fade in animation
            storyboard = new();
            storyboard.Children.Add(fadeInAnimation);

            // Set the target of the fade in animation to the next page
            Storyboard.SetTarget(fadeInAnimation, nextPage);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the fade in animation
            storyboard.Begin();
        }
    }

    public static class DBUtils
    {
        public static void CheckStatusOperation(Action<string, string> errorAction, Action<string, string> successAction, Action<string, string> infoAction, int result, string name)
        {
            if (result == DBConstants.REGISTER_NOT_UPDATED)
            {

                errorAction?.Invoke("Error Interno", $"No se ha podido actualizar el {name}");
            }
            else if (result == DBConstants.REGISTER_UPDATED)
            {

                successAction?.Invoke("Info", $"{name} Actualizado");
            }


            else if (result == DBConstants.REGISTER_ADDED)
            {

                successAction?.Invoke("Info", $"{name} Añadido");
            }
            else if (result == DBConstants.REGISTER_NOT_ADDED)
            {

                errorAction?.Invoke("Error Interno", $"No se ha podido añadir el {name}");
            }

            else if (result == DBConstants.REGISTER_FOUNDED)
            {
                infoAction?.Invoke("Error Interno", $"{name} ya existe");

            }
            else if (result == DBConstants.REGISTER_NOT_FOUND)
            {
                errorAction?.Invoke("Error Interno", $"{name} no existe");
            }

            else if (result == DBConstants.SQL_EXCEPTION)
            {

                errorAction?.Invoke("Error Interno", "Intentalo de nuevo mas tarde");

            }
            else if (result == DBConstants.REGISTER_NOT_DELETED)
            {
                errorAction?.Invoke("Error Interno", $"No se ha podido eliminar el {name}");
            }
            else if (result == DBConstants.REGISTER_DELETED)
            {
                successAction?.Invoke("Info", $"{name} Eliminado");
            }
            else if (result == ((int)MySqlErrorCode.RowIsReferenced2))
            {

                errorAction?.Invoke("Error Interno", $"No se puede eliminar el {name} porque esta siendo usado");
            }
            else if (IsMySQLIntegrityError(result))
            {
                HandleIntegrityError(result, errorAction, name);
            }





        }


        private static bool IsMySQLIntegrityError(int errorCode)
        {
            return Enum.IsDefined(typeof(MySqlErrorCode), errorCode);
        }

        private static void HandleIntegrityError(int errorCode, Action<string, string> errorAction, string name)
        {
            MySqlErrorCode mysqlErrorCode = (MySqlErrorCode)errorCode;

            switch (mysqlErrorCode)
            {
                case MySqlErrorCode.RowIsReferenced2:
                    errorAction?.Invoke("Error Interno", $"No se puede eliminar el {name} porque está siendo usado");
                    break;
                case MySqlErrorCode.DuplicateEntryWithKeyName:
                    errorAction?.Invoke("Error Interno", $"Ya existe un registro con el mismo valor para {name}");
                    break;
                case MySqlErrorCode.CannotAddForeignConstraint:
                    errorAction?.Invoke("Error Interno", $"No se puede agregar el {name} porque violaría la restricción de clave externa");
                    break;

                case MySqlErrorCode.DataTooLong:
                    errorAction?.Invoke("Error Interno", $"La longitud de los datos para {name} es demasiado larga");
                    break;
                case MySqlErrorCode.NoReferencedRow2:
                    errorAction?.Invoke("Error Interno", $"No hay fila referenciada para actualizar o eliminar en {name}");
                    break;



                case MySqlErrorCode.CannotCreateTable:
                    errorAction?.Invoke("Error Interno", $"No se puede crear la tabla {name}");
                    break;

                case MySqlErrorCode.InvalidUseOfNull:
                    errorAction?.Invoke("Error Interno", $"Uso inválido de NULL en {name}");
                    break;
                case MySqlErrorCode.UnableToConnectToHost:
                    errorAction?.Invoke("Error Interno", $"No se puede conectar al host de la base de datos");
                    break;
                case MySqlErrorCode.TableNameErrror:
                    errorAction?.Invoke("Error Interno", $"No se encuentra la tabla {name}");
                    break;
                case MySqlErrorCode.CannotCreateDatabase:
                    errorAction?.Invoke("Error Interno", $"No se puede crear la base de datos {name}");
                    break;

                case MySqlErrorCode.DataOutOfRange:
                    errorAction?.Invoke("Error Interno", $"Datos fuera de rango en {name}");
                    break;

                case MySqlErrorCode.HostNotPrivileged:
                    errorAction?.Invoke("Error Interno", $"El host no está permitido para la conexión");
                    break;
                case MySqlErrorCode.DuplicateKeyEntry:
                    errorAction?.Invoke("Error Interno", $"Entrada de clave duplicada para {name}");
                    break;
                case MySqlErrorCode.InvalidDefault:
                    errorAction?.Invoke("Error Interno", $"Valor predeterminado no válido para {name}");
                    break;

                case MySqlErrorCode.DivisionByZero:
                    errorAction?.Invoke("Error Interno", $"División por cero al operar en {name}");
                    break;
                case MySqlErrorCode.TooManyUserConnections:
                    errorAction?.Invoke("Error Interno", $"Demasiadas conexiones a la base de datos");
                    break;
                case MySqlErrorCode.LockWaitTimeout:
                    errorAction?.Invoke("Error Interno", $"Tiempo de espera de bloqueo agotado al intentar acceder a {name}");
                    break;
                case MySqlErrorCode.NonUnique:
                    errorAction?.Invoke("Error Interno", $"Valores no únicos en índice para {name}");
                    break;
                case MySqlErrorCode.DropIndexForeignKey:
                    errorAction?.Invoke("Error Interno", $"No se puede eliminar la columna referenciada por una clave externa en {name}");
                    break;
                case MySqlErrorCode.DuplicateUnique:
                    errorAction?.Invoke("Error Interno", $"Valor duplicado en columna única para {name}");
                    break;
                case MySqlErrorCode.WrongColumnName:
                    errorAction?.Invoke("Error Interno", $"Columna desconocida en {name}");
                    break;
                case MySqlErrorCode.UnknownTable:
                    errorAction?.Invoke("Error Interno", $"Tabla desconocida {name}");
                    break;

                case MySqlErrorCode.WarningDataTruncated:
                    errorAction?.Invoke("Error Interno", $"Datos truncados al insertar o actualizar en {name}");
                    break;
                case MySqlErrorCode.CannotCreateFile:
                    errorAction?.Invoke("Error Interno", $"No se puede crear el archivo para {name}");
                    break;

                case MySqlErrorCode.CannotDropFieldOrKey:
                    errorAction?.Invoke("Error Interno", $"No se puede eliminar el campo o clave en {name}");
                    break;

                default:
                    errorAction?.Invoke("Error Desconocido", $"Error de integridad no manejado: {mysqlErrorCode}");
                    break;
            }
        }


    }
}
