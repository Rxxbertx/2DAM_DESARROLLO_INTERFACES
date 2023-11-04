using System;

namespace PROYECTO_1EVA_RJT.Utilidades
{
    class Constantes
    {
        public static double FPS { get; internal set; }
        public static bool MUTED = false;

        /**
    * Esta clase lo que tiene son referencias para saber que animaciones escoger es decir si selecciona WALK, se ira
    * a la fila 1 del array de animaciones
    */
        public static class PlayerConst
        {

            public static readonly int WALK = 0;
            public static readonly int IDLE = 1;
            public static readonly int ATTACK = 2;

            public static readonly int FRONT = 0;
            public static readonly int BACK = 1;
            public static readonly int RIGHT = 2;
            public static readonly int LEFT = 3;


            /**
             * Esto es un metodo muy guay, que dependiendo de la animacion escogida, retorna el numero de sprites asociados
             * con esa animacion
             *
             * @param player_action la accion del jugador
             * @return cantidad de sprites por accion
             */
            public static int getSpritesAmount(int action, int player_action)
            {


                if (action == FRONT)
                {

                    if (player_action == WALK)
                    {
                        return 6;
                    }
                    else if (player_action == IDLE)
                    {
                        return 6;
                    }
                    else if (player_action == ATTACK)
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }

                }

                if (action == BACK)
                {
                    if (player_action == WALK)
                    {
                        return 6;
                    }
                    else if (player_action == IDLE)
                    {
                        return 7;
                    }
                    else if (player_action == ATTACK)
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }

                if (action == RIGHT)
                {
                    if (player_action == WALK)
                    {
                        return 6;
                    }
                    else if (player_action == IDLE)
                    {
                        return 6;
                    }
                    else if (player_action == ATTACK)
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }

                if (action == LEFT)
                {
                    if (player_action == WALK)
                    {
                        return 6;
                    }
                    else if (player_action == IDLE)
                    {
                        return 6;
                    }
                    else if (player_action == ATTACK)
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }

                else
                {
                    return 0;
                }




            }

        }
        public static class LvlConst
        {

            public static readonly String NIVEL1 = "NIVEL 1";
            public static readonly String NIVEL2 = "NIVEL 2";
            public static readonly String NIVEL3 = "NIVEL 3";
            public static readonly String NIVEL4 = "NIVEL 4";
            public static readonly String NIVEL5 = "NIVEL 5";
            public static readonly String TUTORIAL = "TUTORIAL";

        }
    }
}
