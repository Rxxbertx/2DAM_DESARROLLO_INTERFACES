using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_PhoneStorage : IViewModelBase, INotifyPropertyChanged, IViewModelCrud, IFilter
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event PropertyChangedEventHandler? PropertyChanged;

        private M_PhoneStorage _phoneStorage;


        private M_Storage _storageSelected;
        private M_Phone _phoneSelected;



        private M_PhoneStoragesCollection _phonesStoragesCollection;
        private M_StoragesCollection _storagesCollection;
        private M_PhonesCollection _phonesCollection;


        public M_PhoneStorage PhoneStorage
        {
            get { return _phoneStorage; }
            set
            {
                _phoneStorage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneStorage)));
            }
        }

        public M_Storage StorageSelected
        {
            get { return _storageSelected; }
            set
            {
                _storageSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StorageSelected)));
            }
        }

        public M_Phone PhoneSelected
        {
            get { return _phoneSelected; }
            set
            {
                _phoneSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneSelected)));
            }
        }

        public M_PhoneStoragesCollection PhonesStoragesCollection
        {
            get { return _phonesStoragesCollection; }
            set
            {
                _phonesStoragesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhonesStoragesCollection)));
            }
        }

        public M_StoragesCollection StoragesCollection
        {
            get { return _storagesCollection; }
            set
            {
                _storagesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoragesCollection)));
            }
        }

        public M_PhonesCollection PhonesCollection
        {
            get { return _phonesCollection; }
            set
            {
                _phonesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhonesCollection)));
            }
        }

 

        #endregion Properties

        public VM_PhoneStorage(VM_Storage vmStorage)
        {
        
            PhoneStorage = new M_PhoneStorage();
            PhonesStoragesCollection = new();
            StoragesCollection = new();
            PhonesCollection = new();
            PhonesCollection.ReadAll();
            StoragesCollection.ReadAll();
            PhonesStoragesCollection.ReadAll();
            View = CollectionViewSource.GetDefaultView(PhonesStoragesCollection);
            View.Filter = Filter;
            vmStorage.StoragesCollectionUpdated += UpdatePhonesStoragesCollection;

        }




        #region CRUD

        public bool Create()
        {
            int i = PhoneStorage.Create();

            if (i == DBConstants.REGISTER_ADDED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento añadida correctamente");
                PhoneStorage.Storage = StorageSelected;
                PhoneStorage.Phone = PhoneSelected;
                PhonesStoragesCollection.Create(PhoneStorage);
                View.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, i, "Almacenamiento");
                return false;
            }
        }

        public bool Delete(int index)
        {
            int result = PhoneStorage.Delete();
            if (result == DBConstants.REGISTER_DELETED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento eliminada correctamente");
                PhonesStoragesCollection.Delete(index);
                View?.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Almacenamiento");
                return false;
            }
        }

        public bool Read()
        {
            M_PhoneStorage? temp = PhoneStorage.ReadObject();
            
            if (temp != null)
            {
                PhoneStorage = temp;
                // Establecer SelectedStorage en el Id_Storage correspondiente
                
                
                StorageSelected = StoragesCollection.FirstOrDefault(s => s.Storage == PhoneStorage.Storage.Storage);
                PhoneSelected = PhonesCollection.FirstOrDefault(p => p.Id == PhoneStorage.Phone.Id);
                


                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int i)
        {
            int result = PhoneStorage.Update();
            if (result == DBConstants.REGISTER_UPDATED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento actualizado correctamente");
                PhoneStorage.Storage = StorageSelected;
                PhoneStorage.Phone = PhoneSelected;
                PhonesStoragesCollection.Update(i, PhoneStorage);
                View.Refresh();
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Almacenamiento");
                return false;
            }
        }

        #endregion CRUD


        #region EXTRAS

        public bool ValidateInput()
        {

            PhoneStorage.Id_Phone = PhoneSelected.Id;
            PhoneStorage.Id_Storage = StorageSelected.Storage;


            return true;
        }

        public void ClearData()
        {
            PhoneStorage = new M_PhoneStorage();
        }

        private void UpdatePhonesStoragesCollection()
        {
            // Actualizar PhonesStoragesCollection
            PhonesStoragesCollection.Clear();
            StoragesCollection.Clear();
            PhonesStoragesCollection.ReadAll();
            StoragesCollection.ReadAll();
        }




        #endregion EXTRAS



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


            if (obj is M_PhoneStorage phoneStorage)
            {
                if (SelectedSearchParameter?.Content.ToString() == "Marca")
                {
                    return phoneStorage.Phone.Brand.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Modelo")
                {
                    return phoneStorage.Phone.Model.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }
                else if (SelectedSearchParameter?.Content.ToString() == "Capacidad")
                {
                    return phoneStorage.Storage.Storage.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                }


            }
            return true;

        }


        #endregion Filter

    }
}
