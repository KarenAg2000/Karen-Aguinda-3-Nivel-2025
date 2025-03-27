using System;
using System.Collections.Generic;

namespace ArbolBinarioApp
{
    // Clase que representa un nodo del árbol binario
    class Nodo
    {
        public int Valor { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase que implementa el árbol binario de búsqueda
    class ArbolBinario
    {
        private Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        // Método público para insertar un valor
        public void Insertar(int valor)
        {
            raiz = InsertarRec(raiz, valor);
        }

        // Método privado recursivo para insertar
        private Nodo InsertarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRec(nodo.Derecho, valor);
            }

            return nodo;
        }

        // Método público para buscar un valor
        public bool Buscar(int valor)
        {
            return BuscarRec(raiz, valor);
        }

        // Método privado recursivo para buscar
        private bool BuscarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return false;
            }

            if (valor == nodo.Valor)
            {
                return true;
            }

            return valor < nodo.Valor 
                ? BuscarRec(nodo.Izquierdo, valor) 
                : BuscarRec(nodo.Derecho, valor);
        }

        // Método público para eliminar un valor
        public void Eliminar(int valor)
        {
            raiz = EliminarRec(raiz, valor);
        }

        // Método privado recursivo para eliminar
        private Nodo EliminarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return nodo;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRec(nodo.Derecho, valor);
            }
            else
            {
                // Nodo con un solo hijo o sin hijos
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                // Nodo con dos hijos: obtener el sucesor in-order (mínimo en el subárbol derecho)
                nodo.Valor = MinValor(nodo.Derecho);

                // Eliminar el sucesor in-order
                nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
            }

            return nodo;
        }

        // Método para encontrar el valor mínimo en un subárbol
        private int MinValor(Nodo nodo)
        {
            int min = nodo.Valor;
            while (nodo.Izquierdo != null)
            {
                min = nodo.Izquierdo.Valor;
                nodo = nodo.Izquierdo;
            }
            return min;
        }

        // Métodos de recorrido del árbol
        public void InOrder()
        {
            InOrderRec(raiz);
            Console.WriteLine();
        }

        private void InOrderRec(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrderRec(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                InOrderRec(nodo.Derecho);
            }
        }

        public void PreOrder()
        {
            PreOrderRec(raiz);
            Console.WriteLine();
        }

        private void PreOrderRec(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                PreOrderRec(nodo.Izquierdo);
                PreOrderRec(nodo.Derecho);
            }
        }

        public void PostOrder()
        {
            PostOrderRec(raiz);
            Console.WriteLine();
        }

        private void PostOrderRec(Nodo nodo)
        {
            if (nodo != null)
            {
                PostOrderRec(nodo.Izquierdo);
                PostOrderRec(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }

        public void LevelOrder()
        {
            if (raiz == null)
            {
                return;
            }

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Nodo temp = cola.Dequeue();
                Console.Write(temp.Valor + " ");

                if (temp.Izquierdo != null)
                {
                    cola.Enqueue(temp.Izquierdo);
                }

                if (temp.Derecho != null)
                {
                    cola.Enqueue(temp.Derecho);
                }
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("*       UNIVERSIDAD ESTATAL AMAZONICA       *");
            Console.WriteLine("*********************************************");
            Console.WriteLine("Nombre: KAREN AGUINDA");
            Console.WriteLine("Materia: ESTRUCTURA DE DATOS");
            Console.WriteLine("Ejercicio: Ejemplo de árboles binarios, con tipos de datos primitivos (enteros, cadenas, etc.) o de objetos a su elección, para demostrar las principales operaciones contenidas en las diapositivas de esta semana. La aplicación deberá contener un menú para mostrar cada una de las operaciones y el registro de datos dentro del árbol, se lo realizará mediante teclado.");
            Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine();

            ArbolBinario arbol = new ArbolBinario();
            int opcion;
            int valor;

            do
            {
                Console.WriteLine("\nMENÚ DEL ÁRBOL BINARIO");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Recorrido In-Order");
                Console.WriteLine("5. Recorrido Pre-Order");
                Console.WriteLine("6. Recorrido Post-Order");
                Console.WriteLine("7. Recorrido Level-Order");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada no válida. Intente nuevamente.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            arbol.Insertar(valor);
                            Console.WriteLine($"Valor {valor} insertado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            Console.WriteLine(arbol.Buscar(valor) 
                                ? $"El valor {valor} está en el árbol." 
                                : $"El valor {valor} no está en el árbol.");
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            arbol.Eliminar(valor);
                            Console.WriteLine($"Valor {valor} eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Valor no válido.");
                        }
                        break;

                    case 4:
                        Console.Write("Recorrido In-Order: ");
                        arbol.InOrder();
                        break;

                    case 5:
                        Console.Write("Recorrido Pre-Order: ");
                        arbol.PreOrder();
                        break;

                    case 6:
                        Console.Write("Recorrido Post-Order: ");
                        arbol.PostOrder();
                        break;

                    case 7:
                        Console.Write("Recorrido Level-Order: ");
                        arbol.LevelOrder();
                        break;

                    case 8:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 8);
        }
    }
}