using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2Eva_RJT.CORE
{
    public class Comandos
    {


        public static readonly RoutedUICommand BuscarCommand = CreateCommand("BuscarCommand", Key.B);
        public static readonly RoutedUICommand GuardarCommand = CreateCommand("GuardarCommand", Key.G);
        public static readonly RoutedUICommand LimpiarCommand = CreateCommand("LimpiarCommand", Key.L);








        private static RoutedUICommand CreateCommand(string text, Key key)
        {
            return new RoutedUICommand(
                text,
                text,
                typeof(Comandos),
                new InputGestureCollection() { new KeyGesture(key, ModifierKeys.Control) }

                );
        }

    }
}
