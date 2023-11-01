using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates.Houses;
using System;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class House : StateMethods
    {

        private StateMethods houseX;
        private Player player;
        private Game game;

        public House(Player player, Game game)
        {
            this.player = player;
            this.game = game;
        }

        public void loadPage(String element)
        {
            switch (element)
            {

                case "puertaCasa1":

                    houseX = new House1(game, player);

                    break;

                case "puerta2":

                    // houseX = new House2();
                    break;

                case "puerta3":

                    //  houseX = new House3();

                    break;

                case "puerta4":

                    // houseX = new House4();

                    break;

                case "puerta5":

                    // houseX = new House5();

                    break;

            }


        }


        public bool loadElements()
        {
            return false;
        }

        public void render()
        {
            if (houseX != null)
            houseX.render();

        }

        public void saveElements()
        {

        }

        public void update()
        {
            if (houseX != null)
            houseX.update();
        }

        public void addElements()
        {
            throw new NotImplementedException();
        }
    }
}
