using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Encabezado del programa
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Tema del proyecto 3: Implementación de conjuntos y mapas.");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();

        // Mapa para almacenar deportistas (nombre -> {disciplina, puntaje})
        Dictionary<string, (string disciplina, int puntaje)> deportistas = new Dictionary<string, (string, int)>();

        // Conjunto para almacenar disciplinas únicas
        HashSet<string> disciplinas = new HashSet<string>();

        while (true)
        {
            Console.WriteLine("\n--- Menú de Premiación de Deportistas ---");
            Console.WriteLine("1. Agregar deportista");
            Console.WriteLine("2. Visualizar deportistas premiados");
            Console.WriteLine("3. Consultar disciplinas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del deportista: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Disciplina: ");
                    string disciplina = Console.ReadLine();
                    Console.Write("Puntaje: ");
                    int puntaje = int.Parse(Console.ReadLine());

                    // Agregar deportista al mapa
                    deportistas[nombre] = (disciplina, puntaje);

                    // Agregar disciplina al conjunto
                    disciplinas.Add(disciplina);

                    Console.WriteLine("Deportista agregado con éxito.");
                    break;

                case "2":
                    Console.WriteLine("\n--- Deportistas Premiados ---");
                    foreach (var deportista in deportistas)
                    {
                        Console.WriteLine($"Nombre: {deportista.Key}, Disciplina: {deportista.Value.disciplina}, Puntaje: {deportista.Value.puntaje}");
                    }
                    break;

                case "3":
                    Console.WriteLine("\n--- Disciplinas Registradas ---");
                    foreach (var disciplinaRegistrada in disciplinas)
                    {
                        Console.WriteLine(disciplinaRegistrada);
                    }
                    break;

                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}