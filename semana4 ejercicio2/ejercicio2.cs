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

        List<char> abecedario = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        // Eliminar las letras en posiciones múltiplos de 3 (índices 3, 6, 9, ...)
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0)  // +1 porque el índice comienza desde 0
            {
                abecedario.RemoveAt(i);
            }
        }

        // Mostrar lista resultante
        Console.WriteLine("Abecedario después de eliminar las letras en posiciones múltiplos de 3:");
        foreach (var letra in abecedario)
        {
            Console.Write(letra + " ");
        }
    }
}
