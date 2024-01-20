using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_ProcessorWindow : Window
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse = new();
        private readonly Operation operation = new();
        public VM_Processor? ViewModel;

        private int id = -1;

        public V_ProcessorWindow()
        {
            InitializeComponent();
        }


        public V_ProcessorWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();
            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            InitWindow(v_Warehouse, operation);

        }

        public V_ProcessorWindow(V_Warehouse v_Warehouse, Operation operation, int id)
        {
            InitializeComponent();
            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.id = id;
            InitWindow(v_Warehouse, operation);



        }

        
        private void InitWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));
            Owner = Window.GetWindow(v_Warehouse);
            Owner.Effect = new BlurEffect();

            if (operation == Operation.Add)
            {
                BtnAddOrModify.Content = "Añadir";
                TitleProcessor.Text = "Añadir " + TitleProcessor.Text;
            }
            else if (operation == Operation.Modify)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleProcessor.Text = "Modificar " + TitleProcessor.Text;
            }
            else if (operation == Operation.Delete)
            {
                BtnAddOrModify.Content = "Eliminar";
                TitleProcessor.Text = "Eliminar " + TitleProcessor.Text + " ?";
                txtCores.IsEnabled = false;
                txtGpu.IsEnabled = false;
                txtManufacturer.IsEnabled = false;
                txtName.IsEnabled = false;
                txtNanometers.IsEnabled = false;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        private void Cancel()
        {
            if (v_Warehouse != null)
                Utils.WarningMessage(v_Warehouse.infoTextProcessor, "Operacion Cancelada");

            InputBindings.Clear();
            _ = WindowAnimationUtils.FadeOutAndClose(this);


        }


        #region crud
        private void AddModifyDeleteProcessor_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (ViewModel != null && v_Warehouse != null)
            {


                if (!ViewModel.ValidateInput()) return;


                if (operation == Operation.Add)
                {

                    if (ViewModel.Add())
                    {
                        Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador :" + ViewModel.Processor.ToString() + " Añadido");
                        v_Warehouse.ProcessorsGrid.SelectedItem = ViewModel.Processor;
                        v_Warehouse.ProcessorsGrid.ScrollIntoView(ViewModel.Processor);

                    }else return;
                    

                }
                else if (operation == Operation.Modify)

                {

                    if (ViewModel.Modify(v_Warehouse.ProcessorsGrid.SelectedIndex))
                    {
                        Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador :" + ViewModel.Processor.ToString() + " Actualizado");
                        v_Warehouse.ProcessorsGrid.SelectedItem = ViewModel.Processor;

                    }
                    else return;


                }
                else if (operation == Operation.Delete)
                {

                    if (ViewModel.Delete(v_Warehouse.ProcessorsGrid.SelectedIndex))
                    {
                        Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador :" + ViewModel.Processor.ToString() + " Eliminado");
                        v_Warehouse.ProcessorsGrid.SelectedItem = null;

                    }
                    else return;
                }


                _ = WindowAnimationUtils.FadeOutAndClose(this);
                

            }

            


        }

        private void AddModifyDeleteProcessor_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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

        private void Find()
        {
            if (ViewModel != null)
            {
                if (!ViewModel.Find())
                {
                    Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Procesador no encontrado");
                    _ = WindowAnimationUtils.FadeOutAndClose(this);
                }
            }
        }


        #endregion crud

        #region window events
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.InfoErrorMessage += ShowErrorMessage;
                ViewModel.InfoSuccessMessage += ShowSuccessMessage;
                ViewModel.InfoWarningMessage += ShowWarningMessage;
                ViewModel.CleanOldData();

                if (id != -1 && operation==Operation.Modify ||operation==Operation.Delete)
                {
                    ViewModel.Processor.Id = id;
                    Find();

                }else if (operation != Operation.Add)
                {
                    Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECTACTION");
                    Close();
                }
            }
            else if (v_Warehouse != null)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: NOMODEL");
                Close();
            }
            else
            {

                Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: NOVIEW");
                Close();
            }

        }
        #endregion window events


        #region message events
        private void ShowSuccessMessage(object sender, string successMessage)
        {

            Utils.SuccessMessage(infoTextProcessor, sender + " : " + successMessage);

        }

        private void ShowErrorMessage(object sender, string errorMessage)
        {

            Utils.ErrorMessage(infoTextProcessor, sender + " : " + errorMessage);


        }

        private void ShowWarningMessage(object sender, string warningMessage)
        {

            Utils.WarningMessage(infoTextProcessor, sender + " : " + warningMessage);
        }
        #endregion message events
    }
}
