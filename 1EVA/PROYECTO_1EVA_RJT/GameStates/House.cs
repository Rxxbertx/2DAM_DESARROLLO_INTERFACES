using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates.Houses;
using System;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class House : StateMethods
    {

        private StateMethods? houseX;
        private Player player;
        private readonly Game game;

        public House(Player player, Game game)
        {
            this.player = player;
            this.game = game;

        }

        public bool LoadPage(String element)
        {
            bool temp;
            switch (element)
            {

                case "puertaCasa1":

                    houseX = new House1(game, player);
                    temp = true;
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




        public void Render()
        {
            houseX?.Render();

        }



        public void Update()
        {
            houseX?.Update();
        }


        public void CheckHouse()
        {

            if (houseX != null)
                game.MainFrame.Navigate(houseX);

        }
    }
}
