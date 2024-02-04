using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public  interface IWindowBase
    {
        // esto son los eventos de la ventana base que se heredan a todas las ventanas que lo necesiten

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e);
        public void Window_Loaded(object sender, RoutedEventArgs e);
        public void ShowSuccessMessage(object sender, string successMessage);
        public void ShowErrorMessage(object sender, string errorMessage);
        public void ShowWarningMessage(object sender, string warningMessage);
        public void Cancel();
        public void InitWindow(Page parent, Operation operation);


    }
}
