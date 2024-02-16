using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2Eva_RJT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            new VIEW.V_planetas().ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            new VIEW.V_datagrid().ShowDialog();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            new REPORTS.Reporte().ShowDialog();

        }
    }
}