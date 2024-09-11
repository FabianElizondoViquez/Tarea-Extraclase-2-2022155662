using System;
using System.Collections.Generic;

public class OrderedList
{
    private List<int> list;
    private int middleIndex;

    public OrderedList()
    {
        list = new List<int>();
        middleIndex = -1;
    }

    public void InsertInOrder(int value)
    {
        int index = list.BinarySearch(value);
        if (index < 0) index = ~index;
        list.Insert(index, value);

        // Update middle index
        middleIndex = list.Count / 2;
    }

    public int GetMiddle()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("La lista está vacía.");
        return list[middleIndex];
    }

    // Método para obtener la lista completa
    public List<int> GetList()
    {
        return list;
    }
}