using System.Windows.Input;

namespace PROYECTO_EV2_RJT.CORE.COMMANDS
{
    public class ExitCommand(Action accion, Key tecla, ModifierKeys modificadores = ModifierKeys.None) : ICommand
    {
        private readonly Action _accion = accion;

#pragma warning disable CS0067 // El evento 'ExitCommand.CanExecuteChanged' nunca se usa
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067 // El evento 'ExitCommand.CanExecuteChanged' nunca se usa

        public Key Tecla { get; private set; } = tecla;
        public ModifierKeys Modificadores { get; private set; } = modificadores;

        public bool CanExecute(object? parameter)
        {
            return true; // Puedes implementar lógica de habilitación aquí si es necesario
        }

        public void Execute(object? parameter)
        {
            _accion?.Invoke();
        }



        public InputGesture InputGesture => new KeyGesture(Tecla, Modificadores);
    }

}
