using System;
using System.Collections.Generic;

namespace BusquedaVuelosGrafo
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarEncabezado();
            
            // Crear el grafo de conexiones aéreas
            GrafoAeropuertos grafo = new GrafoAeropuertos();
            
            // Agregar aeropuertos (nodos)
            grafo.AgregarAeropuerto("QUITO"); // Quito
            grafo.AgregarAeropuerto("GUAYAQUIL"); // Guayaquil
            grafo.AgregarAeropuerto("CUENCA"); // Cuenca
            grafo.AgregarAeropuerto("MANTA"); // Manta
            grafo.AgregarAeropuerto("BOGOTA"); // Bogotá
            grafo.AgregarAeropuerto("LIMA"); // Lima
            
            // Agregar vuelos (aristas con precios)
            grafo.AgregarVuelo("QUITO", "GUAYAQUIL", 120);
            grafo.AgregarVuelo("QUITO", "CUENCA", 80);
            grafo.AgregarVuelo("QUITO", "MANTA", 90);
            grafo.AgregarVuelo("GUAYAQUIL", "MANTA", 50);
            grafo.AgregarVuelo("GUAYAQUIL", "BOGOTA", 200);
            grafo.AgregarVuelo("CUENCA", "LIMA", 180);
            grafo.AgregarVuelo("MANTA", "LIMA", 150);
            grafo.AgregarVuelo("BOGOTA", "LIMA", 220);
            
            // Mostrar todas las conexiones
            grafo.MostrarConexiones();
            
            // Buscar la ruta más económica
            Console.WriteLine("\nBuscando la ruta más económica...");
            Console.Write("Ingrese aeropuerto de origen: ");
            string origen = Console.ReadLine().ToUpper();
            Console.Write("Ingrese aeropuerto de destino: ");
            string destino = Console.ReadLine().ToUpper();
            
            grafo.EncontrarRutaMasEconomica(origen, destino);
        }
        
        static void MostrarEncabezado()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA       *");
            Console.WriteLine("*********************************************");
            Console.WriteLine("Nombre: KAREN AGUINDA");
            Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
            Console.WriteLine("Proyecto 4: Implementación y representación de grafos.");
            Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine();
        }
    }

    class GrafoAeropuertos
    {
        private Dictionary<string, Dictionary<string, int>> listaAdyacencia;
        
        public GrafoAeropuertos()
        {
            listaAdyacencia = new Dictionary<string, Dictionary<string, int>>();
        }
        
        public void AgregarAeropuerto(string codigo)
        {
            if (!listaAdyacencia.ContainsKey(codigo))
            {
                listaAdyacencia.Add(codigo, new Dictionary<string, int>());
            }
        }
        
        public void AgregarVuelo(string origen, string destino, int precio)
        {
            if (listaAdyacencia.ContainsKey(origen) && listaAdyacencia.ContainsKey(destino))
            {
                if (!listaAdyacencia[origen].ContainsKey(destino))
                {
                    listaAdyacencia[origen].Add(destino, precio);
                    // Para vuelos de ida y vuelta (grafo no dirigido)
                    listaAdyacencia[destino].Add(origen, precio); 
                }
            }
        }
        
        public void MostrarConexiones()
        {
            Console.WriteLine("\nConexiones disponibles:");
            foreach (var aeropuerto in listaAdyacencia)
            {
                Console.Write($"{aeropuerto.Key} -> ");
                foreach (var conexion in aeropuerto.Value)
                {
                    Console.Write($"{conexion.Key} (${conexion.Value}) ");
                }
                Console.WriteLine();
            }
        }
        
        public void EncontrarRutaMasEconomica(string origen, string destino)
        {
            if (!listaAdyacencia.ContainsKey(origen) || !listaAdyacencia.ContainsKey(destino))
            {
                Console.WriteLine("Uno o ambos aeropuertos no existen en la base de datos.");
                return;
            }
            
            // Implementación simplificada de Dijkstra
            var precios = new Dictionary<string, int>();
            var anteriores = new Dictionary<string, string>();
            var noVisitados = new List<string>();
            
            foreach (var aeropuerto in listaAdyacencia)
            {
                precios[aeropuerto.Key] = int.MaxValue;
                anteriores[aeropuerto.Key] = null;
                noVisitados.Add(aeropuerto.Key);
            }
            
            precios[origen] = 0;
            
            while (noVisitados.Count > 0)
            {
                // Encontrar el nodo con el precio mínimo
                string actual = null;
                foreach (string aeropuerto in noVisitados)
                {
                    if (actual == null || precios[aeropuerto] < precios[actual])
                    {
                        actual = aeropuerto;
                    }
                }
                
                if (actual == null || precios[actual] == int.MaxValue)
                    break;
                
                if (actual == destino)
                    break;
                
                noVisitados.Remove(actual);
                
                foreach (var vecino in listaAdyacencia[actual])
                {
                    int precioAlternativo = precios[actual] + vecino.Value;
                    if (precioAlternativo < precios[vecino.Key])
                    {
                        precios[vecino.Key] = precioAlternativo;
                        anteriores[vecino.Key] = actual;
                    }
                }
            }
            
            // Reconstruir la ruta
            var ruta = new List<string>();
            string actualRuta = destino;
            
            while (actualRuta != origen && actualRuta != null)
            {
                ruta.Add(actualRuta);
                actualRuta = anteriores[actualRuta];
            }
            
            if (actualRuta == null)
            {
                Console.WriteLine($"No hay ruta disponible entre {origen} y {destino}");
                return;
            }
            
            ruta.Add(origen);
            ruta.Reverse();
            
            Console.WriteLine("\nRuta más económica encontrada:");
            Console.WriteLine($"De {origen} a {destino} por ${precios[destino]}");
            Console.WriteLine("Ruta: " + string.Join(" -> ", ruta));
        }
    }
}