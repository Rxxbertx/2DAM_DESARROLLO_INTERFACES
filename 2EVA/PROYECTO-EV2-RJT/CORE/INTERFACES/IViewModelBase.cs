namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public interface IViewModelBase
    {



        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;

        public bool ValidateInput();
        public void ClearData();
    }
}
