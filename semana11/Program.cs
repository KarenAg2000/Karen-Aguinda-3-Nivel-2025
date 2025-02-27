using System;
using System.Collections.Generic;

class Traductor
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño/a"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
    };

    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLower = palabras[i].ToLower();
            if (diccionario.ContainsKey(palabraLower))
            {
                palabras[i] = diccionario[palabraLower];
            }
            else if (diccionario.ContainsValue(palabraLower))
            {
                foreach (var par in diccionario)
                {
                    if (par.Value == palabraLower)
                    {
                        palabras[i] = par.Key;
                        break;
                    }
                }
            }
        }
        Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIng = Console.ReadLine().ToLower();
        Console.Write("Ingrese la traducción en español: ");
        string palabraEsp = Console.ReadLine().ToLower();
        if (!diccionario.ContainsKey(palabraIng))
        {
            diccionario[palabraIng] = palabraEsp;
            Console.WriteLine("Palabra agregada con éxito!\n");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.\n");
        }
    }

    static void Main()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Ejercicio: Desarrolle un traductor básico de inglés español o español ingles utilizando para ello diccionarios puede utilizar como base la siguiente lista de palabras: ."); 
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
        
        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                TraducirFrase();
            }
            else if (opcion == "2")
            {
                AgregarPalabra();
            }
            else if (opcion == "0")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida, intente de nuevo.");
            }
        }
    }
}