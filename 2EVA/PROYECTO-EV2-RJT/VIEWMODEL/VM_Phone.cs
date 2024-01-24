using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Phone : IViewModelBase, INotifyPropertyChanged, IViewModelCrud
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event PropertyChangedEventHandler? PropertyChanged;

        private M_Phone _Phone;
        private M_PhonesCollection _PhonesCollection;
        private M_BrandsCollection _BrandsCollection;
        private M_ProcessorsCollection _ProcessorsCollection;
        private M_StoragesCollection _StoragesCollection;


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


        //pasar int a string propiedaes del movil


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

        #endregion Properties

        public VM_Phone()
        {
            Phone = new M_Phone();
            PhonesCollection = [];
            PhonesCollection.ReadAll();

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
                InfoSuccessMessage?.Invoke("Success", "Movil añadida correctamente");
                PhonesCollection.Create(Phone);
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


            return true;
        }

        public void ClearData()
        {
            Phone = new M_Phone();
        }
    }
}
