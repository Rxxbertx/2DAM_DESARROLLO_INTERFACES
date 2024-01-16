using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_EV2_RJT.MODEL
{
    public class Phone
    {

        #region Atributos

        private int id;
        private string brand;
        private string model;
        private int ram;
        private string processor;
        private int battery;
        private string os;
        private float screen;

        #endregion


        #region Propiedades

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Ram { get => ram; set => ram = value; }
        public string Processor { get => processor; set => processor = value; }
        public int Battery { get => battery; set => battery = value; }
        public string Os { get => os; set => os = value; }
        public float Screen { get => screen; set => screen = value; }

        #endregion

        #region Constructores

        public Phone()
        {
            this.id = 0;
            this.brand = "";
            this.model = "";
            this.ram = 0;
            this.processor = "";
            this.battery = 0;
            this.os = "";
            this.screen = 0;
        }

        public Phone(int id, string brand, string model, int ram, string processor, int battery, string os, float screen)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.ram = ram;
            this.processor = processor;
            this.battery = battery;
            this.os = os;
            this.screen = screen;
        }

        #endregion




    }
}
