using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_ProcessorWindow : Window, IWindowBase
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse = new();
        private readonly Operation operation = new();
        public VM_Processor? ViewModel;

        private readonly int id = -1;

        public V_ProcessorWindow()
        {
            InitializeComponent();
        }

        public V_ProcessorWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();
            this.v_Warehouse = v_Warehouse;
            this.operation = operation;


        }

        public V_ProcessorWindow(V_Warehouse v_Warehouse, Operation operation, int id)
        {
            InitializeComponent();
            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.id = id;


        }

        public void InitWindow(Page v_Warehouse, Operation operation)
        {
            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));
            DataContext = ViewModel;
            Owner.Effect = new BlurEffect();

            if (operation == Operation.CREATE)
            {
                BtnAddOrModify.Content = "Añadir";
                TitleProcessor.Text = "Añadir " + TitleProcessor.Text;
            }
            else if (operation == Operation.UPDATE)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleProcessor.Text = "Modificar " + TitleProcessor.Text;
            }
            else if (operation == Operation.DELETE)
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

        public void Cancel()
        {

            InputBindings.Clear();
            if (v_Warehouse != null)
                Utils.WarningMessage(v_Warehouse.infoTextProcessor, "Operacion Cancelada");
            _ = WindowAnimationUtils.FadeOutAndClose(this);
        }


        #region crud
        private void CreateUpdateDelete_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (ViewModel != null && v_Warehouse != null)
            {

                if (ViewModel.ValidateInput())
                {

                    switch (operation)
                    {
                        case Operation.CREATE:


                            if (ViewModel.Create())
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador " + ViewModel.Processor.ToString() + " añadido correctamente");
                                v_Warehouse.ProcessorsGrid.SelectedItem = ViewModel.Processor;
                                v_Warehouse.ProcessorsGrid.ScrollIntoView(ViewModel.Processor);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                                

                            }

                            break;
                        case Operation.UPDATE:
                            if (ViewModel.Update(v_Warehouse.ProcessorsGrid.SelectedIndex))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador " + ViewModel.Processor.ToString() + " modificado correctamente");
                                v_Warehouse.ProcessorsGrid.SelectedItem = ViewModel.Processor;
                                v_Warehouse.ProcessorsGrid.ScrollIntoView(ViewModel.Processor);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }

                            break;
                        case Operation.DELETE:
                            int i = v_Warehouse.ProcessorsGrid.SelectedIndex;
                            if (ViewModel.Delete(v_Warehouse.ProcessorsGrid.SelectedIndex))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador " + ViewModel.Processor.ToString() + " eliminado correctamente");
                                Utils.UpdateDataGridToNextPosition(v_Warehouse.ProcessorsGrid, i);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;
                        default:
                            Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                            _ = WindowAnimationUtils.FadeOutAndClose(this);
                            break;

                    }
                }


            }




        }

        private void CreateUpdateDelete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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

        private void Read()
        {
            if (ViewModel != null && v_Warehouse != null)
            {
                if (!ViewModel.Read())
                {
                    Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Procesador no encontrado");
                    _ = WindowAnimationUtils.FadeOutAndClose(this);
                }
            }
        }


        #endregion crud

        #region window events
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (v_Warehouse == null)
            {
                MessageBox.Show("Error Interno, No se ha podido establecer la conexion. ERROR: NOWAREHOUSE");
                Close();
                return;
            }

            if (ViewModel == null)
            {

                Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: NOMODEL");
                Close();
                return;
            }


            ViewModel.InfoErrorMessage += ShowErrorMessage;
            ViewModel.InfoSuccessMessage += ShowSuccessMessage;
            ViewModel.InfoWarningMessage += ShowWarningMessage;
            ViewModel.ClearData();

            if (id > 0 && operation == Operation.UPDATE || operation == Operation.DELETE)
            {
                ViewModel.Processor.Id = id;
                Read();

            }
            else if (operation != Operation.CREATE)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                Close();
            }

            InitWindow(v_Warehouse, operation);


        }
        #endregion window events

        #region message events
        public void ShowSuccessMessage(object sender, string successMessage)
        {

            Utils.SuccessMessage(infoTextProcessor, sender + " : " + successMessage);

        }

        public void ShowErrorMessage(object sender, string errorMessage)
        {

            Utils.ErrorMessage(infoTextProcessor, sender + " : " + errorMessage);


        }

        public void ShowWarningMessage(object sender, string warningMessage)
        {

            Utils.WarningMessage(infoTextProcessor, sender + " : " + warningMessage);
        }
        #endregion message events

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            BitmapImage? img = Utils.SelectImage();
            if (img != null && ViewModel != null)
            {
                ViewModel.Processor.Image = img;


            }

        }
    }
}
