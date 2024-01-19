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
        public VM_Processor? ViewModel = new();
       

        public V_ProcessorWindow()
        {
            InitializeComponent();
        }


        public V_ProcessorWindow(V_Warehouse v_Warehouse, Operation operation)
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
                TitleProcessor.Text = "Añadir " + TitleProcessor.Text;
            }
            if (operation == Operation.Modify)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleProcessor.Text = "Modificar " + TitleProcessor.Text;
            }




        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        private async void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextProcessor, "Operacion Cancelada");

            await WindowAnimationUtils.FadeOut(this, 10);

           // Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
            // Inicia la animación de salida
            // Cancela el cierre inicial de la ventana
            
            


        }

        private void AddModifyProcessor_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (ViewModel != null)
            {

                if (v_Warehouse == null)
                {
                    Utils.ErrorMessage(infoTextProcessor, "Error Interno");
                    return;
                }

                if (!ViewModel.ValidateInput()) return;


                if (operation == Operation.Add)
                {

                    if (ViewModel.Add() == DBConstants.REGISTER_ADDED)
                    {
                        Utils.SuccessMessage(v_Warehouse.infoTextProcessor, "Procesador :" + ViewModel.Processor.ToString() + " Añadido");
                        v_Warehouse.ProcessorsGrid.SelectedItem = ViewModel.Processor;
                        Close();
                    };

                    return;

                }

                if (operation == Operation.Modify)
                {

                    ViewModel.Modify();
                    return;

                }


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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.InfoErrorMessage += ShowErrorMessage;
                ViewModel.InfoSuccessMessage += ShowSuccessMessage;
                ViewModel.CleanOldData();
            }
            else
            {
                Utils.ErrorMessage(infoTextProcessor, "Error Interno, No se ha podido establecer la conexion");

            }

        }

        private void ShowSuccessMessage(object sender, string successMessage)
        {

            Utils.SuccessMessage(infoTextProcessor, sender + " : " + successMessage);

        }

        private void ShowErrorMessage(object sender, string errorMessage)
        {

            Utils.ErrorMessage(infoTextProcessor, sender + " : " + errorMessage);


        }
    }
}
