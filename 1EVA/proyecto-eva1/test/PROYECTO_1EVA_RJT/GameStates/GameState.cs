namespace PROYECTO_1EVA_RJT.GameStates
{


    public enum GameState
    {

        PLAYING, MENU, PAUSE, WIN, TUTORIAL,
        QUIT
    }

    public static class GameManager
    {
        public static GameState state = GameState.MENU;
    }

}

