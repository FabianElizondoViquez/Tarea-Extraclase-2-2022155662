using System;

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

    // Método para añadir un nodo al final de la lista
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

    // Método para mezclar dos listas doblemente enlazadas en orden ascendente o descendente
    public void MergeSorted(ListaDoble<T> otherList, SortDirection direction)
    {
        Nodo<T> currentA = cabeza;
        Nodo<T> currentB = otherList.cabeza;

        ListaDoble<T> mergedList = new ListaDoble<T>();

        while (currentA != null && currentB != null)
        {
            int comparison = currentA.Valor.CompareTo(currentB.Valor);
            if ((direction == SortDirection.Ascending && comparison <= 0) ||
                (direction == SortDirection.Descending && comparison >= 0))
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

        // Añadir nodos restantes de la lista A
        while (currentA != null)
        {
            mergedList.Add(currentA.Valor);
            currentA = currentA.Siguiente;
        }

        // Añadir nodos restantes de la lista B
        while (currentB != null)
        {
            mergedList.Add(currentB.Valor);
            currentB = currentB.Siguiente;
        }

        // Copiar el contenido de mergedList a la lista actual (listA)
        cabeza = mergedList.cabeza;
        cola = mergedList.cola;
    }

    // Método para imprimir la lista
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
