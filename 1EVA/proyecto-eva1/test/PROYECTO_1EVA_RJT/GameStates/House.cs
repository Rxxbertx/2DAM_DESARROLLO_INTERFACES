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

        public bool loadPage(String element)
        {
            bool temp = false;

            switch (element)
            {

                case "puertaCasa1":

                    houseX = new House1(game, player);
                    temp= true;
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
                default:

                    return false;
                    

            }
            return temp;


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

        public void checkHouse()
        {
            
            if (houseX != null)
                game.MainFrame.Navigate(houseX);
            
        }
    }
}
