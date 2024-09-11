using System;

public class Program
{
    public static void Main()
    {
        OrderedList orderedList = new OrderedList();
        orderedList.InsertInOrder(3);
        orderedList.InsertInOrder(1);
        orderedList.InsertInOrder(4);
        orderedList.InsertInOrder(2);
        orderedList.InsertInOrder(0);

        // Mostrar la lista original
        Console.WriteLine("Lista original: " + string.Join(", ", orderedList.GetList()));

        // Mostrar el elemento central
        Console.WriteLine("Elemento central: " + orderedList.GetMiddle()); // Debería imprimir 2
    }
}
