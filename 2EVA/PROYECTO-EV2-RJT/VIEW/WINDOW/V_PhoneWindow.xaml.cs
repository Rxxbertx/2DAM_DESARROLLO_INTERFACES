using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_AddPhoneWindow.xaml
    /// </summary>
    public partial class V_PhoneWindow : Window
    {
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        private readonly Phone? phone;
        private ExitCommand ExitCommand => new(Cancel, Key.Escape);

        public V_PhoneWindow()
        {
            InitializeComponent();
        }


        public V_PhoneWindow(V_Warehouse v_Warehouse, Operation operation)
        {
            InitializeComponent();

            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));

            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            Owner = Window.GetWindow(v_Warehouse);
            Owner.Effect = new BlurEffect();

            if (operation == Operation.CREATE)
            {
                btnAddOrModify.Content = "Añadir";
                TitlePhone.Text = "Añadir " + TitlePhone.Text;
            }
            if (operation == Operation.UPDATE)
            {
                btnAddOrModify.Content = "Modificar";
                TitlePhone.Text = "Modificar " + TitlePhone.Text;
            }

        }

        public V_PhoneWindow(V_Warehouse v_Warehouse, Operation operation, Phone phone)
        {

            InitializeComponent();

            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));


            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.phone = phone;
            Owner = Window.GetWindow(v_Warehouse);
            Owner.Effect = new BlurEffect();

            if (operation == Operation.CREATE)
            {
                btnAddOrModify.Content = "Añadir";
                TitlePhone.Text = "Añadir " + TitlePhone.Text;
            }
            if (operation == Operation.UPDATE)
            {
                btnAddOrModify.Content = "Modificar";
                TitlePhone.Text = "Modificar " + TitlePhone.Text;
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

        private void AddModifyPhone_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (v_Warehouse == null)
            {
                Utils.ErrorMessage(infoTextPhone, "Error Interno");
                return;
            }


        }

        private void AddModifyPhone_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (
                string.IsNullOrEmpty(txtModel.Text) ||
                string.IsNullOrEmpty(txtBattery.Text) ||
                string.IsNullOrEmpty(txtOS.Text) ||
                string.IsNullOrEmpty(txtRam.Text) ||
                string.IsNullOrEmpty(txtScreen.Text) ||
                cbxProcessor.SelectedIndex == -1 ||
                cbxBrand.SelectedIndex == -1 ||
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
