using System;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList list = new DoublyLinkedList();

        // Agregar nodos a la lista
        list.Head = new Node(1);
        list.Head.Next = new Node(0);
        list.Head.Next.Prev = list.Head;
        list.Head.Next.Next = new Node(30);
        list.Head.Next.Next.Prev = list.Head.Next;
        list.Head.Next.Next.Next = new Node(50);
        list.Head.Next.Next.Next.Prev = list.Head.Next.Next;
        list.Head.Next.Next.Next.Next = new Node(2);
        list.Head.Next.Next.Next.Next.Prev = list.Head.Next.Next.Next;

        Console.WriteLine("Lista original:");
        PrintList(list);

        // Invertir la lista
        list.Invert();

        Console.WriteLine("Lista invertida:");
        PrintList(list);
    }

    static void PrintList(DoublyLinkedList list)
    {
        Node current = list.Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}
