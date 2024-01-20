using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using PROYECTO_EV2_RJT.VIEWMODEL;
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
        private readonly VM_Processor vm_processor = new();

        public V_Warehouse()
        {
            InitializeComponent();





        }


        private void TabControl_Selected(object sender, RoutedEventArgs e)
        {


            if (sender is TabControl tabControl)
            {
                if (tabControl.SelectedItem is TabItem tabItem)
                {


                    if (parent != null)
                    {


                        switch (tabItem.Name)
                        {
                            case "phoneTab":

                                phoneTab.Focusable = true;
                                phoneTab.Focus();
                                parent.w_phones.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_phones.IsChecked = true;
                                parent.w_phones.Checked += parent.Menu_Checked; // Add the event handler back



                                break;
                            case "brandTab":

                                brandTab.Focusable = true;
                                brandTab.Focus();
                                parent.w_brands.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_brands.IsChecked = true;
                                parent.w_brands.Checked += parent.Menu_Checked; // Add the event handler back


                                break;
                            case "storageTab":

                                storageTab.Focusable = true;
                                storageTab.Focus();
                                parent.w_storages.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_storages.IsChecked = true;
                                parent.w_storages.Checked += parent.Menu_Checked; // Add the event handler back

                                break;
                            case "processorTab":

                                processorTab.Focusable = true;
                                processorTab.Focus();
                                parent.w_processors.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_processors.IsChecked = true;
                                parent.w_processors.Checked += parent.Menu_Checked; // Add the event handler back
                                DataContext = vm_processor;
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
            LoadWindow(new V_PhoneWindow(this, CORE.ENUMS.Operation.Add));
        }

        private void AddPhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (tabControl.SelectedItem == phoneTab)
            {
                e.CanExecute = true; System.Diagnostics.Debug.WriteLine("CanExecuteppppp");
            }
            else
            {
                e.CanExecute = false;
            }


        }

        private void ModifyPhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneWindow(this, CORE.ENUMS.Operation.Modify));

        }




        private void ModifyPhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (phoneTab.IsSelected && PhonesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DeletePhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este movil?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Utils.SuccessMessage(infoTextPhone, "Movil eliminado correctamente");
            }

        }

        private void DeletePhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (phoneTab.IsSelected && PhonesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        #endregion
        #region Storage

        private void AddStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_StorageWindow(this, Operation.Add));
        }

        private void AddStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            if (storageTab.IsSelected)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ModifyStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_StorageWindow(this, Operation.Modify));
        }

        private void ModifyStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (storageTab.IsSelected && StoragesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DeleteStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
        }

        private void DeleteStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (storageTab.IsSelected && StoragesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        #endregion
        #region Brand

        private void AddBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_BrandWindow(this, Operation.Add));
        }

        private void AddBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (brandTab.IsSelected)
            {
                e.CanExecute = true;

            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ModifyBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_BrandWindow(this, Operation.Modify));
        }

        private void ModifyBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (brandTab.IsSelected && BrandsGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DeleteBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private void DeleteBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (brandTab.IsSelected && BrandsGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        #endregion
        #region Processor
        private void AddProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_ProcessorWindow(this, Operation.Add) { ViewModel = vm_processor });
        }

        private void AddProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (processorTab.IsSelected)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ModifyProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            if ( ProcessorsGrid.SelectedItem is M_Processor processor)
            {

                LoadWindow(new V_ProcessorWindow(this, Operation.Modify, processor.Id) { ViewModel = vm_processor });
            }


            
        }

        private void ModifyProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (processorTab.IsSelected && ProcessorsGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DeleteProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            if (ProcessorsGrid.SelectedItem is M_Processor processor)
            {
               
                LoadWindow(new V_ProcessorWindow(this, Operation.Delete, processor.Id) { ViewModel = vm_processor });
            }

        }

        private void DeleteProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (processorTab.IsSelected && ProcessorsGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        #endregion
        #region PhoneStorage

        private void AddPhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneStorageWindow(this, Operation.Add));
        }

        private void AddPhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (storageTab.IsSelected)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ModifyPhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneStorageWindow(this, Operation.Modify));
        }

        private void ModifyPhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (storageTab.IsSelected && PhonesStoragesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DeletePhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {


        }

        private void DeletePhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (storageTab.IsSelected && PhonesStoragesGrid.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        #endregion

        #endregion



        private  void LoadWindow(Window window)
        {

            window.Owner = Window.GetWindow(this);
            window.DataContext = this.DataContext;
            window.Opacity = 0;
            WindowAnimationUtils.FadeIn(window);
            window.Show();
            
            




        }



    }
}
