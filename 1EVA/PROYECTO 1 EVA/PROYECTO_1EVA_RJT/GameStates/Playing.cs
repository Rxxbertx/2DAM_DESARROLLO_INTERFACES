using PROYECTO_1EVA_RJT.Entidades;
using static PROYECTO_1EVA_RJT.Utilidades.Constantes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class Playing : StateMethods
    {

        public Player Player { get; }
        public Game Game { get; }

        private StateMethods? LVLx;

        public Playing(Player player, Game game)
        {
            this.Player = player;
            this.Game = game;
        }





        public void LoadNextLevel()
        {

            switch (GameManager.Nivel)
            {

                case LvlConst.NIVEL1:

                    GameManager.Nivel = LvlConst.NIVEL2;
                    LVLx = new Levels.Level2(Player, Game);

                    break;

                case LvlConst.NIVEL2:

                    GameManager.Nivel = LvlConst.NIVEL3;
                    LVLx = new Levels.Level3(Player, Game);

                    break;

                case LvlConst.NIVEL3:

                    GameManager.Nivel = LvlConst.NIVEL4;
                    LVLx = new Levels.Level4(Player, Game);

                    break;

                case LvlConst.NIVEL4:

                    GameManager.Nivel = LvlConst.NIVEL5;
                    LVLx = new Levels.Level5(Player, Game);

                    break;

                case LvlConst.NIVEL5:

                    Game.MainFrame.Navigate(Game.Taller);
                    break;

                default:

                    GameManager.Nivel = LvlConst.NIVEL1;
                    LVLx = new Levels.Level1(Player, Game);

                    break;

            }

            CheckLevel();


        }



        public void Render()
        {

            LVLx?.Render();

        }



        public void Update()
        {
            LVLx?.Update();
        }

        public void CheckLevel()
        {

            if (LVLx != null)
            {
                Game.MainFrame.Navigate(LVLx);
                CheckHouse();
            }
            else
            {

                GameManager.Nivel = LvlConst.NIVEL1;
                LVLx = new Levels.Level1(Player, Game);
                Game.MainFrame.Navigate(LVLx);
            }

        }

        public void CheckHouse()
        {
            LVLx.CheckHouse();
        }
    }
}
