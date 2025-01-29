using System;
using System.Collections.Generic;
using System.Diagnostics;

class Persona
{
    public string Nombre { get; set; }
    public int NumeroAsiento { get; set; }

    public Persona(string nombre, int numeroAsiento)
    {
        Nombre = nombre;
        NumeroAsiento = numeroAsiento;
    }
}

class Atraccion
{
    private Queue<Persona> colaEspera = new Queue<Persona>();
    private List<Persona> asientosAsignados = new List<Persona>();
    private const int MaxAsientos = 30;

    public void AgregarPersona(string nombre)
    {
        if (asientosAsignados.Count < MaxAsientos)
        {
            int numeroAsiento = asientosAsignados.Count + 1;
            Persona nuevaPersona = new Persona(nombre, numeroAsiento);
            asientosAsignados.Add(nuevaPersona);
            Console.WriteLine($"Asiento asignado: {nombre} - Asiento #{numeroAsiento}");
        }
        else
        {
            colaEspera.Enqueue(new Persona(nombre, -1));
            Console.WriteLine($"La atracción está llena. {nombre} ha sido agregado a la cola de espera.");
        }
    }

    public void MostrarAsientos()
    {
        Console.WriteLine("\nAsientos asignados:");
        foreach (var persona in asientosAsignados)
        {
            Console.WriteLine($"{persona.Nombre} - Asiento #{persona.NumeroAsiento}");
        }
    }

    public void MostrarColaEspera()
    {
        Console.WriteLine("\nPersonas en cola de espera:");
        foreach (var persona in colaEspera)
        {
            Console.WriteLine(persona.Nombre);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Practico Experimental 2 \n");
        Console.WriteLine("Tema: Implementación de teoría de pilas y colas.\n");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
        
        Atraccion atraccion = new Atraccion();
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        
        for (int i = 1; i <= 35; i++)
        {
            atraccion.AgregarPersona($"Persona {i}");
        }
        
        atraccion.MostrarAsientos();
        atraccion.MostrarColaEspera();
        
        stopwatch.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
    }
}