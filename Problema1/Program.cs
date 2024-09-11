using System;

namespace Problema1
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public interface Lista<T> where T : IComparable
    {
        void Add(T value);
        void MergeSorted(ListaDoble<T> otherList, SortDirection direction);
        void PrintList();
    }

    public class Nodo<T>
    {
        public T Valor { get; set; }
        public Nodo<T> Anterior { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Anterior = null;
            Siguiente = null;
        }
    }

    public class ListaDoble<T> : Lista<T> where T : IComparable
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
        }

        public void Add(T value)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(value);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
        }

        public void MergeSorted(ListaDoble<T> otherList, SortDirection direction)
        {
            Nodo<T> currentA = cabeza;
            Nodo<T> currentB = otherList.cabeza;

            ListaDoble<T> mergedList = new ListaDoble<T>();

            while (currentA != null && currentB != null)
            {
                int comparison = currentA.Valor.CompareTo(currentB.Valor);
                if ((direction == SortDirection.Ascending && comparison <= 0) ||
                    (direction == SortDirection.Descending && comparison > 0))
                {
                    mergedList.Add(currentA.Valor);
                    currentA = currentA.Siguiente;
                }
                else
                {
                    mergedList.Add(currentB.Valor);
                    currentB = currentB.Siguiente;
                }
            }

            while (currentA != null)
            {
                mergedList.Add(currentA.Valor);
                currentA = currentA.Siguiente;
            }

            while (currentB != null)
            {
                mergedList.Add(currentB.Valor);
                currentB = currentB.Siguiente;
            }

            if (direction == SortDirection.Descending)
            {
                InvertList(mergedList);
            }

            cabeza = mergedList.cabeza;
            cola = mergedList.cola;
        }

        private void InvertList(ListaDoble<T> list)
        {
            Nodo<T> current = list.cabeza;
            Nodo<T> prev = null;
            Nodo<T> next = null;

            while (current != null)
            {
                next = current.Siguiente;
                current.Siguiente = prev;
                current.Anterior = next;
                prev = current;
                current = next;
            }

            list.cabeza = prev;

            // Ajustar la cola
            list.cola = list.cabeza;
            while (list.cola.Siguiente != null)
            {
                list.cola = list.cola.Siguiente;
            }
        }

        public void PrintList()
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main()
        {
            ListaDoble<int> listA = new ListaDoble<int>();
            listA.Add(0);
            listA.Add(2);
            listA.Add(6);
            listA.Add(10);
            listA.Add(25);
            
            ListaDoble<int> listB = new ListaDoble<int>();
            listB.Add(3);
            listB.Add(7);
            listB.Add(11);
            listB.Add(40);
            listB.Add(50);

            Console.WriteLine("Lista A antes de la mezcla:");
            listA.PrintList();

            Console.WriteLine("Lista B:");
            listB.PrintList();

            listA.MergeSorted(listB, SortDirection.Ascending);
            Console.WriteLine("Lista A después de mezclar en orden ascendente:");
            listA.PrintList();

            // Reset listA to original state
            listA = new ListaDoble<int>();
            listA.Add(0);
            listA.Add(2);
            listA.Add(6);
            listA.Add(10);
            listA.Add(25);

            listA.MergeSorted(listB, SortDirection.Descending);
            Console.WriteLine("Lista A después de mezclar en orden descendente:");
            listA.PrintList();
        }
    }
}
