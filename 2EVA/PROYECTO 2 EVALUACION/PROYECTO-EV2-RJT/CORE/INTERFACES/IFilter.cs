using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public interface IFilter
    {

        public ICollectionView View { get; }
        public bool Filter(object obj);


    }
}
