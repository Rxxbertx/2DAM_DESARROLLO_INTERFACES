using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppRepasoExamen
{
    /// <summary>
    /// Lógica de interacción para checkBoxesTest.xaml
    /// </summary>
    public partial class checkBoxesTest : Window
    {
        public checkBoxesTest()
        {
            InitializeComponent();
            llamada();


        }
        void llamada()
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres salir?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }
    }
}
