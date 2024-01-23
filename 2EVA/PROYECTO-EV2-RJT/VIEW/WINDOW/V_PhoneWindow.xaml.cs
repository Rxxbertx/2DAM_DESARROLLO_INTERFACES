using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
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

    public partial class V_PhoneWindow : Window
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        public VM_PhoneStorage? ViewModel;


        private readonly int id = -1;

        public V_PhoneWindow()
        {
            InitializeComponent();
        }

        public V_PhoneWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;


        }

        public V_PhoneWindow(V_Warehouse v_Warehouse, Operation operation, int id)
        {
            InitializeComponent();

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.id = id;


        }

        public void InitWindow(Page parent, Operation operation)
        {
            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));
            DataContext = ViewModel;
            Owner.Effect = new BlurEffect();

            if (operation == Operation.CREATE)
            {
                BtnAddOrModify.Content = "Añadir";
                TitlePhone.Text = "Añadir " + TitlePhone.Text;
            }
            else if (operation == Operation.UPDATE)
            {
                BtnAddOrModify.Content = "Modificar";
                TitlePhone.Text = "Modificar " + TitlePhone.Text;
            }
            else if (operation == Operation.DELETE)
            {
                BtnAddOrModify.Content = "Eliminar";
                TitlePhone.Text = "Eliminar " + TitlePhone.Text + " ?";
                


            }


        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        public void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Operacion Cancelada");
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

                Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Error Interno, No se ha podido establecer la conexion. ERROR: NOMODEL");
                Close();
                return;
            }

            ViewModel.InfoErrorMessage += ShowErrorMessage;
            ViewModel.InfoSuccessMessage += ShowSuccessMessage;
            ViewModel.InfoWarningMessage += ShowWarningMessage;
            ViewModel.ClearData();

            if (id > 0 && operation == Operation.UPDATE || operation == Operation.DELETE)
            {

                Read();

            }
            else if (operation != Operation.CREATE)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                Close();
            }



            InitWindow(v_Warehouse, operation);


        }
        #endregion window events

        #region crud
        private void CreateUpdateDeletePhone_Executed(object sender, ExecutedRoutedEventArgs e)
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
                                //Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " añadido correctamente");
                                //v_Warehouse.PhonesGrid.SelectedItem = ViewModel.Phone;

                                //v_Warehouse.PhonesGrid.ScrollIntoView(ViewModel.Phone);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.UPDATE:

                            if (ViewModel.Update(v_Warehouse.PhonesGrid.SelectedIndex))
                            {
                                //Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " modificado correctamente");
                                //v_Warehouse.PhonesGrid.SelectedItem = ViewModel.Phone;
                                //v_Warehouse.PhonesGrid.ScrollIntoView(ViewModel.Phone);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.DELETE:

                            int i = v_Warehouse.PhonesGrid.SelectedIndex;

                            if (ViewModel.Delete(i))
                            {
                                //Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " eliminado correctamente");
                                Utils.UpdateDataGridToNextPosition(v_Warehouse.PhonesGrid, i);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);

                            }
                            break;

                        default:
                            Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                            _ = WindowAnimationUtils.FadeOutAndClose(this);
                            break;

                    }
                }


            }


        }



        private void CreateUpdateDeletePhone_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (1>0) { }
                

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
                    Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Movil no encontrado");
                    _ = WindowAnimationUtils.FadeOutAndClose(this);
                }
            }
        }

        #endregion crud

        #region messages

        public void ShowSuccessMessage(object sender, string successMessage)
        {
            Utils.SuccessMessage(infoTextPhone, sender + " : " + successMessage);
        }

        public void ShowErrorMessage(object sender, string errorMessage)
        {
            Utils.ErrorMessage(infoTextPhone, sender + " : " + errorMessage);
        }

        public void ShowWarningMessage(object sender, string warningMessage)
        {
            Utils.WarningMessage(infoTextPhone, sender + " : " + warningMessage);
        }
        #endregion messages
    }


}
