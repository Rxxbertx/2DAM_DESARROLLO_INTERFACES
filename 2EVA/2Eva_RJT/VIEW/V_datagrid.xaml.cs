using _2Eva_RJT.VIEWMODEL;
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

namespace _2Eva_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_datagrid.xaml
    /// </summary>
    public partial class V_datagrid : Window
    {

        private VM_datagrid viewmodel = new VM_datagrid();


        public V_datagrid()
        {
            InitializeComponent();
            

        }

    }
}
