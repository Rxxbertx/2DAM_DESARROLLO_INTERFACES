using PROYECTO_EV2_RJT.CORE;
using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class V_PhoneWindow : Window
    {
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;
        private Phone? phone;
        private ExitCommand ExitCommand => new ExitCommand(Cancel, Key.Escape);

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

            if (operation == Operation.Add)
            {
                btnAddOrModify.Content = "Añadir";
                Title.Text = "Añadir "+Title.Text;
            }
            if (operation == Operation.Modify)
            {
                btnAddOrModify.Content = "Modificar";
                Title.Text = "Modificar " + Title.Text;
            }

        }

        public V_PhoneWindow(V_Warehouse v_Warehouse, Operation operation, Phone phone)
        {

            InitializeComponent();

            InputBindings.Add(new InputBinding(ExitCommand, ExitCommand.InputGesture));


            this.v_Warehouse = v_Warehouse;
            this.operation = operation;
            this.phone=phone;
            Owner = Window.GetWindow(v_Warehouse);
            Owner.Effect = new BlurEffect();

            if (operation == Operation.Add)
            {
                btnAddOrModify.Content = "Añadir";
                Title.Text = "Añadir " + Title.Text;
            }
            if (operation == Operation.Modify)
            {
                btnAddOrModify.Content = "Modificar";
                Title.Text = "Modificar " + Title.Text;
            }

        }

        private void BtnAddOrModify_Click(object sender, RoutedEventArgs e)
        {


            if (v_Warehouse == null)
            {
                infoText.Text = "Error, no se puede realizar la operacion en estos momentos. COD:NO_PAGE";
                return;
            }

            if(operation == Operation.Add)
            {
                Utils.SuccessMessage(v_Warehouse.infoTextPhone,"Movil Añadido Con Exito");
            }
            if (operation == Operation.Modify)
            {
                Utils.SuccessMessage(v_Warehouse.infoTextPhone,"Movil Modificado Con Exito");
            }

            Close();

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

    }
}
