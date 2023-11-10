using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.GameStates
{


    public enum GameState // Estados del juego
    {

        PLAYING, MENU, TUTORIAL,
        LVL1, LVL2, LVL3, LVL4, LVL5,
        TALLER
    }

    public class GameManager
    {

        public static GameState State { get; set; } // Estado actual
        public static GameState PreviousState { get; internal set; } // Estado anterior

        public static String Nivel { get; set; } // Nivel actual

        public static List<ImageBrush> inventario = new List<ImageBrush>(); // Inventario actual

        private Dictionary<Enum, GameStateData> gameStates = new Dictionary<Enum, GameStateData>(); // Diccionario de estados
        public static Dictionary<String, ImageBrush> piezaBuscar = new Dictionary<String, ImageBrush>(); // Diccionario de piezas a buscar

        public GameStateData? CurrentGameStateData { get; set; } // Datos del estado actual


        public GameManager()
        {

            Constantes.FPS = 60; // FPS del juego
            Constantes.SoundLvl = 0.3; // Volumen del juego

            Nivel = Constantes.LvlConst.TUTORIAL; 
            State = GameState.MENU;
            PreviousState = GameState.MENU;
            // Inicializa los estados y sus datos
            gameStates[GameState.TUTORIAL] = new GameStateData();
            gameStates[GameState.LVL1] = new GameStateData();
            gameStates[GameState.LVL2] = new GameStateData();
            gameStates[GameState.LVL3] = new GameStateData();
            gameStates[GameState.LVL4] = new GameStateData();
            gameStates[GameState.LVL5] = new GameStateData();
            // Agrega elementos y colisiones a cada estado según sea necesario


            //agregar imagenes a su respectivo nivel

            piezaBuscar[Constantes.LvlConst.TUTORIAL] = CargarGuardar.getPiezaFoto("torre");
            piezaBuscar[Constantes.LvlConst.NIVEL1] = CargarGuardar.getPiezaFoto("ps");
            piezaBuscar[Constantes.LvlConst.NIVEL2] = CargarGuardar.getPiezaFoto("ram");
            piezaBuscar[Constantes.LvlConst.NIVEL3] = CargarGuardar.getPiezaFoto("gpu");
            piezaBuscar[Constantes.LvlConst.NIVEL4] = CargarGuardar.getPiezaFoto("cpu");
            piezaBuscar[Constantes.LvlConst.NIVEL5] = CargarGuardar.getPiezaFoto("placaBase");

        }





        public void GameStateElements(Enum gameStateName) // Carga los elementos del estado actual
        {

            if (gameStates.ContainsKey(gameStateName)) // Si el estado existe
            {
                CurrentGameStateData = gameStates[gameStateName]; // Carga los datos del estado
            }
        }

        public static void addInventarioElemento(ImageBrush imagen) // Añade un elemento al inventario
        {

            if (inventario.Contains(imagen)) // Si el elemento ya está en el inventario
            {
                return;
            }

            inventario.Add(imagen);
        }

        internal static void ChangeState(GameState state) // Cambia el estado actual
        {

            GameManager.PreviousState = GameManager.State; // Guarda el estado anterior
            GameManager.State = state; // Cambia el estado actual

        }
    }
}
