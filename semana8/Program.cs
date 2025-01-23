using System;
using System.Collections.Generic;

class Program
{
    public static bool EsFormulaBalanceada(string formula)
    {
        Stack<char> pila = new Stack<char>(); // Pila para almacenar los caracteres

        foreach (char c in formula)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c); // Agregar los símbolos de apertura a la pila
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) // Si la pila está vacía, hay un cierre sin apertura
                    return false;

                char apertura = pila.Pop(); // Sacar el último elemento de la pila

                // Verificar que el paréntesis, corchete o llave coincida
                if ((c == ')' && apertura != '(') || 
                    (c == '}' && apertura != '{') || 
                    (c == ']' && apertura != '['))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0; // Si la pila está vacía, significa que todo está balanceado
    }

    public static void ResolverTorres(int numDiscos, string origen, string destino, string auxiliar)
    {
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();

        // Colocamos los discos en la torre de origen
        for (int i = numDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Determinamos la cantidad de movimientos
        int movimientos = (int)Math.Pow(2, numDiscos) - 1;

        // Ejecutamos los movimientos
        for (int i = 1; i <= movimientos; i++)
        {
            if (i % 3 == 1)
            {
                MoverDisco(torreOrigen, torreDestino, origen, destino);
            }
            else if (i % 3 == 2)
            {
                MoverDisco(torreOrigen, torreAuxiliar, origen, auxiliar);
            }
            else
            {
                MoverDisco(torreAuxiliar, torreDestino, auxiliar, destino);
            }
        }

        Console.WriteLine("\nSolución final:");
        Console.WriteLine($"Torre de {destino}:");
        foreach (var disco in torreDestino)
        {
            Console.WriteLine(disco);
        }
    }

    private static void MoverDisco(Stack<int> origen, Stack<int> destino, string origenTorre, string destinoTorre)
    {
        if (origen.Count == 0)
        {
            return;
        }

        int discoOrigen = origen.Pop();
        Console.WriteLine($"Mover disco {discoOrigen} de {origenTorre} a {destinoTorre}");
        destino.Push(discoOrigen);
    }

    static void Main()
    {
        // Información adicional solicitada
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Tema: Tomando en cuenta la teoría de la clase sobre pilas, resuelva el código en C# la verificación  de una operación matemática se encuentran balanceados: Ej: {7+(8*5)-[(9-7)+(4+1)]} resultado => formula balanceada.\nRealice un algoritmo en C# y el uso de pilas para resolver el problema de las torres de Hanoi..");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();

        // Verificación de la fórmula balanceada
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";

        if (EsFormulaBalanceada(formula))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula no balanceada.");
        }

        // Resolver Torres de Hanoi
        int numDiscos = 3; // Cambiar el número de discos según lo deseado
        Console.WriteLine("\nResolviendo las Torres de Hanoi:");
        ResolverTorres(numDiscos, "A", "C", "B");
    }
}
