using System;

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
        string palabra = Console.ReadLine().ToLower().Replace(" ", "");

        string palabraInvertida = new string(palabra.ToCharArray().Reverse().ToArray());

        if (palabra == palabraInvertida)
        {
            Console.WriteLine("La palabra es un palíndromo.");
        }
        else
        {
            Console.WriteLine("La palabra no es un palíndromo.");
        }
    }
}
