using System;
using System.ComponentModel;

namespace WpfAppBINDING_TEST
{
    public class Persona : INotifyPropertyChanged
    {
        private string? nombre;
        private string? apellido;
        private uint? edad;

        public Persona(string? nombre, uint? edad, string? apellido)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Apellido = apellido;
        }

        public string? Nombre
        {
            get => nombre;
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                    OnPropertyChanged(nameof(NombreCompleto));
                }
            }
        }

        public string? Apellido
        {
            get => apellido;
            set
            {
                if (apellido != value)
                {
                    apellido = value;
                    OnPropertyChanged(nameof(Apellido));
                    OnPropertyChanged(nameof(NombreCompleto));
                }
            }
        }

        public uint? Edad
        {
            get => edad;
            set
            {
                if (edad != value)
                {
                    edad = value;
                    OnPropertyChanged(nameof(Edad));
                }
            }
        }

        public string? NombreCompleto
        {
            get => $"{Nombre} {Apellido}";
            set => NombreCompleto = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string nombrePropiedad)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
