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
        public static readonly RoutedUICommand Login = CreateCommand("Login", Key.L);

        public static readonly RoutedUICommand ModifyPhone = CreateCommand("ModifyPhone");
        public static readonly RoutedUICommand DeletePhone = CreateCommand("DeletePhone");
        public static readonly RoutedUICommand AddPhone = CreateCommand("AddPhone");
        public static readonly RoutedUICommand AddModifyPhone = CreateCommand("AddModifyPhone", Key.Enter);


        // Commands for Storage
        public static readonly RoutedUICommand DeleteStorage = CreateCommand("DeleteStorage");


        public static readonly RoutedUICommand ModifyStorage = CreateCommand("ModifyStorage");
        public static readonly RoutedUICommand AddStorage = CreateCommand("AddStorage");
        public static readonly RoutedUICommand AddModifyStorage = CreateCommand("AddModifyStorage", Key.Enter);



        // Commands for Brands
        public static readonly RoutedUICommand DeleteBrand = CreateCommand("DeleteBrand");
        public static readonly RoutedUICommand ModifyBrand = CreateCommand("ModifyBrand");
        public static readonly RoutedUICommand AddBrand = CreateCommand("AddBrand");
        public static readonly RoutedUICommand AddModifyBrand = CreateCommand("AddModifyBrand", Key.Enter);

        // Commands for Processors
        public static readonly RoutedUICommand DeleteProcessor = CreateCommand("DeleteProcessor");



        public static readonly RoutedUICommand ModifyProcessor = CreateCommand("ModifyProcessor");
        public static readonly RoutedUICommand AddProcessor = CreateCommand("AddProcessor");
        public static readonly RoutedUICommand AddModifyProcessor = CreateCommand("AddModifyProcessor", Key.Enter);

        // Commands for Phone Storage
        public static readonly RoutedUICommand AddPhoneStorage = CreateCommand("AddPhoneStorage");
        public static readonly RoutedUICommand DeletePhoneStorage = CreateCommand("DeletePhoneStorage");
        public static readonly RoutedUICommand ModifyPhoneStorage = CreateCommand("ModifyPhoneStorage");
        public static readonly RoutedUICommand AddModifyPhoneStorage = CreateCommand("AddModifyPhoneStorage", Key.Enter);

        private static RoutedUICommand CreateCommand(string text, Key key)
        {
            return new RoutedUICommand(
                text,
                text,
                typeof(Commands),
                new InputGestureCollection() { new KeyGesture(key, ModifierKeys.Control) }

                );
        }

        private static RoutedUICommand CreateCommand(string v)
        {

            return new RoutedUICommand(
                               v,
                                              v,
                                                             typeof(Commands)
                                                                            );
        }
    }
}

