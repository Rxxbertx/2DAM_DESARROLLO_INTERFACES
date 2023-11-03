using PROYECTO_1EVA_RJT.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_1EVA_RJT.GameStates
{
    public class Playing : StateMethods
    {
        public Playing(Player player, Game game)
        {
            Player = player;
            Game = game;
        }

        public Player Player { get; }
        public Game Game { get; }

        public void AddElements()
        {
            throw new NotImplementedException();
        }

        public bool LoadElements()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void SaveElements()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
