using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Processor : IViewModelBase, INotifyPropertyChanged, IViewModelCrud, IFilter
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

        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;




        public bool ValidateInput()
        {
            if (int.TryParse(_nanometers, out int nanometers))
            {
                if (nanometers <= 0)
                {
                    InfoWarningMessage?.Invoke("Nanometros", "El campo debe ser mayor de 0");
                    return false;
                }
                _processor.Nanometers = nanometers;

            }
            else
            {
                InfoWarningMessage?.Invoke("Nanometros", "El campo debe ser numerico");
                return false;
            }


            if (int.TryParse(_cores, out int cores))
            {
                if (cores <= 0)
                {
                    InfoWarningMessage?.Invoke("Nucleos", "El campo debe ser mayor de 0");
                    return false;
                }
                _processor.Cores = cores;

            }
            else
            {
                InfoWarningMessage?.Invoke("Nucleos", "El campo debe ser numerico");
                return false;
            }

            return true;
        }

        #endregion Commands


        public VM_Processor()
        {
            Processor = new M_Processor();
            ProcessorsCollection = [];
            ProcessorsCollection.ReadAll();
            View = CollectionViewSource.GetDefaultView(ProcessorsCollection);
            View.Filter = Filter;


        }


        #region CRUD

        public bool Create()
        {

            int ProcessorAdded = Processor.Create();


            if (ProcessorAdded == DBConstants.REGISTER_ADDED)
            {

                ProcessorsCollection.Add(Processor);
                View.Refresh();

                InfoSuccessMessage?.Invoke("Info", "Procesador Añadido");
                return true;

            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, ProcessorAdded, "Procesador");

            }


            return false;
        }
        public bool Read()
        {

            M_Processor? temp = Processor.ReadObject();
            if (temp == null) return false;
            else
            {
                Processor = temp;
                Cores = Processor.Cores.ToString();
                Nanometers = Processor.Nanometers.ToString();
                return true;
            }


        }

        public bool Update(int selectedIndex)
        {

            int ProcessorModified = Processor.Update();



            if (ProcessorModified == DBConstants.REGISTER_UPDATED)
            {

                ProcessorsCollection.Update(selectedIndex, Processor);
                View.Refresh();

                InfoSuccessMessage?.Invoke("Info", "Procesador Actualizado");
                return true;

            }
            else DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, ProcessorModified, "Procesador");

            return false;



        }

        public bool Delete(int selectedIndex)
        {

            int ProcessorDeleted = Processor.Delete();

            if (ProcessorDeleted == DBConstants.REGISTER_DELETED)
            {

                ProcessorsCollection.Delete(selectedIndex);
                View.Refresh();

                InfoSuccessMessage?.Invoke("Info", "Procesador Eliminado");
                return true;

            }
            else DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, ProcessorDeleted, "Procesador");

            return false;

        }



        #endregion CRUD

        #region Init
        public void ClearData()
        {
            Cores = "";
            Nanometers = "";
            Processor = new M_Processor();
        }
        #endregion Init


        #region Filter


        private ComboBoxItem _selectedSearchParameter;
        private string _searchText;


        public ICollectionView View { get; private set; }


        public ComboBoxItem SelectedSearchParameter
        {
            get { return _selectedSearchParameter; }
            set
            {
                _selectedSearchParameter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSearchParameter)));
                View?.Refresh();
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));

                View?.Refresh();
            }
        }


        public bool Filter(object obj)
        {


            if (obj is M_Processor processor)
            {
                if (SelectedSearchParameter?.Content.ToString() == "Nucleos")
                {
                    return processor.Cores.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Nanometros")
                {
                    return processor.Nanometers.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Nombre")
                {
                    return processor.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Marca")
                {

                    return processor.Manufacturer.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Gpu")
                {
                    return processor.Gpu.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }


            }
            return true;

        }


        #endregion Filter


    }

}
