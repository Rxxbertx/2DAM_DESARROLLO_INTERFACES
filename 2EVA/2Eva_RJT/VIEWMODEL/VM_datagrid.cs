using _2Eva_RJT.MODEL;
using BoldReports.RDL.DOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _2Eva_RJT.VIEWMODEL
{
    public class VM_datagrid : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        // Propiedades para la vista
        private Planeta planeta;
        private PlanetaCollection planetaCollection;


        // getters y setters de las propiedades para la vista
        public Planeta Planeta
        {
            get { return planeta; }
            set
            {
                planeta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Planeta)));
            }
        }
        public PlanetaCollection PlanetasCollection
        {
            get { return planetaCollection; }
            set
            {
                planetaCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlanetasCollection)));

            }
        }






        // Constructor


        public VM_datagrid()
        {
            Planeta = new Planeta();
            PlanetasCollection = new PlanetaCollection();
            PlanetasCollection.ReadAll();
            View = CollectionViewSource.GetDefaultView(PlanetasCollection);
            View.Filter = Filter;

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
                View?.Refresh();


            }
        }

        public bool Filter(object obj)
        {

            if (obj is Planeta temp)
            {


                if (!string.IsNullOrEmpty(SearchText) && !temp.Nombre.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }


            }
            return true;



        }
        #endregion Filter


    }
}
