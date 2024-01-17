using PROYECTO_EV2_RJT.CORE;
using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
    public partial class V_StorageWindow : Window
    {
        private ExitCommand ExitCommand => new ExitCommand(Cancel, Key.Escape);
        private readonly V_Warehouse? v_Warehouse;
        private readonly Operation operation;

        public V_StorageWindow()
        {
            InitializeComponent();
        }

        public V_StorageWindow(V_Warehouse v_Warehouse, Operation operation)
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
                Title.Text = "Añadir " + Title.Text;
            }
            if (operation == Operation.Modify)
            {
                BtnAddOrModify.Content = "Modificar";
                Title.Text = "Modificar " + Title.Text;
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            Cancel();

        }

        private void Cancel()
        {
            if (v_Warehouse != null)
                Utils.ErrorMessage(v_Warehouse.infoTextPhone, txtStorage.Text);
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }

        private void AddModifyStorage_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            if (v_Warehouse == null)
            {
                Utils.ErrorMessage(infoTextStorage, "Error Interno");
                return;
            }


        }

        private void AddModifyStorage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(txtStorage.Text))

            {
              e.CanExecute = false;

            }
            else { e.CanExecute = true; }
            
            


        }
    }
}
