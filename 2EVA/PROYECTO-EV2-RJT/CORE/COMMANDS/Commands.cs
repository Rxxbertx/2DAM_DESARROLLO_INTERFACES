using System.Windows.Input;

namespace PROYECTO_EV2_RJT
{
    public static class Commands
    {
        // Commands for Phones
        public static readonly RoutedUICommand Exit = CreateCommand("Exit", Key.S);
        public static readonly RoutedUICommand Login = CreateCommand("Login", Key.L);

        public static readonly RoutedUICommand UpdatePhone = CreateCommand("UpdatePhone");
        public static readonly RoutedUICommand DeletePhone = CreateCommand("DeletePhone");
        public static readonly RoutedUICommand CreatePhone = CreateCommand("CreatePhone");
        public static readonly RoutedUICommand CreateUpdateDeletePhone = CreateCommand("CreateUpdateDeletePhone", Key.Enter);


        // Commands for Storage
        public static readonly RoutedUICommand DeleteStorage = CreateCommand("DeleteStorage");


        public static readonly RoutedUICommand UpdateStorage = CreateCommand("UpdateStorage");
        public static readonly RoutedUICommand CreateStorage = CreateCommand("CreateStorage");
        public static readonly RoutedUICommand CreateUpdateDeleteStorage = CreateCommand("CreateUpdateDeleteStorage", Key.Enter);



        // Commands for Brands
        public static readonly RoutedUICommand DeleteBrand = CreateCommand("DeleteBrand");
        public static readonly RoutedUICommand UpdateBrand = CreateCommand("UpdateBrand");
        public static readonly RoutedUICommand CreateBrand = CreateCommand("CreateBrand");
        public static readonly RoutedUICommand CreateUpdateDeleteBrand = CreateCommand("CreateUpdateDeleteDeleteBrand", Key.Enter);

        // Commands for Processors
        public static readonly RoutedUICommand DeleteProcessor = CreateCommand("DeleteProcessor");



        public static readonly RoutedUICommand UpdateProcessor = CreateCommand("UpdateProcessor");
        public static readonly RoutedUICommand CreateProcessor = CreateCommand("CreateProcessor");
        public static readonly RoutedUICommand CreateUpdateDeleteProcessor = CreateCommand("CreateUpdateDeleteDeleteProcessor", Key.Enter);

        // Commands for Phone Storage
        public static readonly RoutedUICommand CreatePhoneStorage = CreateCommand("CreatePhoneStorage");
        public static readonly RoutedUICommand DeletePhoneStorage = CreateCommand("DeletePhoneStorage");
        public static readonly RoutedUICommand UpdatePhoneStorage = CreateCommand("UpdatePhoneStorage");
        public static readonly RoutedUICommand CreateUpdateDeletePhoneStorage = CreateCommand("CreateUpdateDeletePhoneStorage", Key.Enter);

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

