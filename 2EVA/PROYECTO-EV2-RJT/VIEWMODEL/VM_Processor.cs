using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Processor : IViewModelBase, INotifyPropertyChanged, IViewModelCRUD
    {
        #region Propiertes
        private M_Processor _processor = new();
        private M_ProcessorsCollection _processorsCollection = new();
        private string _cores = "";
        private string _nanometers = "";


        public M_Processor Processor
        {
            get { return _processor; }
            set
            {
                _processor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Processor)));
            }
        }

        public M_ProcessorsCollection ProcessorsCollection
        {
            get { return _processorsCollection; }
            set
            {
                _processorsCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessorsCollection)));
            }
        }

        public string Cores
        {
            get { return _cores; }
            set
            {
                _cores = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cores)));
            }
        }
        public string Nanometers
        {
            get { return _nanometers; }
            set
            {
                _nanometers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nanometers)));
            }
        }

        #endregion Propiertes


        #region Commands
        public event PropertyChangedEventHandler? PropertyChanged;

        public event Action<string, string>? InfoErrorMessage;
        public event Action<string, string>? InfoSuccessMessage;




        public bool ValidateInput()
        {
            if (int.TryParse(_nanometers, out int nanometers))
            {
                if (nanometers <= 0)
                {
                    InfoErrorMessage?.Invoke("Nanometros", "El campo debe ser mayor de 0");
                    return false;
                }
                _processor.Nanometers = nanometers;

            }
            else
            {
                InfoErrorMessage?.Invoke("Nanometros", "El campo debe ser numerico");
                return false;
            }


            if (int.TryParse(_cores, out int cores))
            {
                if (cores <= 0)
                {
                    InfoErrorMessage?.Invoke("Nucleos", "El campo debe ser mayor de 0");
                    return false;
                }
                _processor.Cores = cores;

            }
            else
            {
                InfoErrorMessage?.Invoke("Nucleos", "El campo debe ser numerico");
                return false;
            }

            return true;
        }

        #endregion Commands


        public VM_Processor()
        {

            ProcessorsCollection = [];
            ProcessorsCollection.LoadProcessors();
            Processor = new M_Processor();

        }


        #region CRUD

        public int Add()
        {

            int ProcessorAdded = Processor.Add();


            if (ProcessorAdded == DBConstants.REGISTER_ADDED)
            {

                ProcessorsCollection.Add(Processor);

                InfoSuccessMessage?.Invoke("Info", "Procesador Añadido");
                return ProcessorAdded;

            }
            else if (ProcessorAdded == DBConstants.REGISTER_NOT_ADDED)
            {

                InfoErrorMessage?.Invoke("Error Interno", "No se ha podido añadir el procesador");


            }
            else if (ProcessorAdded == DBConstants.REGISTER_FOUNDED)
            {
                InfoErrorMessage?.Invoke("Error Interno", "El procesador ya existe");

            }
            else if (ProcessorAdded == DBConstants.SQL_EXCEPTION)
            {

                InfoErrorMessage?.Invoke("Error Interno", "Intentalo de nuevo mas tarde");
            }

            else
            {
                InfoErrorMessage?.Invoke("Error Interno", "Revisa el codigo de error: SQL: " + ProcessorAdded);


            }

            return ProcessorAdded;
        }

        public int Modify()
        {

            return 0;
        }

        public int Delete()
        {

            return 0;
        }

        public int Find()
        {
            return 0;
        }

        #endregion CRUD

        #region Init
        public void CleanOldData()
        {
            Cores = "";
            Nanometers = "";
            Processor = new M_Processor();
        }
        #endregion Init




    }

}
