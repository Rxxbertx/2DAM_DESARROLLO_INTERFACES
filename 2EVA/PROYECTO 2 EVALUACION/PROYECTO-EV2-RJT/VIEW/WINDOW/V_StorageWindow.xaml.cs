using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_StorageWindow : Window
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        public VM_Storage? ViewModel;

        private readonly int storage = -1;

        public V_StorageWindow()
        {
            InitializeComponent();
        }

        public V_StorageWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            

        }

        public V_StorageWindow(V_Warehouse v_Warehouse, Operation operation, int storage)
        {
            InitializeComponent();

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.storage = storage;


        }

        public void InitWindow(Page parent, Operation operation)
        {
            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));
            DataContext = ViewModel;
            Owner.Effect = new BlurEffect();

            if (operation == Operation.CREATE)
            {
                BtnAddOrModify.Content = "Añadir";
                TitleStorage.Text = "Añadir " + TitleStorage.Text;
            }
            else if (operation == Operation.UPDATE)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleStorage.Text = "Modificar " + TitleStorage.Text;
            }
            else if (operation == Operation.DELETE)
            {
                BtnAddOrModify.Content = "Eliminar";
                TitleStorage.Text = "Eliminar " + TitleStorage.Text + " ?";
                txtStorage.IsEnabled = false;
            }


        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        public void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextPhoneStorage, "Operacion Cancelada");
            Close();
        }

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

                Utils.ErrorMessage(v_Warehouse.infoTextPhoneStorage, "Error Interno, No se ha podido establecer la conexion. ERROR: NOMODEL");
                Close();
                return;
            }

            ViewModel.InfoErrorMessage += ShowErrorMessage;
            ViewModel.InfoSuccessMessage += ShowSuccessMessage;
            ViewModel.InfoWarningMessage += ShowWarningMessage;
            ViewModel.ClearData();

            if (storage > 0 && operation == Operation.UPDATE || operation == Operation.DELETE)
            {
                ViewModel.Storage.OldStorage = storage;
                ViewModel.Storage.Storage = storage;
                Read();

            }
            else if (operation != Operation.CREATE)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextPhoneStorage, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                Close();
            }



            InitWindow(v_Warehouse, operation);


        }
        #endregion window events

        #region crud
        private void CreateUpdateDeleteStorage_Executed(object sender, ExecutedRoutedEventArgs e)
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
                                Utils.SuccessMessage(v_Warehouse.infoTextPhoneStorage, "Almacenamiento " + ViewModel.Storage.ToString() + " añadido correctamente");
                                v_Warehouse.StoragesGrid.SelectedItem = ViewModel.Storage;
                                
                                v_Warehouse.StoragesGrid.ScrollIntoView(ViewModel.Storage);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.UPDATE:

                            if (ViewModel.Update(v_Warehouse.StoragesGrid.SelectedIndex))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextPhoneStorage, "Almacenamiento " + ViewModel.Storage.ToString() + " modificado correctamente");
                                v_Warehouse.StoragesGrid.SelectedItem = ViewModel.Storage;
                                v_Warehouse.StoragesGrid.ScrollIntoView(ViewModel.Storage);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.DELETE:

                            int i = v_Warehouse.StoragesGrid.SelectedIndex;

                            if (ViewModel.Delete(i))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextPhoneStorage, "Almacenamiento " + ViewModel.Storage.ToString() + " eliminado correctamente");
                                Utils.UpdateDataGridToNextPosition(v_Warehouse.StoragesGrid, i);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);

                            }
                            break;

                        default:
                            Utils.ErrorMessage(v_Warehouse.infoTextPhoneStorage, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                            _ = WindowAnimationUtils.FadeOutAndClose(this);
                            break;

                    }
                }


            }


        }



        private void CreateUpdateDeleteStorage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (
                string.IsNullOrEmpty(txtStorage.Text))

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
                    Utils.ErrorMessage(v_Warehouse.infoTextPhoneStorage, "Almacenamiento no encontrado");
                    _ = WindowAnimationUtils.FadeOutAndClose(this);
                }
            }
        }

        #endregion crud

        #region messages

        public void ShowSuccessMessage(object sender, string successMessage)
        {
            Utils.SuccessMessage(infoTextStorage, sender + " : " + successMessage);
        }

        public void ShowErrorMessage(object sender, string errorMessage)
        {
            Utils.ErrorMessage(infoTextStorage, sender + " : " + errorMessage);
        }

        public void ShowWarningMessage(object sender, string warningMessage)
        {
            Utils.WarningMessage(infoTextStorage, sender + " : " + warningMessage);
        }
        #endregion messages
    }
}
