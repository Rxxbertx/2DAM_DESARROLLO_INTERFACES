using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public interface LevelMethods
    {

        void SaveElements();

        bool LoadElements();

        void AddElements();


        void CheckInteractions();

        void CheckHouse();


    }
}
