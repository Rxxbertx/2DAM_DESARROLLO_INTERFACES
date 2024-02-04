using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_BrandWindow : Window, IWindowBase
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        public VM_Brand? ViewModel;
        private readonly int id = -1;

        public V_BrandWindow()
        {
            InitializeComponent();
        }

        public V_BrandWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;

        }

        public V_BrandWindow(V_Warehouse v_Warehouse, Operation operation, int id)
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
                TitleBrand.Text = "Añadir " + TitleBrand.Text;
            }
            else if (operation == Operation.UPDATE)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleBrand.Text = "Modificar " + TitleBrand.Text;
            }
            else if (operation == Operation.DELETE)
            {
                BtnAddOrModify.Content = "Eliminar";
                TitleBrand.Text = "Eliminar " + TitleBrand.Text + " ?";
                txtBrand.IsEnabled = false;
            }


        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        public void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextBrand, "Operacion Cancelada");
            Close();
        }

        #region window events
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }
        
        
        // este metodo se ejecuta cuando se carga la ventana y se encarga de inicializar los datos, asignar los eventos y comprobar que todo esta correcto
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

                Utils.ErrorMessage(v_Warehouse.infoTextBrand, "Error Interno, No se ha podido establecer la conexion. ERROR: NOMODEL");
                Close();
                return;
            }

            // asignamos los eventos de los mensajes
            ViewModel.InfoErrorMessage += ShowErrorMessage;
            ViewModel.InfoSuccessMessage += ShowSuccessMessage;
            ViewModel.InfoWarningMessage += ShowWarningMessage;
            ViewModel.ClearData();// limpiamos los datos del modelo

            // si la operacion es de actualizar o eliminar, cargamos los datos del modelo
            if (id > 0 && operation == Operation.UPDATE || operation == Operation.DELETE)
            {
                ViewModel.Brand.Id = id;
                Read();// leemos los datos del modelo

            }
            else if (operation != Operation.CREATE)
            {
                Utils.ErrorMessage(v_Warehouse.infoTextBrand, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                Close();
            }



            InitWindow(v_Warehouse, operation);


        }
        #endregion window events

        #region crud
        private void CreateUpdateDeleteBrand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (ViewModel != null && v_Warehouse != null)
            {
                // si la validacion es correcta, ejecutamos la operacion
                if (ViewModel.ValidateInput())
                {
                    // dependiendo de la operacion, ejecutamos una accion u otra
                    switch (operation)
                    {
                        case Operation.CREATE:

                            if (ViewModel.Create())
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextBrand, "Marca " + ViewModel.Brand.ToString() + " añadida correctamente");
                                v_Warehouse.BrandsGrid.SelectedItem = ViewModel.Brand;
                                v_Warehouse.BrandsGrid.ScrollIntoView(ViewModel.Brand);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.UPDATE:

                            if (ViewModel.Update(v_Warehouse.BrandsGrid.SelectedIndex))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextBrand, "Marca " + ViewModel.Brand.ToString() + " modificada correctamente");
                                v_Warehouse.BrandsGrid.SelectedItem = ViewModel.Brand;
                                v_Warehouse.BrandsGrid.ScrollIntoView(ViewModel.Brand);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                            }
                            break;

                        case Operation.DELETE:

                            int i = v_Warehouse.BrandsGrid.SelectedIndex;

                            if (ViewModel.Delete(i))
                            {
                                Utils.SuccessMessage(v_Warehouse.infoTextBrand, "Marca " + ViewModel.Brand.ToString() + " eliminada correctamente");
                                Utils.UpdateDataGridToNextPosition(v_Warehouse.BrandsGrid, i);
                                _ = WindowAnimationUtils.FadeOutAndClose(this);
                                
                            }
                            break;

                        default:
                            Utils.ErrorMessage(v_Warehouse.infoTextBrand, "Error Interno, No se ha podido establecer la conexion. ERROR: INCORRECT-ACTION");
                            _ = WindowAnimationUtils.FadeOutAndClose(this);
                            break;

                    }
                    
                    

                }


            }


        }



        private void CreateUpdateDeleteBrand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (
                string.IsNullOrEmpty(txtBrand.Text))

            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
            return;


        }

        // metodo que se encarga de leer los datos del modelo 
        private void Read()
        {
            if (ViewModel != null && v_Warehouse != null)
            {
                //si la lectura no es correcta, mostramos un mensaje de error y cerramos la ventana
                if (!ViewModel.Read())
                {
                    Utils.ErrorMessage(v_Warehouse.infoTextBrand, "Marca no encontrada");
                    _ = WindowAnimationUtils.FadeOutAndClose(this);
                }
            }
        }

        #endregion crud

        #region messages

        public void ShowSuccessMessage(object sender, string successMessage)
        {
            Utils.SuccessMessage(infoTextBrand, sender + " : " + successMessage);
        }

        public void ShowErrorMessage(object sender, string errorMessage)
        {
            Utils.ErrorMessage(infoTextBrand, sender+" : "+errorMessage);
        }

        public void ShowWarningMessage(object sender, string warningMessage)
        {
            Utils.WarningMessage(infoTextBrand, sender + " : " + warningMessage);
        }
        #endregion messages

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            BitmapImage? img = Utils.SelectImage();
            if (img != null && ViewModel !=null)
            {
                ViewModel.Brand.Image = img;
                

            }

        }
    }
}
