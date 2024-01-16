using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PROYECTO_EV2_RJT.CORE.COMMANDS
{
    public class ExitCommand : ICommand
    {
        private Action _accion;

        public Key Tecla { get; private set; }
        public ModifierKeys Modificadores { get; private set; }

        public ExitCommand(Action accion, Key tecla, ModifierKeys modificadores = ModifierKeys.None)
        {
            _accion = accion;
            Tecla = tecla;
            Modificadores = modificadores;
        }

        public bool CanExecute(object? parameter)
        {
            return true; // Puedes implementar lógica de habilitación aquí si es necesario
        }

        public void Execute(object? parameter)
        {
            _accion?.Invoke();
        }

        public event EventHandler? CanExecuteChanged;

        public InputGesture InputGesture => new KeyGesture(Tecla, Modificadores);
    }

}
