using PROYECTO_EV2_RJT.CORE;
using PROYECTO_EV2_RJT.MODEL;
using System.Windows;
using System.Windows.Controls;


namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_Warehouse.xaml
    /// </summary>
    public partial class V_Warehouse : Page
    {

        V_MainWindow? parent = null;

        public V_Warehouse()
        {
            InitializeComponent();

            PhoneCollection phones = [];
            PhonesGrid.ItemsSource = phones;

        }


        private void TabControl_Selected(object sender, RoutedEventArgs e)
        {


            if (sender is TabControl tabControl)
            {
                if (tabControl.SelectedItem is TabItem tabItem)
                {

                       
                    if(parent != null) { 


                        switch (tabItem.Name)
                        {
                            case "phoneTab":

                                parent.w_phones.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_phones.IsChecked = true;
                                parent.w_phones.Checked += parent.Menu_Checked; // Add the event handler back



                                break;
                            case "brandTab":

                                parent.w_brands.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_brands.IsChecked = true;
                                parent.w_brands.Checked += parent.Menu_Checked; // Add the event handler back


                                break;
                            case "storageTab":

                                parent.w_storages.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_storages.IsChecked = true;
                                parent.w_storages.Checked += parent.Menu_Checked; // Add the event handler back

                                break;
                            case "processorTab":

                                parent.w_processors.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_processors.IsChecked = true;
                                parent.w_processors.Checked += parent.Menu_Checked; // Add the event handler back

                                break;


                        }
                    }
                }
                }
            }


        public void SetOwner(V_MainWindow v_MainWindow)
        {
           
           parent = v_MainWindow;
        }

        #region Commands


        #region Phone

        private void AddPhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneWindow(this,CORE.ENUMS.Operation.Add));
        }

        private void AddPhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (phoneTab.IsSelected)
            {
                e.CanExecute = true;
            }

            
        }

        private void ModifyPhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneWindow(this, CORE.ENUMS.Operation.Modify,null));

        }




        private void ModifyPhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (phoneTab.IsSelected && PhonesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
        }

        private void DeletePhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este movil?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Utils.SuccessMessage(infoTextPhone,"Movil eliminado correctamente");
            }

        }

        private void DeletePhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (phoneTab.IsSelected && PhonesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
        }

        #endregion
        #region Storage

        private void AddStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_StorageWindow());
        }

        private void AddStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ModifyStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_StorageWindow());
        }

        private void ModifyStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
        }

        private void DeleteStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion
        #region Brand

        private void AddBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_BrandWindow());
        }

        private void AddBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ModifyBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_BrandWindow());
        }

        private void ModifyBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            
        }

        private void DeleteBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion
        #region Processor
        private void AddProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_CpuWindow());
        }

        private void AddProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ModifyProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_CpuWindow());
        }

        private void ModifyProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            
        }

        private void DeleteProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion
        #region PhoneStorage

        private void AddPhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneStorageWindow());
        }

        private void AddPhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ModifyPhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneStorageWindow());
        }

        private void ModifyPhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeletePhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            
           
        }

        private void DeletePhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion

        #endregion


        private void LoadWindow(Window window)
        {

            window.Owner = Window.GetWindow(this);
            window.ShowDialog();


        }

    }
}
