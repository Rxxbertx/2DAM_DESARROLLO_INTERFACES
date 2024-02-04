using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_Warehouse.xaml
    /// </summary>
    public partial class V_Warehouse : Page
    {

        V_MainWindow? parent = null;

        //ViewModels
        VM_Brand? vm_Brand;
        VM_Storage? vm_Storage;
        VM_Processor? vm_Processor;
        VM_Phone? vm_Phone;
        VM_PhoneStorage? vm_PhoneStorage;


        public V_Warehouse()
        {
            InitializeComponent();


        }




        // cada vez que se selecciona una pestaña se ejecuta este evento
        private void TabControl_Selected(object sender, RoutedEventArgs e)
        {

            if (e.OriginalSource is TabControl tabControl)// si el objeto que ha lanzado el evento es un TabControl
            {

                if (tabControl.SelectedItem is TabItem tabItem)// si el objeto seleccionado es un TabItem
                {


                    if (parent != null)
                    {

                        // en función de la pestaña seleccionada, se selecciona el checkbox correspondiente y se carga el ViewModel correspondiente en el DataContext
                        switch (tabItem.Name)
                        {
                            case "phoneTab":


                                // parent.w_phones.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_phones.IsChecked = true;
                                // parent.w_phones.Checked += parent.Menu_Checked; // Create the event handler back
                                vm_Phone = new();
                                phoneTab.DataContext = vm_Phone;


                                break;
                            case "brandTab":



                                //parent.w_brands.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_brands.IsChecked = true;
                                // parent.w_brands.Checked += parent.Menu_Checked; // Create the event handler back
                                vm_Brand = new();
                                brandTab.DataContext = vm_Brand;




                                break;
                            case "storageTab":


                                //parent.w_storages.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_storages.IsChecked = true;
                                // parent.w_storages.Checked += parent.Menu_Checked; // Create the event handler back
                                vm_Storage = new();
                                vm_PhoneStorage = new(vm_Storage);
                                storageTab.DataContext = vm_PhoneStorage;
                                StoragesGrid.DataContext = vm_Storage;



                                break;
                            case "processorTab":



                                //parent.w_processors.Checked -= parent.Menu_Checked; // Remove the event handler temporarily
                                parent.w_processors.IsChecked = true;
                                //parent.w_processors.Checked += parent.Menu_Checked; // Create the event handler back
                                vm_Processor = new();
                                processorTab.DataContext = vm_Processor;

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

        private void CreatePhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneWindow(this, Operation.CREATE) { ViewModel = vm_Phone });
        }

        private void CreatePhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (tabControl.SelectedItem == phoneTab)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }


        }

        private void UpdatePhone_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            //LoadWindow(new V_PhoneWindow(this, CORE.ENUMS.Operation.UPDATE));

            if (PhonesGrid.SelectedItem is M_Phone phone)
            {
                LoadWindow(new V_PhoneWindow(this, Operation.UPDATE, phone.Id) { ViewModel = vm_Phone });
            }


        }

        private void UpdatePhone_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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
            if (PhonesGrid.SelectedItem is M_Phone phone)
            {
                LoadWindow(new V_PhoneWindow(this, Operation.DELETE, phone.Id) { ViewModel = vm_Phone });
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

        private void CreateStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_StorageWindow(this, Operation.CREATE) { ViewModel = vm_Storage });
        }

        private void CreateStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

        private void UpdateStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            if (StoragesGrid.SelectedItem is M_Storage storage)
            {
                LoadWindow(new V_StorageWindow(this, Operation.UPDATE, storage.Storage) { ViewModel = vm_Storage });
            }

        }

        private void UpdateStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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


            if (StoragesGrid.SelectedItem is M_Storage storage)
            {
                LoadWindow(new V_StorageWindow(this, Operation.DELETE, storage.Storage) { ViewModel = vm_Storage });
            }

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

        private void CreateBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_BrandWindow(this, Operation.CREATE) { ViewModel = vm_Brand });
        }

        private void CreateBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

        private void UpdateBrand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (BrandsGrid.SelectedItem is M_Brand brand)
            {
                LoadWindow(new V_BrandWindow(this, Operation.UPDATE, brand.Id) { ViewModel = vm_Brand });
            }
        }

        private void UpdateBrand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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
            if (BrandsGrid.SelectedItem is M_Brand brand)
            {
                LoadWindow(new V_BrandWindow(this, Operation.DELETE, brand.Id) { ViewModel = vm_Brand });
            }
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
        private void CreateProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_ProcessorWindow(this, Operation.CREATE) { ViewModel = vm_Processor });
        }

        private void CreateProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

        private void UpdateProcessor_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            if (ProcessorsGrid.SelectedItem is M_Processor processor)
            {

                LoadWindow(new V_ProcessorWindow(this, Operation.UPDATE, processor.Id) { ViewModel = vm_Processor });
            }



        }

        private void UpdateProcessor_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

                LoadWindow(new V_ProcessorWindow(this, Operation.DELETE, processor.Id) { ViewModel = vm_Processor });
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

        private void CreatePhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            LoadWindow(new V_PhoneStorageWindow(this, Operation.CREATE) { ViewModel = vm_PhoneStorage });
        }

        private void CreatePhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

        private void UpdatePhoneStorage_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

            if (PhonesStoragesGrid.SelectedItem is M_PhoneStorage phoneStorage)
            {
                LoadWindow(new V_PhoneStorageWindow(this, Operation.UPDATE, phoneStorage.Id_Phone, phoneStorage.Id_Storage) { ViewModel = vm_PhoneStorage });
            }


        }

        private void UpdatePhoneStorage_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
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

            if (PhonesStoragesGrid.SelectedItem is M_PhoneStorage phoneStorage)
            {
                LoadWindow(new V_PhoneStorageWindow(this, Operation.DELETE, phoneStorage.Id_Phone, phoneStorage.Id_Storage) { ViewModel = vm_PhoneStorage });
            }

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



        private void LoadWindow(Window window)
        {

            window.Owner = Window.GetWindow(this);
            window.Opacity = 0;
            WindowAnimationUtils.FadeIn(window);
            window.ShowDialog();
        }

    }
}
