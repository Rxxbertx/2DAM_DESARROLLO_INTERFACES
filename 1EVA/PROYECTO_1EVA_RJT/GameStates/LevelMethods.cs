using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public interface ILevelMethods
    {

        public List<Rectangle> CollidableElements { get; set; }
        public List<Rectangle>[] NormalOpacityElements { get; set; }
        public List<Rectangle> InteractiveElements { get; set; }

        public bool Completed { get; set; }


        void SaveElements();

        bool LoadElements();

        void AddElements();

        void InitPlayer();

        void CheckInteractions();

        void CheckHouse();

        void LoadCanva(Canvas canva);

        void LoadCanvas();

        void Finished();

        bool IsFinished();


    }
}
