using PROYECTO_EV2_RJT.CORE.UTILS;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class V_MainWindow : Window
    {

        Page page = new();

        public V_MainWindow()
        {

            InitializeComponent();
            mainFrame.NavigationService.Navigate(new V_Home { parentWindow = this });
            Focus();
        }

        private void Control_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton)
            {
                switch (boton.Name)
                {
                    case "minimize":
                        WindowState = WindowState.Minimized;
                        break;
                    case "maximize":
                        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                        break;
                }
            }
        }

        private void Home_Click(object sender, MouseButtonEventArgs e)
        {

            if (mainFrame.NavigationService.Content is V_Home)
            {
                return;
            }

            mainFrame.NavigationService.Navigate(new V_Home { parentWindow = this });
            clearSelection();
        }

        public void Menu_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is not FrameworkElement element)
                return;

            V_Warehouse wh = new();
            wh.SetOwner(this);

            page = (Page)mainFrame.NavigationService.Content;

            if (element.Equals(warehouse))
            {

                mainFrame.NavigationService.Navigate(wh);

            }
            else if (element.Equals(informs))
            {

                mainFrame.NavigationService.Navigate(new V_Informs());

            }
            else if (element.Equals(help))
            {
                mainFrame.NavigationService.Navigate(new V_Help());



            }
            else if (element.Equals(w_brands))
            {
                wh.brandTab.IsSelected = true;

                mainFrame.NavigationService.Navigate(wh);

            }
            else if (element.Equals(w_phones))
            {
                wh.phoneTab.IsSelected = true;
                mainFrame.NavigationService.Navigate(wh);
            }
            else if (element.Equals(w_storages))
            {
                wh.storageTab.IsSelected = true;
                mainFrame.NavigationService.Navigate(wh);
            }
            else if (element.Equals(w_processors))
            {
                wh.processorTab.IsSelected = true;
                mainFrame.NavigationService.Navigate(wh);
            }
        }

        #region Exit

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {

            mainFrame.NavigationService.Navigate(new V_Exit());
        }

        private void Exit_Command_Executed(object sender, RoutedEventArgs e)
        {
            exit.IsChecked = true;
        }

        private void Exit_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {

            PageNavigationUtils.NavigateWithFadeOut(page, (Page)e.Content);



            if (e.Content is V_Home)
            {
                clearSelection();
            }
            else if ((e.Content is V_Warehouse))
            {
                V_Warehouse wh = (V_Warehouse)e.Content;

                if (wh.brandTab.IsSelected)
                {
                    w_brands.IsChecked = true;
                }
                else if (wh.phoneTab.IsSelected)
                {
                    w_phones.IsChecked = true;
                }
                else if (wh.storageTab.IsSelected)
                {
                    w_storages.IsChecked = true;
                }
                else if (wh.processorTab.IsSelected)
                {
                    w_processors.IsChecked = true;
                }
                else
                {
                    warehouse.IsChecked = true;
                }
            }
            else if ((e.Content is V_Informs))
            {
                informs.IsChecked = true;
            }
            else if ((e.Content is V_Help))
            {
                help.IsChecked = true;
            }
            else if ((e.Content is V_Exit))
            {
                exit.IsChecked = true;
            }



        }

        private void clearSelection()
        {

            warehouse.IsChecked = false;
            informs.IsChecked = false;
            help.IsChecked = false;
            exit.IsChecked = false;
            w_brands.IsChecked = false;
            w_phones.IsChecked = false;
            w_storages.IsChecked = false;
            w_processors.IsChecked = false;
        }

        private void DragMoveWindow(object sender, MouseButtonEventArgs e)
        {


            DragMove();


        }
    }
}