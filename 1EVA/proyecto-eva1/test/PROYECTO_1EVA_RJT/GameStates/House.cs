using PROYECTO_1EVA_RJT.GameStates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Controls;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class House: StateMethods
    {

        private static StateMethods houseX;


        

       
        public static void loadPage(String element)
        {
            switch (element)
            {

                case "puerta1":

                    houseX = new House1();

                    break;

            }


        }


        public bool loadElements()
        {
            return false;
        }

        public void render()
        {
           
            houseX.render();

        }

        public void saveElements()
        {
            
        }

        public void update()
        {
            houseX.update();
        }
    }
}
