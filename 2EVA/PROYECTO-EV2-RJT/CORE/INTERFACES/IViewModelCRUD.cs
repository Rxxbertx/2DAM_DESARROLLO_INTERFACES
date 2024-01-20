namespace PROYECTO_EV2_RJT.CORE.INTERFACES
{
    public interface IViewModelCRUD
    {


        public bool Add();
        public bool Modify(int i);
        public bool Delete(int i);
        public bool Find();


    }
}