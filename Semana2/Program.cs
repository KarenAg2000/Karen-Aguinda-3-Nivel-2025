// crear dos clases para dos figuras geométricas(circulo, cuadrado, rectángulo, etc.) que encapsule sus tipos de datos primitivos y proporcione métodos para calcular el área y el perímetro


using System;

class Circulo
{
    public double Radio; // Campo público para almacenar el radio

    public double CalcularArea()
    {
        return 3.14 * Radio * Radio; // Fórmula simplificada para el área
    }

    public double CalcularPerimetro()
    {
        return 2 * 3.14 * Radio; // Fórmula simplificada para el perímetro
    }
}

class Rectangulo
{
    public double Largo; // Campo público para el largo
    public double Ancho; // Campo público para el ancho

    public double CalcularArea()
    {
        return Largo * Ancho; // Área = Largo x Ancho
    }

    public double CalcularPerimetro()
    {
        return 2 * (Largo + Ancho); // Perímetro = 2 x (Largo + Ancho)
    }
}

class Program
{
    static void Main(string[] args)
    {


        // MIS DATOS

        Console.WriteLine("***************************");
        Console.WriteLine("*       CARÁTULA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Título del ejercicio: Cálculo de área y perímetro");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("10/12/2024"));
        Console.WriteLine();


        // Círculo
        Circulo circulo = new Circulo();
        Console.Write("Ingrese el radio del círculo: ");
        circulo.Radio = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Área del círculo: {circulo.CalcularArea()}");
        Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro()}");

        // Rectángulo
        Rectangulo rectangulo = new Rectangulo();
        Console.Write("Ingrese el largo del rectángulo: ");
        rectangulo.Largo = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingrese el ancho del rectángulo: ");
        rectangulo.Ancho = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"Área del rectángulo: {rectangulo.CalcularArea()}");
        Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro()}");
    }
}
