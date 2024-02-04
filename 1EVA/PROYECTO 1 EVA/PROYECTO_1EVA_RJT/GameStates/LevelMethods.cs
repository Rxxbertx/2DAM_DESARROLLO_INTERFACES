using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public interface ILevelMethods //interfaz para los metodos de los niveles
    {

        public List<Rectangle> CollidableElements { get; set; } //collidable elements
        public List<Rectangle>[] NormalOpacityElements { get; set; } //normal opacity elements
        public List<Rectangle> InteractiveElements { get; set; } //interactive elements

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
