using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Application = System.Windows.Application;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_ExitWindow.xaml
    /// </summary>
    public partial class V_Exit : Page
    {
        public V_Exit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try { NavigationService.GoBack(); }
            catch (Exception)
            {

                NavigationService.Navigate(new V_Home());



            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }
    }
}
