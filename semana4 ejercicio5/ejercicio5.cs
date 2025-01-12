using System;
using System.Collections.Generic;

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

        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

        int precioMinimo = int.MaxValue;
        int precioMaximo = int.MinValue;

        // Buscar el precio mínimo y máximo
        foreach (var precio in precios)
        {
            if (precio < precioMinimo)
                precioMinimo = precio;

            if (precio > precioMaximo)
                precioMaximo = precio;
        }

        // Mostrar los resultados
        Console.WriteLine($"El precio mínimo es: {precioMinimo}");
        Console.WriteLine($"El precio máximo es: {precioMaximo}");
    }
}
