﻿using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Data.Common;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Brand : IViewModelBase, INotifyPropertyChanged, IViewModelCrud
    {

        #region Properties
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        public event PropertyChangedEventHandler? PropertyChanged;

        private M_Brand _brand;
        private M_BrandsCollection _brandsCollection;

        public M_Brand Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brand)));
            }
        }

        public M_BrandsCollection BrandsCollection
        {
            get { return _brandsCollection; }
            set
            {
                _brandsCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BrandsCollection)));
            }
        }

        #endregion Properties

        public VM_Brand()
        {
            Brand = new M_Brand();
            BrandsCollection = [];
            BrandsCollection.ReadAll();
        }


        public bool Create()
        {
            int i = Brand.Create();

            if (i == DBConstants.REGISTER_ADDED)
            {
                InfoSuccessMessage?.Invoke("Success", "Marca añadida correctamente");
                BrandsCollection.Create(Brand);
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, i, "Marca");
                return false;
            }
        }

        public bool Delete(int index)
        {
            int result = Brand.Delete();
            if (result == DBConstants.REGISTER_DELETED)
            {
                InfoSuccessMessage?.Invoke("Success", "Marca eliminada correctamente");
                BrandsCollection.Delete(index);
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Marca");
                return false;
            }
        }

        public bool Read()
        {
            M_Brand? temp = Brand.ReadObject();
            if (temp != null)
            {
                Brand = temp;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int i)
        {
            int result = Brand.Update();
            if (result == DBConstants.REGISTER_UPDATED)
            {
                InfoSuccessMessage?.Invoke("Success", "Marca actualizada correctamente");
                BrandsCollection.Update(i, Brand);
                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Marca");
                return false;
            }
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrEmpty(_brand.Name))
            {
                InfoErrorMessage?.Invoke("Error", "El nombre no puede estar vacio");
                return false;
            }
            //minimo 3 caracteres
            if (_brand.Name.Length < 2)
            {
                InfoWarningMessage?.Invoke("Error", "El nombre debe tener al menos 2 caracteres");
                return false;
            }

            return true;
        }

        public void ClearData()
        {
            Brand = new M_Brand();
        }
    }
}