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
        private bool insideHouse;

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
                    

                case "puertaCasa2":

                    houseX = new House2(game, player);
                    temp = true;
                    break;

                case "puertaCasa3":

                    houseX = new House3(game, player);
                    temp = true;

                    break;

                case "puertaCasa4":

                    houseX = new House4(game, player);
                    temp = true;
                    break;

                case "puertaCasa5":

                    houseX = new House5(game, player);
                    temp = true;
                    break;
               
                default:
                    return false;
                    

            }
            return temp;


        }


        public bool LoadElements()
        {
            return false;
        }

        public void Render()
        {
            if (houseX != null)
                houseX.Render();

        }

        public void SaveElements()
        {

        }

        public void Update()
        {
            if (houseX != null)
                houseX.Update();
        }



        public void AddElements()
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
