using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class GameStateData //
    {
        public Canvas playerHitbox { get; set; } // Player hitbox
        public List<Rectangle> CollidableElements { get; set; } // Collidable elements
        public List<Rectangle> InteractiveElements { get; set; } // Interactive elements
        public List<Rectangle>[] NormalOpacityElements { get; set; } // elementos a los que se les puede cambiar la opacidad

        public GameStateData()
        {

        }
    }

}
