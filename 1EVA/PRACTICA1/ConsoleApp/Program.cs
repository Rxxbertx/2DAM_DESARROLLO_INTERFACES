using System.Globalization;

//ROBERTO JOAO TIRON 2DAM 

namespace ConsoleAppTOP
{
    internal class Program
{
    
    // Arreglo de letras para calcular la letra del DNI
    private static readonly char[] LETRAS = {'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X',
                         'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

    static void Main(string[] args)
    {
        bienvenida(); // Función para dar la bienvenida al usuario
        menu(); // Función que muestra el menú principal
        salida(); // Función que muestra un mensaje de despedida
    }

    private static void salida()
    {
        // Mostrar "ADIOS :)" 100 veces con pausas
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("ADIOS  :) ");
            Thread.Sleep(10); // Pausa de 10 milisegundos
        }
    }


        //Whoever said nothing is impossible is a liar. I've been doing nothing for years.
    private static void menu()
    {
        bool exit = false;

        while (!exit)
        {
            switch (opciones()) // Mostrar el menú y obtener la opción del usuario
            {
                case 1:
                    Console.Clear();
                    letraDni(); // Calcular la letra del DNI
                    break;
                case 2:
                    Console.Clear();
                    diaFecha(); // Mostrar el día de la semana para una fecha dada
                    break;
                case 3:
                    Console.Clear();
                    exit = true; // Salir del programa
                    break;
                case 0:
                    Console.Clear();
                    error("NO HAS INTRODUCIDO UN NUMERO"); // Mostrar error si no se ingresó un número
                    break;
                default:
                    Console.Clear();
                    error("No has introducido un numero correcto"); // Mostrar error para opciones inválidas
                    break;
            }
        }
    }

    private static void diaFecha()
    {
        Console.WriteLine("Introduce el dia el mes y el año");
        DateTime dateTime;

        if (DateTime.TryParse(Console.ReadLine(), out dateTime) == true)
        {
            Console.WriteLine(dateTime.ToString("dddd", new CultureInfo("es-ES"))); // Mostrar el día de la semana en español
        }
        else
            error("No has introducido la fecha de manera correcta, el formato recomendado es dia/mes/año");
    }

    private static void letraDni()
    {
        MostrarLetraDni(comprobarDni(pedirDni())); // Calcular y mostrar la letra del DNI
    }

    private static int pedirDni()
    {
        Console.WriteLine("Introduzca el DNI sin la letra por favor");
        int dni;
        int.TryParse(Console.ReadLine(), out dni); // Leer el número del DNI desde la entrada estándar
        return dni;
    }

    private static int comprobarDni(int value)
    {
            if (value.ToString().Length.Equals("8")) // Comprobar si el DNI tiene 8 dígitos
        {
            return value;
        }
        return 0; // Retornar 0 si el DNI es incorrecto
    }

    private static void MostrarLetraDni(int value)
    {
        if (value != 0)
        {
            Console.WriteLine("DNI: " + value + " LETRA: " + LETRAS[value % 23]); // Calcular y mostrar la letra del DNI
        }
        else
        {
            error("DNI ERRONEO EJ: 12345678"); // Mostrar error si el DNI es incorrecto
        }
    }

    private static void error(String msg)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg); // Mostrar mensaje de error en colores
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
    }

    private static int opciones()
    {
        String opciones = "1 - LETRA DNI \n2 - DIA DE LA FECHA \n3 - SALIR";
        int opcion = -1;

        Console.WriteLine(opciones); // Mostrar las opciones del menú

        Console.WriteLine("ELIGE UNA OPCION: ");

        int.TryParse(Console.ReadLine(), out opcion); // Leer la opción seleccionada por el usuario

        return opcion;
    }

    private static void bienvenida()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Buenas, World! , introduce tu nombre antes de continuar"); // Saludar al usuario y solicitar su nombre
        Console.ForegroundColor = ConsoleColor.Red;
        String name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"HOLA {name}");
        Console.ForegroundColor = ConsoleColor.Green;
    }
}
}
