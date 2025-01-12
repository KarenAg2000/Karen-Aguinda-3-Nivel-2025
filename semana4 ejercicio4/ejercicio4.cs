using System;
using System.Linq;

class Program
{
    // MIS DATOS
    static void MostrarDatos()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Título del ejercicio: Listas");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        MostrarDatos();  // Mostrar los datos

        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

        foreach (var vocal in vocales)
        {
            int cantidad = palabra.Count(c => c == vocal);
            Console.WriteLine($"La vocal '{vocal}' aparece {cantidad} veces.");
        }
    }
}
