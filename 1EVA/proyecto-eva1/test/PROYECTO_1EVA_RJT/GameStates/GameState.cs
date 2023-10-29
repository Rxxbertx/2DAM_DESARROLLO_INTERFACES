using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PROYECTO_1EVA_RJT.GameStates
{


    public enum GameState
    {

        PLAYING, MENU, PAUSE, WIN,
        QUIT
    }

    public static class GameManager
    {
        public static GameState state = GameState.MENU;
    }

}

