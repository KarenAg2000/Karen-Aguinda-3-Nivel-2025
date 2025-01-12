using System;
using System.Collections.Generic;

class Turno
{
    public string Paciente { get; set; }
    public string Fecha { get; set; }
    public string Hora { get; set; }

    public Turno(string paciente, string fecha, string hora)
    {
        Paciente = paciente;
        Fecha = fecha;
        Hora = hora;
    }

    public override string ToString()
    {
        return $"Paciente: {Paciente}, Fecha: {Fecha}, Hora: {Hora}";
    }
}

class Agenda
{
    private List<Turno> turnos;

    public Agenda()
    {
        turnos = new List<Turno>();
    }

    public void AgregarTurno(string paciente, string fecha, string hora)
    {
        turnos.Add(new Turno(paciente, fecha, hora));
        Console.WriteLine("Turno agregado correctamente.");
    }

    public void MostrarTurnos()
    {
        if (turnos.Count == 0)
        {
            Console.WriteLine("No hay turnos registrados.");
        }
        else
        {
            Console.WriteLine("\n--- Lista de Turnos ---");
            foreach (var turno in turnos)
            {
                Console.WriteLine(turno);
            }
        }
    }

    public void ConsultarTurnos(string paciente)
    {
        var resultados = turnos.FindAll(t => t.Paciente.ToLower() == paciente.ToLower());
        if (resultados.Count == 0)
        {
            Console.WriteLine($"No se encontraron turnos para el paciente: {paciente}.");
        }
        else
        {
            Console.WriteLine($"\n--- Turnos de {paciente} ---");
            foreach (var turno in resultados)
            {
                Console.WriteLine(turno);
            }
        }
    }
}

class Program
{
    static void MostrarDatos()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("* UNIVERSIDAD ESTATAL AMAZONICA *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Título del ejercicio: PracticoExperimental1");
        Console.WriteLine("Fecha: 12/01/2025");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        MostrarDatos();

        Agenda agenda = new Agenda();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- Menú Agenda de Turnos ---");
            Console.WriteLine("1. Agregar turno");
            Console.WriteLine("2. Ver todos los turnos");
            Console.WriteLine("3. Consultar turnos por paciente");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del paciente: ");
                    string paciente = Console.ReadLine();
                    Console.Write("Ingrese la fecha del turno (DD/MM/AAAA): ");
                    string fecha = Console.ReadLine();
                    Console.Write("Ingrese la hora del turno (HH:MM): ");
                    string hora = Console.ReadLine();
                    agenda.AgregarTurno(paciente, fecha, hora);
                    break;

                case "2":
                    agenda.MostrarTurnos();
                    break;

                case "3":
                    Console.Write("Ingrese el nombre del paciente: ");
                    string nombrePaciente = Console.ReadLine();
                    agenda.ConsultarTurnos(nombrePaciente);
                    break;

                case "4":
                    Console.WriteLine("¡Hasta luego!");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
