using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_PhoneStorage : IViewModelBase, INotifyPropertyChanged, IViewModelCrud
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event PropertyChangedEventHandler? PropertyChanged;

        private M_PhoneStorage _phoneStorage;
        private M_Storage _storage;

        private string _idPhone;

        private M_PhoneStoragesCollection _phonesStoragesCollection;
        private M_StoragesCollection _storagesCollection;

        public M_PhoneStorage PhoneStorage
        {
            get { return _phoneStorage; }
            set
            {
                _phoneStorage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneStorage)));
            }
        }

        public M_Storage Storage
        {
            get { return _storage; }
            set
            {
                _storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Storage)));
            }
        }

        public M_PhoneStoragesCollection PhonesStoragesCollection
        {
            get { return _phonesStoragesCollection; }
            set
            {
                _phonesStoragesCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StoragesCollection)));
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

        public string IdPhone
        {
            get { return _idPhone; }
            set
            {
                _idPhone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IdPhone)));
            }
        }

        #endregion Properties

        public VM_PhoneStorage()
        {
        
            PhoneStorage = new M_PhoneStorage();
            Storage = new M_Storage();
            PhonesStoragesCollection = [];
            StoragesCollection = [];
            PhonesStoragesCollection.ReadAll();
            
        }


        public bool Create()
        {
            int i = PhoneStorage.Create();

            if (i == DBConstants.REGISTER_ADDED)
            {
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento añadida correctamente");
                PhonesStoragesCollection.Create(PhoneStorage);
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
                Storage.Storage = PhoneStorage.Storage;
                //_idPhone = PhoneStorage.Id_Phone.ToString();
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
                InfoSuccessMessage?.Invoke("Success", "Almacenamiento actualizada correctamente");
                PhonesStoragesCollection.Update(i, PhoneStorage);
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


            return true;
        }

        public void ClearData()
        {
            PhoneStorage = new M_PhoneStorage();
        }
    }
}
