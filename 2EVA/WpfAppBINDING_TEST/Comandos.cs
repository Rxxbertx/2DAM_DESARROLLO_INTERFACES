using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfAppBINDING_TEST
{
    public static class Comandos
    {

        public static readonly RoutedUICommand salir = new RoutedUICommand(
            "Salir",
            "Salir",
            typeof(Comandos),
            new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt) }
        );



        public static readonly RoutedUICommand notificacion = new RoutedUICommand(
            "Notificacion",
            "Notificacion",
            typeof(Comandos),
            new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Control) }
        );




    }
}
