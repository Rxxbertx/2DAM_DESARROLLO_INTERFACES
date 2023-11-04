using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class GameStateData
    {
        public Canvas playerHitbox { get; set; }
        public List<Rectangle> CollidableElements { get; set; }
        public List<Rectangle> InteractiveElements { get; set; }
        public List<Rectangle>[] NormalOpacityElements { get; set; }

        public GameStateData()
        {

        }
    }

}
