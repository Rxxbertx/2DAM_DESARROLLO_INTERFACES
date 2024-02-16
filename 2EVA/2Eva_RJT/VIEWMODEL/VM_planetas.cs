using _2Eva_RJT.MODEL;
using CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Eva_RJT.VIEWMODEL
{
    public class VM_planetas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        // Propiedades para la vista
        private Planeta planeta;
        private PlanetaCollection planetaCollection;
        private TiposPlanetasCollection tiposPlanetaCollection;



        private TiposPlaneta selectedTipoPlaneta;


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

        public TiposPlanetasCollection TiposPlanetasCollection
        {
            get { return tiposPlanetaCollection; }
            set
            {
                tiposPlanetaCollection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TiposPlanetasCollection)));

            }
        }

        public TiposPlaneta SelectedTipoPlaneta
        {
            get { return selectedTipoPlaneta; }
            set
            {
                selectedTipoPlaneta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTipoPlaneta)));
            }
        }







        public VM_planetas()
        {


            Planeta = new Planeta();
            PlanetasCollection = new PlanetaCollection();
            TiposPlanetasCollection = new TiposPlanetasCollection();
            PlanetasCollection.ReadAll();
            TiposPlanetasCollection.ReadAll();
        }



        public bool ReadPlaneta()
        {



            Planeta = Planeta.ReadObject();

            if (Planeta != null)
            {

                SelectedTipoPlaneta = TiposPlanetasCollection.FirstOrDefault<TiposPlaneta>(x => x.Id == Planeta.Tipo); // asignacion del procesador al combobox de la vista

                return true;
            }
            else
            {
                return false;
            }


        }

        public void Limpiar()
        {
            Planeta = new Planeta();
            SelectedTipoPlaneta = null;

        }

        public bool Guardar()
        {
            Planeta.Tipo = SelectedTipoPlaneta.Id;
            if (Planeta.Update() == DBConstants.REGISTER_UPDATED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Crear()
        {
            Planeta.Tipo = SelectedTipoPlaneta.Id;
            if (Planeta.Crear() == DBConstants.REGISTER_ADDED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
