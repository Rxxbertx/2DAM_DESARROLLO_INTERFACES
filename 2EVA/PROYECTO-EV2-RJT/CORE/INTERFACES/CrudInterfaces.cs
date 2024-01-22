using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public interface IViewModelCrud
    {


        public bool Create();
        public bool Update(int i);
        public bool Delete(int i);
        public bool Read();


    }
    public interface ICollectionCrud<T> where T : ICrud<T>
    {

        public void Create(T crud);
        public void Update(int i, T crud);
        public void Delete(int i);
        public int Read(T crud);
        public void ReadAll();
    }
    public interface ICrud<T>
    {
        int Create();
        int Read();
        T? ReadObject();
        int Update();
        int Delete();
    }




}
