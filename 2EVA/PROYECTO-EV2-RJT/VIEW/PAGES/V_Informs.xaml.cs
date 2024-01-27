

using System.Windows;
using System.Windows.Controls;
using CrystalDecisions.CrystalReports.Engine;
using PROYECTO_EV2_RJT.VIEW.WINDOW;

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

        }
        private void Storage_Click(object sender, RoutedEventArgs e)
        {

            
            new ReportsWindow().Show();




        }
        private void Processors_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Brand_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
