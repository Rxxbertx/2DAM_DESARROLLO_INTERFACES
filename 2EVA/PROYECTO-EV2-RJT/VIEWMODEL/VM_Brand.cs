using PROYECTO_EV2_RJT.CORE.CONSTANTS;
using PROYECTO_EV2_RJT.CORE.INTERFACES;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.MODEL;
using System.ComponentModel;
using System.Windows.Data;

namespace PROYECTO_EV2_RJT.VIEWMODEL
{
    public class VM_Brand : IViewModelBase, INotifyPropertyChanged, IViewModelCrud, IFilter
    {

        #region Properties
        // Eventos para mostrar mensajes
        public event Action<string, string> InfoErrorMessage;
        public event Action<string, string> InfoSuccessMessage;
        public event Action<string, string> InfoWarningMessage;
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler? PropertyChanged;
        
        // Propiedades para la vista
        private M_Brand _brand;
        private M_BrandsCollection _brandsCollection;


        // getters y setters de las propiedades para la vista
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

            // Inicializar la vista de la colección con la colección de marcas y el filtro de búsqueda
            View = CollectionViewSource.GetDefaultView(BrandsCollection);
            View.Filter = Filter;
        }



        #region CRUD
        public bool Create()
        {
            int i = Brand.Create(); // guardamos el resultado de la operación de inserción 

            if (i == DBConstants.REGISTER_ADDED) // si la operación ha sido exitosa
            {
                InfoSuccessMessage?.Invoke("Success", "Marca añadida correctamente"); // mostramos mensaje de éxito
                BrandsCollection.Create(Brand); // añadimos la marca a la colección
                View.Refresh(); // refrescamos la vista
                return true; // devolvemos true
            }
            else // si la operación no ha sido exitosa
            { 
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, i, "Marca"); // mostramos mensaje de error
                return false;
            }
        }

        public bool Delete(int index)
        {
            int result = Brand.Delete(); // guardamos el resultado de la operación de borrado
            if (result == DBConstants.REGISTER_DELETED)
            {
                InfoSuccessMessage?.Invoke("Success", "Marca eliminada correctamente");
                BrandsCollection.Delete(index);
                View?.Refresh();
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
            M_Brand? temp = Brand.ReadObject(); // guardamos el resultado de la operación de lectura
            if (temp != null)
            {
                Brand = temp; // si la operación ha sido exitosa, asignamos el objeto leído a la propiedad de la vista
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
                View.Refresh();

                return true;
            }
            else
            {
                DBUtils.CheckStatusOperation(InfoErrorMessage, InfoSuccessMessage, InfoWarningMessage, result, "Marca");
                return false;
            }

            
        }

        #endregion CRUD

        public bool ValidateInput()
        {
            if (string.IsNullOrEmpty(_brand.Name)) // si el nombre está vacío
            {
                InfoErrorMessage?.Invoke("Error", "El nombre no puede estar vacio");
                return false;
            }
            if (_brand.Name.Length < 2) // si el nombre tiene menos de 2 caracteres
            {
                InfoWarningMessage?.Invoke("Error", "El nombre debe tener al menos 2 caracteres");
                return false;
            }

            return true;
        }

        public void ClearData()
        {
            Brand = new M_Brand(); // creamos un nuevo objeto de marca para limpiar los datos
        }


        #region Filter
        // Propiedad para la vista de la colección
        public ICollectionView View { get; private set; }


        // Propiedad para el texto de búsqueda
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));

                // Refrescar la vista de la colección cada vez que cambia el texto de búsqueda
                View?.Refresh();
            }
        }

        public bool Filter(object obj)
        {

            if (obj is M_Brand temp)
            {

                // Filtra por el nombre de la marca
                if (!string.IsNullOrEmpty(SearchText) && !temp.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                
            }
            return true;



        }
        #endregion Filter

    }
}
