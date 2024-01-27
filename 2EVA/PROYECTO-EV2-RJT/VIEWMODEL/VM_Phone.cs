using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Phone : IViewModelBase, INotifyPropertyChanged, IViewModelCrud, IFilter
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action<List<M_Storage>> SelectedItemsStorageListView;

        private M_Phone _Phone;
        private M_PhonesCollection _PhonesCollection;
        private M_BrandsCollection _BrandsCollection;
        private M_ProcessorsCollection _ProcessorsCollection;
        private M_StoragesCollection _StoragesCollection;

        private M_Brand _Brand;
        private M_Processor _Processor;


        private string _battery = "";
        private string _ram = "";
        private string _screen = "";


        public M_Phone Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Phone)));
            }
        }

        public M_Brand SelectedBrand
        {
            get { return _Brand; }
            set
            {
                _Brand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBrand)));
            }
        }
        public M_Processor SelectedProcessor
        {
            get { return _Processor; }
            set
            {
                _Processor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedProcessor)));
            }
        }

        public string Battery
        {
            get { return _battery; }
            set
            {
                _battery = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Battery)));
            }
        }
        public string Ram
        {
            get { return _ram; }
            set
            {
                _ram = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ram)));
            }
        }
        public string Screen
        {
            get { return _screen; }
            set
            {
                _screen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Screen)));
            }
        }

        public M_PhonesCollection PhonesCollection
        {
            get { return _PhonesCollection; }
            set
            {
                _PhonesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhonesCollection)));
            }
        }

        public M_BrandsCollection BrandsCollection
        {
            get { return _BrandsCollection; }
            set
            {
                _BrandsCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BrandsCollection)));
            }
        }

        public M_ProcessorsCollection ProcessorsCollection
        {
            get { return _ProcessorsCollection; }
            set
            {
                _ProcessorsCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessorsCollection)));
            }
        }

        public M_StoragesCollection StoragesCollection
        {
            get { return _StoragesCollection; }
            set
            {
                _StoragesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoragesCollection)));
            }
        }

        public List<M_Storage> SelectedStorage
        {
            get { return Phone.Storage; }
            set
            {
                Phone.Storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStorage)));
            }
        }


        #endregion Properties

        public VM_Phone()
        {
            Phone = new M_Phone();
            PhonesCollection = [];
            PhonesCollection.ReadAll();
            View = CollectionViewSource.GetDefaultView(PhonesCollection);
            View.Filter = Filter;

        }

        public void InitOtherCollections()
        {
            BrandsCollection = [];
            BrandsCollection.ReadAll();
            ProcessorsCollection = [];
            ProcessorsCollection.ReadAll();
            StoragesCollection = [];
            StoragesCollection.ReadAll();
        }


        public bool Create()
        {
            int i = Phone.Create();

            if (i == DBConstants.REGISTER_ADDED)
            {
                InfoSuccessMessage?.Invoke("Success", "Movil añadido correctamente");
                PhonesCollection.Create(Phone);
                View.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, i, "Movil");
                return false;
            }
        }

        public bool Delete(int index)
        {
            int result = Phone.Delete();
            if (result == DBConstants.REGISTER_DELETED)
            {
                InfoSuccessMessage?.Invoke("Success", "Movil eliminada correctamente");
                PhonesCollection.Delete(index);
                View.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Movil");
                return false;
            }
        }

        public bool Read()
        {
            M_Phone? temp = Phone.ReadObject();
            if (temp != null)
            {
                Phone = temp;


                List<M_Storage> tempStorage = new List<M_Storage>();
                foreach (M_Storage storage in Phone.Storage)
                {

                    tempStorage.Add(StoragesCollection.ToList().Find(x => x.Storage == storage.Storage));
                }

                if (tempStorage.Count > 0)
                {
                    SelectedItemsStorageListView?.Invoke(tempStorage);
                }


                SelectedBrand = BrandsCollection.FirstOrDefault<M_Brand>(x => x.Id == Phone.Brand.Id);
                SelectedProcessor = ProcessorsCollection.FirstOrDefault<M_Processor>(x => x.Id == Phone.Processor.Id);
                Ram = Phone.Ram.ToString();
                Battery = Phone.Battery.ToString();
                Screen = Phone.Screen.ToString();






                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int i)
        {
            int result = Phone.Update();
            if (result == DBConstants.REGISTER_UPDATED)
            {
                InfoSuccessMessage?.Invoke("Success", "Movil actualizado correctamente");
                PhonesCollection.Update(i, Phone);
                View.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Movil");
                return false;
            }
        }

        public bool ValidateInput()
        {






            if (int.TryParse(Battery, out int battery))
            {
                if (battery <= 0)
                {
                    InfoWarningMessage?.Invoke("Bateria", "El campo debe ser mayor de 0");
                    return false;
                }
                Phone.Battery = battery;

            }
            else
            {
                InfoWarningMessage?.Invoke("Bateria", "El campo debe ser numerico");
                return false;
            }


            if (float.TryParse(Screen, out float screen))
            {
                if (screen <= 0)
                {
                    InfoWarningMessage?.Invoke("Pantalla", "El campo debe ser mayor de 0");
                    return false;
                }
                Phone.Screen = screen;

            }
            else
            {
                InfoWarningMessage?.Invoke("Pantalla", "El campo debe ser numerico");
                return false;
            }


            if (int.TryParse(Ram, out int ram))
            {
                if (ram <= 0)
                {
                    InfoWarningMessage?.Invoke("Ram", "El campo debe ser mayor de 0");
                    return false;
                }
                Phone.Ram = ram;

            }
            else
            {
                InfoWarningMessage?.Invoke("Ram", "El campo debe ser numerico");
                return false;
            }



            if (SelectedBrand == null)
            {
                InfoWarningMessage?.Invoke("Marca", "Debe seleccionar una marca");
                return false;
            }
            else
            {
                Phone.Brand = SelectedBrand;
            }

            if (SelectedProcessor == null)
            {
                InfoWarningMessage?.Invoke("Procesador", "Debe seleccionar un procesador");
                return false;
            }
            else
            {
                Phone.Processor = SelectedProcessor;
            }

            Phone.Storage = SelectedStorage;




            return true;
        }

        public void ClearData()
        {
            Phone = new M_Phone();
        }

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


            if (obj is M_Phone phone)
            {
                if (SelectedSearchParameter?.Content.ToString() == "Marca")
                {
                    return phone.Brand.Name.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Modelo")
                {
                    return phone.Model.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Procesador")
                {
                    return phone.Processor.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Pantalla")
                {
                    return phone.Screen.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Bateria")
                {
                    return phone.Battery.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Sistema")
                {
                    return phone.Os.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Ram")
                {
                    return phone.Ram.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }


            }
            return true;

        }


        #endregion Filter
    }
}
