using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WpfAppBINDING_TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Persona persona = new Persona("roberto", 12, "PEREZ");

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = persona;
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(persona.Nombre + " tiene la edad de " + persona.Edad + " años");
        }

        private void PuedoNuevo(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;

        }

        private void CommandBinding_Executed_Nuevo(object sender, ExecutedRoutedEventArgs e)
        {

            MessageBox.Show("HOLA");

        }

        private void CommandBinding_Executed_Pegar(object sender, ExecutedRoutedEventArgs e)
        {

            nombreCompleto.Paste();

        }

        private void PuedoPegar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void CommandBinding_Executed_Cortar(object sender, ExecutedRoutedEventArgs e)
        {
            nombreCompleto.Cut();
        }

        private void PuedoCortar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (nombreCompleto != null) && nombreCompleto.SelectionLength > 0;
        }



        private void CommandBinding_Executed_Salir(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PuedoSalir(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_Notificar(object sender, ExecutedRoutedEventArgs e)
        {

            var outPutDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var imagePath = outPutDirectory + "TeamCity_Icon.png";
            var iconPath = outPutDirectory + "Icon_png";

            var content = new ToastContentBuilder()
    .AddText("SUPER APP")
    .AddText("NADA QUE DECIR")
    .AddButton(new ToastButton().SetContent("ACEPTAR"))
    .AddToastInput(new ToastSelectionBox("tiempo")
    {
        DefaultSelectionBoxItemId = "Almuerzo",
        Items =
        {
            new ToastSelectionBoxItem("desayuno", "Desayuno"),
            new ToastSelectionBoxItem("almuerzo", "Almuerzo"),
            new ToastSelectionBoxItem("cena", "Cena")
        }
    })
    .AddHeroImage(new Uri(imagePath));

            var notifier = new ToastNotificationManager().CreateToastNotifier();
            var toast = new ToastNotification(content.GetToastContent());
            notifier.Show(toast);



        }

        private void PuedoNotificar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }




    }
}