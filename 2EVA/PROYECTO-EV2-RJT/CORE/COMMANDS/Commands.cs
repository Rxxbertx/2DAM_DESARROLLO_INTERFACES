using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PROYECTO_EV2_RJT
{
    public static class Commands
    {
        // Commands for Phones
        public static readonly RoutedUICommand Exit = CreateCommand("Exit", Key.S);
        public static readonly RoutedUICommand ModifyPhone = CreateCommand("ModifyPhone", Key.M);
        public static readonly RoutedUICommand DeletePhone = CreateCommand("DeletePhone", Key.D);
        public static readonly RoutedUICommand AddPhone = CreateCommand("AddPhone", Key.A);

        // Commands for Storage
        public static readonly RoutedUICommand DeleteStorage = CreateCommand("DeleteStorage", Key.D);
        public static readonly RoutedUICommand ModifyStorage = CreateCommand("ModifyStorage", Key.M);
        public static readonly RoutedUICommand AddStorage = CreateCommand("AddStorage", Key.A);

        // Commands for Brands
        public static readonly RoutedUICommand DeleteBrand = CreateCommand("DeleteBrand", Key.D);
        public static readonly RoutedUICommand ModifyBrand = CreateCommand("ModifyBrand", Key.M);
        public static readonly RoutedUICommand AddBrand = CreateCommand("AddBrand", Key.A);

        // Commands for Processors
        public static readonly RoutedUICommand DeleteProcessor = CreateCommand("DeleteProcessor", Key.D);
        public static readonly RoutedUICommand ModifyProcessor = CreateCommand("ModifyProcessor", Key.M);
        public static readonly RoutedUICommand AddProcessor = CreateCommand("AddProcessor", Key.A);

        // Commands for Phone Storage
        public static readonly RoutedUICommand AddPhoneStorage = CreateCommand("AddPhoneStorage", Key.A);
        public static readonly RoutedUICommand DeletePhoneStorage = CreateCommand("DeletePhoneStorage", Key.D);
        public static readonly RoutedUICommand ModifyPhoneStorage = CreateCommand("ModifyPhoneStorage", Key.M);

        private static RoutedUICommand CreateCommand(string text, Key key)
        {
            return new RoutedUICommand(
                text,
                text,
                typeof(Commands),
                [
                    new KeyGesture(key, ModifierKeys.Alt)
                ]);
        }
    }
}

