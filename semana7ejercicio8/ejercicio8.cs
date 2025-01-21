using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        MostrarDatos();
        MainProgram1();
        MainProgram2();
    }

    static void MostrarDatos()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Tema: Crear un programa que maneje N cantidad de datos de tipo real en una lista. Una vez \n" +
                          "cargados los datos en la lista, el programa debe calcular el promedio de todos los datos \n" +
                          "cargados. Posteriormente, el programa debe cargar los datos menores o igual al promedio en \n" +
                          "una segunda lista, y los mayores en una tercera lista. Al finalizar este proceso, el programa \n" +
                          "debe mostrar lo siguiente: \n" +
                          "a. Los datos cargados en la lista principal. \n" +
                          "b. El promedio. \n" +
                          "c. Los datos cuyo valor sea igual o menor al promedio de todos los datos. \n" +
                          "d. Los datos que sean mayores al promedio de todos los datos.");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy")); 
        Console.WriteLine();
    }

    static void MainProgram1()
    {
        Console.WriteLine("Programa 1: Manejo de datos en listas");
        
        int n;
        while (true)
        {
            Console.Write("Ingrese la cantidad de datos reales a cargar: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero válido mayor que 0.");
            }
        }

        List<double> listaPrincipal = new List<double>();

        // Carga de datos en la lista principal
        for (int i = 0; i < n; i++)
        {
            double dato;
            while (true)
            {
                Console.Write($"Ingrese el dato {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out dato))
                {
                    listaPrincipal.Add(dato);
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número real válido.");
                }
            }
        }

        // Cálculo del promedio
        double promedio = listaPrincipal.Average();

        // Separación de datos
        List<double> menoresIguales = listaPrincipal.Where(x => x <= promedio).ToList();
        List<double> mayores = listaPrincipal.Where(x => x > promedio).ToList();

        // Resultados
        Console.WriteLine("\nResultados:");
        Console.WriteLine($"Datos en la lista principal: {string.Join(", ", listaPrincipal)}");
        Console.WriteLine($"Promedio: {promedio:F2}");
        Console.WriteLine($"Datos menores o iguales al promedio: {string.Join(", ", menoresIguales)}");
        Console.WriteLine($"Datos mayores al promedio: {string.Join(", ", mayores)}");
    }

    static void MainProgram2()
    {
        Console.WriteLine("\nPrograma 2: Comparación de listas");

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
