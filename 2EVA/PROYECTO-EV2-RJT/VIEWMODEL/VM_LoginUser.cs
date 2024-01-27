using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using PROYECTO_EV2_RJT.VIEW;
using System.ComponentModel;
using System.Windows;
using Application = System.Windows.Application;


namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_LoginUser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string username = "";
        private string password = "";
        public string LoginResult = "";

        public string Username
        {
            get => username;
            set
            {
                username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }


        public VM_LoginUser()
        {
            init();
        }

        public void Login(string username, string password)
        {

            int state = User.AuthenticateUser(username, password);


            ShowMessage(state);

            if (state == LoginConstants.SUCCESS)
            {
                V_MainWindow mainWindow = new();
                mainWindow.Opacity = 0;
                WindowAnimationUtils.FadeIn(mainWindow);
                mainWindow.Show();
                _ = WindowAnimationUtils.FadeOutAndClose(Application.Current.MainWindow);


            }

            init();

        }

        private void ShowMessage(int state)
        {
            if (state == LoginConstants.SUCCESS)
            {
                LoginResult = "Login correcto";
            }
            else if (state == LoginConstants.ERROR)
            {
                LoginResult = "Error";
            }
            else if (state == LoginConstants.USER_NOT_FOUND)
            {
                LoginResult = "Usuario no encontrado";
            }
            else if (state == LoginConstants.PASSWORD_INCORRECT)
            {
                LoginResult = "Contraseña incorrecta";
            }
            else
            {
                LoginResult = "Error";
            }
        }




        #region Inicializacion
        public void init()
        {
            Username = "";
            Password = "";
        }
        #endregion Inicializacion


    }
}
