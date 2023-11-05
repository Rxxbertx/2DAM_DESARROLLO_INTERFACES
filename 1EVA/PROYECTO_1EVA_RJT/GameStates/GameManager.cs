﻿using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.GameStates
{


    public enum GameState
    {

        PLAYING, MENU, TUTORIAL,
        LVL1, LVL2, LVL3, LVL4, LVL5,
        TALLER
    }

    public class GameManager
    {

        public static GameState State { get; set; }
        public static GameState PreviousState { get; internal set; }

        public static String Nivel { get; set; }

        public static List<ImageBrush> inventario = new List<ImageBrush>();

        private Dictionary<Enum, GameStateData> gameStates = new Dictionary<Enum, GameStateData>();
        public static Dictionary<String, ImageBrush> piezaBuscar = new Dictionary<String, ImageBrush>();

        public GameStateData ?CurrentGameStateData { get; set; }
        

        public GameManager()
        {

            Constantes.FPS = 60;

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





        public void GameStateElements(Enum gameStateName)
        {

            if (gameStates.ContainsKey(gameStateName))
            {
                CurrentGameStateData = gameStates[gameStateName];
            }
        }

        public static void addInventarioElemento(ImageBrush imagen)
        {
            
            if(inventario.Contains(imagen))
            {
                return;
            }

            inventario.Add(imagen);
        }

        internal static void ChangeState(GameState state)
        {
            
            GameManager.PreviousState = GameManager.State;
            GameManager.State = state;

        }
    }
}
