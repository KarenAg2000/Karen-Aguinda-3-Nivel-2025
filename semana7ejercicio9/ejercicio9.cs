using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        MostrarDatos();
        CompararListas();
    }

    static void MostrarDatos()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Tema: Crear un programa que maneje N° cantidad de datos de tipo entero en dos listas por el inicio.\n" +
                          "Debe existir un ciclo de carga para la primera lista y otro ciclo de carga para la segunda lista.\n" +
                          "Una vez cargados los datos en las listas, el programa debe comparar las dos listas para verificar\n" +
                          "si ambas listas son iguales en tamaño y contenido, es decir que si tienen la misma cantidad de datos\n" +
                          "y si los datos están cargados en el mismo orden. Una vez realizada la verificación, el programa debe mostrar:\n" +
                          "a. Si las listas son iguales en tamaño y en contenido.\n" +
                          "b. Si las listas son iguales en tamaño pero no en contenido.\n" +
                          "c. No tienen el mismo tamaño ni contenido.");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
    }

    static void CompararListas()
    {
        Console.WriteLine("Programa: Comparación de dos listas de enteros");

        // Carga de la primera lista
        int n1;
        while (true)
        {
            Console.Write("Ingrese la cantidad de datos para la primera lista: ");
            if (int.TryParse(Console.ReadLine(), out n1) && n1 > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero válido mayor que 0.");
            }
        }

        List<int> lista1 = new List<int>();
        for (int i = 0; i < n1; i++)
        {
            int dato;
            while (true)
            {
                Console.Write($"Ingrese el dato {i + 1} para la primera lista: ");
                if (int.TryParse(Console.ReadLine(), out dato))
                {
                    lista1.Add(dato);
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }

        // Carga de la segunda lista
        int n2;
        while (true)
        {
            Console.Write("\nIngrese la cantidad de datos para la segunda lista: ");
            if (int.TryParse(Console.ReadLine(), out n2) && n2 > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero válido mayor que 0.");
            }
        }

        List<int> lista2 = new List<int>();
        for (int i = 0; i < n2; i++)
        {
            int dato;
            while (true)
            {
                Console.Write($"Ingrese el dato {i + 1} para la segunda lista: ");
                if (int.TryParse(Console.ReadLine(), out dato))
                {
                    lista2.Add(dato);
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }

        // Comparación de listas
        if (lista1.SequenceEqual(lista2))
        {
            Console.WriteLine("\nLas listas son iguales en tamaño y contenido.");
        }
        else if (lista1.Count == lista2.Count)
        {
            Console.WriteLine("\nLas listas son iguales en tamaño pero no en contenido.");
        }
        else
        {
            Console.WriteLine("\nLas listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
