using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Storage : IViewModelBase, INotifyPropertyChanged, IViewModelCrud
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event Action StoragesCollectionUpdated;
        public event PropertyChangedEventHandler? PropertyChanged;

        private M_Storage _storage;
        private string _txtStorage;
        private M_StoragesCollection _storagesCollection;

        public M_Storage Storage
        {
            get { return _storage; }
            set
            {
                _storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Storage)));
                
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

        public string TxtStorage
        {
            get { return _txtStorage; }
            set
            {
                _txtStorage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TxtStorage)));
            }
        }

        #endregion Properties

        public VM_Storage()
        {
            _txtStorage = "";
            Storage = new M_Storage();
            StoragesCollection = new();
            StoragesCollection.ReadAll();
            
        }


        public bool Create()
        {
            int i = Storage.Create();

            if (i == DBConstants.REGISTER_ADDED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento añadida correctamente");
                StoragesCollection.Create(Storage);
                StoragesCollectionUpdated?.Invoke();

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
            int result = Storage.Delete();
            if (result == DBConstants.REGISTER_DELETED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento eliminada correctamente");
                StoragesCollection.Delete(index);
                StoragesCollectionUpdated?.Invoke();

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
            M_Storage? temp = Storage.ReadObject();
            if (temp != null)
            {
                Storage = temp;
                _txtStorage = Storage.Storage.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int i)
        {
            int result = Storage.Update();
            if (result == DBConstants.REGISTER_UPDATED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento actualizada correctamente");
                StoragesCollection.Update(i, Storage);
                StoragesCollectionUpdated?.Invoke();

                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Almacenamiento");
                return false;
            }
        }

        public bool ValidateInput()
        {
            if (int.TryParse(_txtStorage, out int value))
            {
                if (value <= 0)
                {
                    InfoWarningMessage?.Invoke("Capacidad", "El campo debe ser mayor de 0");
                    return false;
                }
                Storage.Storage = value;

            }
            else
            {
                InfoWarningMessage?.Invoke("Capacidad", "El campo debe ser numerico");
                return false;
            }

            return true;
        }

        public void ClearData()
        {
            Storage = new M_Storage();
        }
    }
}
