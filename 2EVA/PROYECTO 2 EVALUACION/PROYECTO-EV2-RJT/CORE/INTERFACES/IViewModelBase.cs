namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public interface IViewModelBase
    {

        // esto es la base de todos los viewmodels que consta de los eventos de mensajes y de validacion de datos

        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;

        public bool ValidateInput();
        public void ClearData();
    }
}
