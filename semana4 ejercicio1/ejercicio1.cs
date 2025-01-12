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

    class Asignatura
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        public bool EsAprobada()
        {
            return Nota >= 5;  // Suponemos que la nota mínima para aprobar es 5
        }
    }

    static void Main(string[] args)
    {
        MostrarDatos();  // Mostrar los datos

        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };

        // Pedir notas al usuario
        foreach (var asignatura in asignaturas)
        {
            Console.Write($"Ingrese la nota de {asignatura.Nombre}: ");
            asignatura.Nota = Convert.ToDouble(Console.ReadLine());
        }

        // Eliminar asignaturas aprobadas
        asignaturas.RemoveAll(asig => asig.EsAprobada());

        // Mostrar asignaturas que necesitan repetirse
        Console.WriteLine("\nAsignaturas que debes repetir:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine(asignatura.Nombre);
        }
    }
}
