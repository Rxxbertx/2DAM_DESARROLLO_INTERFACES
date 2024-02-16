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
    /// Lógica de interacción para V_planetas.xaml
    /// </summary>
    public partial class V_planetas : Window
    {

        private VM_planetas vm = new VM_planetas();

        public V_planetas()
        {
            InitializeComponent();
            this.DataContext = vm;
        }


        private void BuscarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (codigop.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }

        }

        private void BuscarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            bool reultado = vm.ReadPlaneta();
            if (reultado)
            {
                MessageBox.Show("Planeta encontrado");
            }
            else
            {
                MessageBox.Show("Planeta no encontrado");
            }


        }

        private void GuardarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (codigop.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }


        }

        private void GuardarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            bool resultado = vm.Guardar();
            if (resultado)
            {
                MessageBox.Show("Planeta guardado");
            }
            else
            {
                bool resultado2 = vm.Crear();

                MessageBox.Show("Planeta no guardado, no existe, se creara uno");

                if (resultado2)
                {
                    MessageBox.Show("Planeta creado");
                }
                else
                {
                    MessageBox.Show("Planeta error creacion");
                }

                
            }

        }

        private void LimpiarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            e.CanExecute = true;




        }

        private void LimpiarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            vm.Limpiar();

        }

    }
}
