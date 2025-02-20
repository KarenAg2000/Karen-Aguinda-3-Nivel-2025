using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

class Program
{
    static void Main()
    {
        // Registrar la codificación de páginas de código
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        // Mostrar encabezado y datos de la tarea
        Console.WriteLine("***************************");
        Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA          *");
        Console.WriteLine("***************************");
        Console.WriteLine("Nombre: KAREN AGUINDA");
        Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
        Console.WriteLine("Semana 10 \n");
        Console.WriteLine("Tarea: El Gobierno Nacional a través de su Ministerio de Salud requiere algunos datos sobre la campaña de vacunación para la mitigación del COVID, en tal sentido se necesitan los siguientes datos: \n");
        Console.WriteLine("Listado de ciudadanos que no se han vacunado");
        Console.WriteLine("Listado de ciudadanos que han recibido las dos vacunas");
        Console.WriteLine("Listado de ciudadanos que solamente han recibido la vacuna de pfizer");
        Console.WriteLine("Listado de ciudadanos que solamente han recibido la vacuna de Astrazeneca \n");
        Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
        Console.WriteLine();

        // Crear los conjuntos de ciudadanos
        HashSet<string> totalCiudadanos = new HashSet<string>();
        HashSet<string> pfizerVacunados = new HashSet<string>();
        HashSet<string> astrazenecaVacunados = new HashSet<string>();

        // Llenar el conjunto de ciudadanos
        for (int i = 1; i <= 500; i++)
        {
            totalCiudadanos.Add($"Ciudadano_{i}");
        }

        // Llenar los conjuntos de vacunados (Aleatorio, 75 para cada vacuna)
        Random rand = new Random();
        var ciudadanosList = totalCiudadanos.ToList();
        var pfizerIds = ciudadanosList.OrderBy(x => rand.Next()).Take(75).ToList();
        var astrazenecaIds = ciudadanosList.OrderBy(x => rand.Next()).Take(75).ToList();

        pfizerVacunados = new HashSet<string>(pfizerIds);
        astrazenecaVacunados = new HashSet<string>(astrazenecaIds);

        // Operaciones de conjuntos
        var noVacunados = totalCiudadanos.Except(pfizerVacunados).Except(astrazenecaVacunados).ToList();
        var vacunadosAmbas = pfizerVacunados.Intersect(astrazenecaVacunados).ToList();
        var soloPfizer = pfizerVacunados.Except(astrazenecaVacunados).ToList();
        var soloAstrazeneca = astrazenecaVacunados.Except(pfizerVacunados).ToList();

        // Crear el documento PDF
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Reporte de Campaña de Vacunación COVID";
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Arial", 12, XFontStyle.Regular);

        // Escribir el título
        gfx.DrawString("Reporte de Campaña de Vacunación COVID", font, XBrushes.Black, 40, 40);

        // Escribir los listados de ciudadanos
        int yPos = 80;
        gfx.DrawString($"1. Ciudadanos que no se han vacunado: {noVacunados.Count}", font, XBrushes.Black, 40, yPos);
        yPos += 20;
        foreach (var ciudadano in noVacunados.Take(5)) // Mostrar los primeros 5 ciudadanos
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, 40, yPos);
            yPos += 20;
        }

        yPos += 10; // Espacio entre secciones
        gfx.DrawString($"2. Ciudadanos que han recibido ambas vacunas: {vacunadosAmbas.Count}", font, XBrushes.Black, 40, yPos);
        yPos += 20;
        foreach (var ciudadano in vacunadosAmbas.Take(5))
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, 40, yPos);
            yPos += 20;
        }

        yPos += 10;
        gfx.DrawString($"3. Ciudadanos que solo han recibido Pfizer: {soloPfizer.Count}", font, XBrushes.Black, 40, yPos);
        yPos += 20;
        foreach (var ciudadano in soloPfizer.Take(5))
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, 40, yPos);
            yPos += 20;
        }

        yPos += 10;
        gfx.DrawString($"4. Ciudadanos que solo han recibido AstraZeneca: {soloAstrazeneca.Count}", font, XBrushes.Black, 40, yPos);
        yPos += 20;
        foreach (var ciudadano in soloAstrazeneca.Take(5))
        {
            gfx.DrawString(ciudadano, font, XBrushes.Black, 40, yPos);
            yPos += 20;
        }

        // Guardar el PDF
        string fileName = "Reporte_Vacunacion_COVID.pdf";
        document.Save(fileName);
        Console.WriteLine($"Reporte generado exitosamente: {fileName}");
    }
}
