using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections; // ArrayList
using System.Collections.Generic; // List<T>

using VA;

class Program
{
    static void Main(string[] args)
    {
        // Створення векторів
        Vector v1 = new Vector("Red", 45.0, 10.0);
        Vector v2 = new Vector("Blue", 90.0, 5.0);
        Vector v3 = new Vector("Green", 30.0, 12.0);
        Vector v4 = new Vector("Yellow", 180.0, 7.0);
        Vector v5 = new Vector("Purple", 270.0, 8.5);

        // 1. Демонстрація Масива
        Console.WriteLine("Array (Vector[])");

        // Розмір масиву фіксований. «Додавання» - це запис у комірку.
        Vector[] vectorArray = new Vector[5];
        vectorArray[0] = v1;
        vectorArray[1] = v2;
        vectorArray[2] = v3;
        vectorArray[3] = v4;
        vectorArray[4] = v5;

        // Прохід (Traversal)
        Console.WriteLine("\nPassage through the array:");
        foreach (Vector v in vectorArray)
        {
            // Перевірка на null, так як видалення може залишити дірку
            if (v != null)
            {
                Console.WriteLine(v.ToString());
            }
        }

        // Update
        Console.WriteLine("\nUpdate (v1):");
        vectorArray[0].Angle = 99.0;
        Console.WriteLine(vectorArray[0]);

        // Search
        Console.WriteLine("\nSearch (Green):");
        foreach (Vector v in vectorArray)
        {
            if (v != null && v.LineColor == "Green")
            {
                Console.WriteLine($"Found: {v}");
            }
        }

        // Delete
        // Тількиприсвоїти null
        Console.WriteLine($"\nDeleting (v3)...");
        vectorArray[2] = null; 
        Console.WriteLine("Updated array:");
        foreach (Vector v in vectorArray)
        {
            Console.WriteLine(v?.ToString() ?? "NULL"); 
        }


        // 2. Демонстрація ArrayList (Non-Generic)
        Console.WriteLine("\n\nArrayList (Non-Generic)");

        // Add
        // Розмір динамічний. Зберігає все як 'object'.
        ArrayList nonGenericList = new ArrayList();
        nonGenericList.Add(v1); // Boxing
        nonGenericList.Add(v2);
        nonGenericList.Add(v3);
        nonGenericList.Add(v4);
        nonGenericList.Add(v5);

        // Прохоід (Traversal)
        Console.WriteLine("\nPassage through the ArrayList:");
        foreach (object obj in nonGenericList)
        {
            // Перевірка Unboxing
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine($"Extraneous element: {obj}");
            }
        }

        // Update
        Console.WriteLine("\nUpdating (v1):");
        if (nonGenericList[0] is Vector)
        {
            ((Vector)nonGenericList[0]).Angle = 88.0;
            Console.WriteLine((Vector)nonGenericList[0]);
        }

        // Search
        Console.WriteLine("\nSearching (Green):");
        foreach (object obj in nonGenericList)
        {
            if (obj is Vector v) 
            {
                if (v.LineColor == "Green")
                {
                    Console.WriteLine($"Found: {v}");
                }
            }
        }

        // Delete
        Console.WriteLine($"\nDeleting (v3)...");
        nonGenericList.Remove(v3);
        foreach (Vector v in nonGenericList)
        {
            Console.WriteLine(v);
        }


        // 3. Демонстрація List<T> (Generic)
        Console.WriteLine("\n\n List<Vector> (Generic)");

        // Динамічний розмір. Строга типізація!
        List<Vector> genericList = new List<Vector>();
        genericList.Add(v1);
        genericList.Add(v2);
        genericList.Add(v3);
        genericList.Add(v4);
        genericList.Add(v5);

        // Traversal
        Console.WriteLine("\nPassage through the List<Vector>:");
        foreach (Vector v in genericList)
        {
            Console.WriteLine(v);
        }

        // Update
        Console.WriteLine("\nUpdating (v1):");
        genericList[0].Angle = 77.0; 
        Console.WriteLine(genericList[0]);

        // Search
        Console.WriteLine("\nSearch (Green):");
        foreach (Vector v in genericList)
        {
            if (v.LineColor == "Green")
            {
                Console.WriteLine($"Found: {v}");
            }
        }

        // Delete
        Console.WriteLine($"\nDeleting (v3)...");
        genericList.Remove(v3);
        foreach (Vector v in genericList)
        {
            Console.WriteLine(v);
        }

        Console.WriteLine("\n\nDemonstration of Generic BinaryTree<Vector>");

        BinaryTree<Vector> vectorTree = new BinaryTree<Vector>();

        vectorTree.Root = new TreeNode<Vector>(v1);
        vectorTree.Root.Left = new TreeNode<Vector>(v2);
        vectorTree.Root.Right = new TreeNode<Vector>(v3);
        vectorTree.Root.Left.Left = new TreeNode<Vector>(v4);
        vectorTree.Root.Right.Right = new TreeNode<Vector>(v5);

        vectorTree.DisplayTree();

        Console.ReadKey();
    }
}