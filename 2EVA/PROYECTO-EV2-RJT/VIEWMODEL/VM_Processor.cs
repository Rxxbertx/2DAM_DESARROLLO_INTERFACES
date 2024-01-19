using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Processor : INotifyPropertyChanged
    {

        private M_Processor _processor;
        private M_ProcessorsCollection _processorsCollection;
        private string _cores;
        private string _nanometers;

        public event PropertyChangedEventHandler? PropertyChanged;

        public event Action<string, string> ValidationError;

        private bool ValidateInput()
        {
            if (int.TryParse(_nanometers, out int nanometers))
            {
                _processor.Nanometers = nanometers;

            }
            else
            {
                ValidationError?.Invoke("Nanometros", "El campo debe ser numerico");
                return false;
            }


            if (int.TryParse(_cores, out int cores))
            {
                _processor.Cores = cores;

            }
            else
            {
                ValidationError?.Invoke("Nucleos", "El campo debe ser numerico");
                return false;
            }

            return true;
        }


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



        public VM_Processor()
        {

            ProcessorsCollection = new M_ProcessorsCollection();
            ProcessorsCollection.LoadProcessors();

        }


        public int AddProcessor()
        {

            int ProcessorAdded = Processor.AddProcessor();

            if (ProcessorAdded == DBConstants.REGISTER_ADDED)

                ProcessorsCollection.Add(Processor);

            return ProcessorAdded;




        }

        public int UpdateProcessor()
        {

            return 0;
        }

        public int DeleteProcessor()
        {

            return 0;
        }

        public void FindProcessor()
        {

        }

        public void ShowMessage(int state)
        {

        }




        #region Inicializacion
        public void init()
        {

        }
        #endregion Inicializacion


    }

}
