using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_PhoneStorageWindow : Window
    {
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;

        public V_PhoneStorageWindow()
        {
            InitializeComponent();
        }

        public V_PhoneStorageWindow(V_Warehouse v_Warehouse, Operation operation)
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
                TitleStoragePhone.Text = "Añadir " + TitleStoragePhone.Text;
            }
            if (operation == Operation.Modify)
            {
                BtnAddOrModify.Content = "Modificar";
                TitleStoragePhone.Text = "Modificar " + TitleStoragePhone.Text;
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

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

        private void AddModifyPhoneStorage_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (v_Warehouse == null)
            {
                Utils.ErrorMessage(infoTextPhoneStorage, "Error Interno");
                return;
            }


        }

        private void AddModifyPhoneStorage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (
                string.IsNullOrEmpty(txtStorage.Text) ||
                cbxPhones.SelectedIndex == -1 ||
                cbxStorage.SelectedIndex == -1)

            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
            return;


        }
    }
}
