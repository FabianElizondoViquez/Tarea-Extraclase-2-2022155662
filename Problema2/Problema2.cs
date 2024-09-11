using System;

public class Node
{
    public int Data;
    public Node Next;
    public Node Prev;

    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class DoublyLinkedList
{
    public Node Head;

    public void Invert()
    {
        Node current = Head;
        Node temp = null;

        while (current != null)
        {
            // Intercambiar los punteros next y prev
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;

            // Moverse al siguiente nodo en la lista original
            current = current.Prev;
        }

        // Ajustar la cabeza de la lista
        if (temp != null)
        {
            Head = temp.Prev;
        }
    }
}
