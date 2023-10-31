using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_1EVA_RJT.GameStates
{


    public enum GameState
    {

        PLAYING, MENU, PAUSE, WIN, TUTORIAL,
        QUIT,HOUSE1,HOUSE2,HOUSE3,HOUSE4
    }

    public class GameManager
    {

        public static GameState state { get; set; }

        private Dictionary<Enum, GameStateData> gameStates = new Dictionary<Enum, GameStateData>();
        public GameStateData currentGameStateData;

        public GameManager()
        {

            state= GameState.MENU;
            // Inicializa los estados y sus datos
            gameStates[GameState.TUTORIAL] = new GameStateData();
            gameStates[GameState.HOUSE1] = new GameStateData();
            gameStates[GameState.HOUSE2] = new GameStateData();
            gameStates[GameState.HOUSE3] = new GameStateData();
            gameStates[GameState.HOUSE4] = new GameStateData();
            // Agrega elementos y colisiones a cada estado según sea necesario

        }

        public void GameStateElements(Enum gameStateName)
        {

            if (gameStates.ContainsKey(gameStateName))
            {
                currentGameStateData = gameStates[gameStateName];
            }
        }
       

    }
}
