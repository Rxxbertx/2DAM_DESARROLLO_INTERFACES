using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
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

    public partial class V_PhoneWindow : Window
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);// comando para salir de la ventana
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        public VM_Phone? ViewModel;


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

                txtBattery.IsEnabled = false;
                txtModel.IsEnabled = false;
                txtOS.IsEnabled = false;
                txtRam.IsEnabled = false;
                txtScreen.IsEnabled = false;
                cbxBrand.IsEnabled = false;
                cbxProcessor.IsEnabled = false;
                ImageRectangle.IsEnabled = false;



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
            ViewModel.SelectedItemsStorageListView += SelectItemsInListView; //asignamos el evento para que se seleccione los items en el listview de almacenamiento
            ViewModel.InitOtherCollections();//inicializamos las colecciones de marcas y procesadores para que se muestren en los combobox
            ViewModel.ClearData();

            if (id > 0 && operation == Operation.UPDATE || operation == Operation.DELETE)
            {
                
                ViewModel.Phone.Id = id;
                Read();

            }
            else if (operation != Operation.CREATE)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextPhone, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                Close();
            }



            InitWindow(v_Warehouse, operation);


        }

        private void SelectItemsInListView(List<M_Storage> list)
        {
            

            foreach (M_Storage item in list)
            {
                cbxStorage.SelectedItems.Add(item);
            }


        }
        #endregion window events

        #region crud
        private void CreateUpdateDeletePhone_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (ViewModel != null && v_Warehouse != null)
            {

                if (ViewModel.ValidateInput())
                {
                    //esto es para que se actualice la lista de almacenamiento seleccionado en el viewmodel
                    ViewModel.SelectedStorage = cbxStorage.SelectedItems.Cast<M_Storage>().ToList(); ;

                    switch (operation)
                    {
                        case Operation.CREATE:

                            if (ViewModel.Create())
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " añadido correctamente");
                                v_Warehouse.PhonesGrid.SelectedItem = ViewModel.Phone;

                                v_Warehouse.PhonesGrid.ScrollIntoView(ViewModel.Phone);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.UPDATE:

                            if (ViewModel.Update(v_Warehouse.PhonesGrid.SelectedIndex))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " modificado correctamente");
                                v_Warehouse.PhonesGrid.SelectedItem = ViewModel.Phone;
                                v_Warehouse.PhonesGrid.ScrollIntoView(ViewModel.Phone);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.DELETE:

                            int i = v_Warehouse.PhonesGrid.SelectedIndex;

                            if (ViewModel.Delete(i))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextPhone, "Movil " + ViewModel.Phone.ToString() + " eliminado correctamente");
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


            if (String.IsNullOrEmpty(txtBattery.Text) ||
                String.IsNullOrEmpty(txtModel.Text) ||
                String.IsNullOrEmpty(txtOS.Text) ||
                String.IsNullOrEmpty(txtRam.Text) ||
                String.IsNullOrEmpty(txtScreen.Text) || cbxBrand.SelectedIndex == -1 || cbxProcessor.SelectedIndex == -1)


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


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            BitmapImage? img = Utils.SelectImage();
            if (img != null && ViewModel != null)
            {
                ViewModel.Phone.Image = img;


            }

        }

    }



}
