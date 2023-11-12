using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.GameStates.Houses;
using System;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class House : StateMethods
    {

        private StateMethods? houseX; //House1, House2, House3, House4, House5
        private Player player; //Player
        private readonly Game game; //Game

        public House(Player player, Game game) 
        {
            this.player = player;
            this.game = game;

        }

        //Carga la casa correspondiente al elemento que se le pasa por parámetro y devuelve true si se ha cargado correctamente

        public bool LoadPage(String element)  {
            bool temp;
            switch (element) //
            {

                case "puertaCasa1":

                    houseX = new House1(game, player); //Carga la casa 1
                    temp = true; //Devuelve true
                    break; //Sale del switch


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
            // Comprueba si la casa es nula y si no lo es, navega a ella
            if (houseX != null)
                game.MainFrame.Navigate(houseX);

        }
    }
}
