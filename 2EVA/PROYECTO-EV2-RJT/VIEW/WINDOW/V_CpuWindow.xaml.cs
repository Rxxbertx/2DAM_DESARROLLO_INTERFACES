using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_CpuWindow : Window
    {
        private ExitCommand ExitCommand => new ExitCommand(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;

        public V_CpuWindow()
        {
            InitializeComponent();
        }

        public V_CpuWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();

            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            Owner = Window.GetWindow(v_Warehouse);
            Owner.Effect = new BlurEffect();

            if (operation == Operation.Add)
            {
                BtnAddOrModify.Content = "Añadir";
                Title.Text = "Añadir " + Title.Text;
            }
            if (operation == Operation.Modify)
            {
                BtnAddOrModify.Content = "Modificar";
                Title.Text = "Modificar " + Title.Text;
            }

            
            

        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

            if(DataContext != null)
                ((VM_Processor)DataContext).Processor = null;
                

        }

        private void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Operacion Cancelada");
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }

        private void AddModifyProcessor_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (DataContext != null) {

                if (v_Warehouse == null)
                {
                    Utils.ErrorMessage(infoTextProcessor, "Error Interno");
                    return;
                }

                if (!CheckInputFields()) return;

                if (operation == Operation.Add) {

                    
                
                    int i = ((VM_Processor)DataContext).AddProcessor();

                    if (i == DBConstants.REGISTER_ADDED)
                    {
                        Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Procesador Añadido");
                        Close();
                        return;
                    }
                    else if (i == DBConstants.REGISTER_NOT_ADDED)
                    {
                        Utils.ErrorMessage(infoTextProcessor, "Error Interno, No se ha podido añadir el procesador");
                        return;
                    }
                    else if (i == DBConstants.REGISTER_FOUNDED)
                    {
                        Utils.ErrorMessage(infoTextProcessor, "Error Interno, El procesador ya existe");
                        return;
                    }
                    else if (i == DBConstants.SQL_EXCEPTION)
                    {
                        Utils.ErrorMessage(infoTextProcessor, "Error Interno, Intentelo de nuevo mas tarde");
                        return;
                    }
                    else
                    {
                        Utils.ErrorMessage(infoTextProcessor, "Error Interno, CODIGO: "+i);
                    }
                
                };


            }
            else
            {
                Utils.ErrorMessage(infoTextProcessor, "Error Interno, No se ha podido establecer la conexion");
            }




        }


        private void AddModifyProcessor_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (
                string.IsNullOrEmpty(txtCores.Text) ||
                string.IsNullOrEmpty(txtGpu.Text) ||
                string.IsNullOrEmpty(txtManufacturer.Text) ||
                string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtNanometers.Text))

            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
            return;


        }
    }
}
