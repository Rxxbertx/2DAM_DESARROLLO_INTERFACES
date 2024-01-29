

using System.Windows;
using System.Windows.Controls;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_Informs.xaml
    /// </summary>
    public partial class V_Informs : Page
    {
        

        public V_Informs()
        {
            InitializeComponent();
        }


        private void Phones_Click(object sender, RoutedEventArgs e)
        {

            new REPORTS.Reports("PhoneReport") { Owner = Window.GetWindow(this) }.ShowDialog();



        }
        private void Storage_Click(object sender, RoutedEventArgs e)
        {


            new REPORTS.Reports("StorageReport") { Owner = Window.GetWindow(this) }.ShowDialog();



        }
        private void Processors_Click(object sender, RoutedEventArgs e)
        {

            new REPORTS.Reports("ProcessorReport") { Owner = Window.GetWindow(this) }.ShowDialog();



        }
        private void Brand_Click(object sender, RoutedEventArgs e)
        {

            new REPORTS.Reports("BrandsReport") { Owner = Window.GetWindow(this) }.ShowDialog();

        }


    }
}
