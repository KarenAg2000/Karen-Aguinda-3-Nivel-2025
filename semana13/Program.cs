using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*********************************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA       *");
        Console.WriteLine("*********************************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Ejercicio: Búsqueda de títulos en un catálogo de revistas");
        Console.WriteLine("Descripción: Implementar búsqueda recursiva e iterativa para encontrar títulos en un catálogo.");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();

        List<string> catalogo = new List<string>
        {
            "Discover",
            "Forbes",
            "National Geographic",
            "Nature",
            "New Scientist",
            "Popular Science",
            "Scientific American",
            "The Economist",
            "Time",
            "Wired"
        };

        while (true)
        {
            Console.WriteLine("\n--- Menú de Búsqueda ---");
            Console.WriteLine("1. Búsqueda Recursiva");
            Console.WriteLine("2. Búsqueda Iterativa");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "3")
            {
                break;
            }

            Console.Write("Ingrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = false;

            switch (opcion)
            {
                case "1":
                    encontrado = BusquedaRecursiva(catalogo, titulo, 0, catalogo.Count - 1);
                    break;
                case "2":
                    encontrado = BusquedaIterativa(catalogo, titulo);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    continue;
            }

            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }
    }

    static bool BusquedaRecursiva(List<string> catalogo, string titulo, int inicio, int fin)
    {
        if (inicio > fin)
        {
            return false; 
        }

        int medio = (inicio + fin) / 2;
        int comparacion = string.Compare(catalogo[medio], titulo, StringComparison.OrdinalIgnoreCase);

        if (comparacion == 0)
        {
            return true; 
        }
        else if (comparacion < 0)
        {
            return BusquedaRecursiva(catalogo, titulo, medio + 1, fin); 
        }
        else
        {
            return BusquedaRecursiva(catalogo, titulo, inicio, medio - 1);
        }
    }

    static bool BusquedaIterativa(List<string> catalogo, string titulo)
    {
        foreach (string revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; 
            }
        }
        return false; 
    }
}
