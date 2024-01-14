using PROYECTO_EV2_RJT.MODEL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_Warehouse.xaml
    /// </summary>
    public partial class V_Warehouse : Page
    {
        public V_Warehouse()
        {
            InitializeComponent();

            PhoneCollection phones = new PhoneCollection();
            PhonesGrid.ItemsSource = phones;

        }
    }
}
