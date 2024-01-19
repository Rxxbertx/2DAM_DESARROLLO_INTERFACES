using System.Windows.Controls;
using System.Windows.Input;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_HomePage.xaml
    /// </summary>
    public partial class V_Home : Page
    {

        public V_MainWindow? parentWindow;

        public V_Home()
        {
            InitializeComponent();


        }

        private void WareHouse_Click(object sender, MouseButtonEventArgs e)
        {



            if (parentWindow != null) parentWindow.warehouse.IsChecked = true;



        }

        private void Informs_Click(object sender, MouseButtonEventArgs e)
        {

            if (parentWindow != null) parentWindow.informs.IsChecked = true;


        }
        private void Help_Click(object sender, MouseButtonEventArgs e)
        {

            if (parentWindow != null) parentWindow.help.IsChecked = true;


        }
        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {

            if (parentWindow != null) parentWindow.exit.IsChecked = true;


        }
    }
}
