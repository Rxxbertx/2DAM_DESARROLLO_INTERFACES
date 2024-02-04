using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.VIEWMODEL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class V_Login : Window
    {
        private ExitCommand exitCommand = new ExitCommand(() => Application.Current.Shutdown(), Key.Escape);
        private readonly VM_LoginUser vM_LoginUser = new();

        public V_Login()
        {
            InitializeComponent();
            InputBindings.Add(new InputBinding(exitCommand, exitCommand.InputGesture));
            DataContext = vM_LoginUser;


        }

        private void Control_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton)
            {
                switch (boton.Name)
                {
                    case "exit":
                        Application.Current.Shutdown();
                        break;
                    case "minimize":
                        WindowState = WindowState.Minimized;
                        break;
                    case "maximize":
                        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                        break;
                }
            }
        }

        private void Login_Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            vM_LoginUser.Login(vM_LoginUser.Username, vM_LoginUser.Password);

            loginResultTextBox.Text = vM_LoginUser.LoginResult;


        }

        private void Login_Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Password))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}