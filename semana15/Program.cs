using System;

class GrafoAmistades
{
    static void Main()
    {
        MostrarEncabezado();
        MostrarGrafoAmistades();
    }

    static void MostrarEncabezado()
    {
        Console.WriteLine("*********************************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA       *");
        Console.WriteLine("*********************************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Ejercicio: Grafo en el mundo real");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
    }

    static void MostrarGrafoAmistades()
    {
        // 1. Definir los nodos (usuarios)
        string[] usuarios = { "Ana (A)", "Carlos (B)", "María (C)", "Pedro (D)" };
        
        // 2. Crear e inicializar matriz de adyacencia
        int[,] matrizAdyacencia = new int[4, 4];
        InicializarMatriz(matrizAdyacencia);
        
        // 3. Establecer conexiones (amistades)
        EstablecerConexiones(matrizAdyacencia);

        // 4. Mostrar información del grafo
        MostrarInformacionGrafo(usuarios, matrizAdyacencia);
    }

    static void InicializarMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = 0;
            }
        }
    }

    static void EstablecerConexiones(int[,] matriz)
    {
        // A-B (Ana-Carlos)
        matriz[0, 1] = 1;
        matriz[1, 0] = 1;
        
        // B-C (Carlos-María)
        matriz[1, 2] = 1;
        matriz[2, 1] = 1;
        
        // C-D (María-Pedro)
        matriz[2, 3] = 1;
        matriz[3, 2] = 1;
        
        // A-D (Ana-Pedro)
        matriz[0, 3] = 1;
        matriz[3, 0] = 1;
    }

    static void MostrarInformacionGrafo(string[] usuarios, int[,] matriz)
    {
        Console.WriteLine("Grafo de Amistades de Facebook (Red Social)");
        Console.WriteLine("===========================================\n");
        
        MostrarUsuarios(usuarios);
        MostrarConexiones();
        MostrarMatrizAdyacencia(usuarios, matriz);
        MostrarExplicacion();
    }

    static void MostrarUsuarios(string[] usuarios)
    {
        Console.WriteLine("Usuarios (Nodos):");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"- {usuario}");
        }
    }

    static void MostrarConexiones()
    {
        Console.WriteLine("\nConexiones (Aristas):");
        Console.WriteLine("- Ana es amiga de Carlos");
        Console.WriteLine("- Carlos es amigo de María");
        Console.WriteLine("- María es amiga de Pedro");
        Console.WriteLine("- Ana es amiga de Pedro");
    }

    static void MostrarMatrizAdyacencia(string[] usuarios, int[,] matriz)
    {
        Console.WriteLine("\nMatriz de Adyacencia:");
        Console.Write("     A  B  C  D");
        Console.WriteLine("\n   -------------");
        
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Console.Write($"{usuarios[i].Substring(usuarios[i].Length-2, 1)} | ");
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write($" {matriz[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void MostrarExplicacion()
    {
        Console.WriteLine("\nExplicación:");
        Console.WriteLine("- 1 = Existe amistad");
        Console.WriteLine("- 0 = No existe amistad directa");
        Console.WriteLine("\nEste grafo es NO DIRIGIDO (las amistades son mutuas)");
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}