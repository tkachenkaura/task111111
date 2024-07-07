using System;
using System.Collections.Generic;
using DataStructuresLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(1, 4);
            list.Remove(2);
            list.RemoveAt(0);
            Console.WriteLine("List contains 4: " + list.Contains(4));
            Console.WriteLine("Index of 3: " + list.IndexOf(3));
            Console.WriteLine("List elements: " + string.Join(", ", list.ToArray()));
            list.Reverse();
            Console.WriteLine("Reversed list elements: " + string.Join(", ", list.ToArray()));

            
            BinaryTree tree = new BinaryTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(8);
            tree.Add(1);
            tree.Add(4);
            Console.WriteLine("Tree contains 3: " + tree.Contains(3));
            Console.WriteLine("Tree contains 6: " + tree.Contains(6));
            Console.WriteLine("Tree elements: " + string.Join(", ", tree.ToArray()));
            tree.Clear();
            Console.WriteLine("Tree count after clear: " + tree.Count);

           
            SinglyLinkedList singlyList = new SinglyLinkedList();
            singlyList.Add(1);
            singlyList.Add(2);
            singlyList.Add(3);
            singlyList.AddFirst(0);
            singlyList.Insert(2, 1.5);
            Console.WriteLine("SinglyLinkedList contains 2: " + singlyList.Contains(2));
            Console.WriteLine("SinglyLinkedList elements: " + string.Join(", ", singlyList.ToArray()));

            DoublyLinkedList doublyList = new DoublyLinkedList();
            doublyList.Add(1);
            doublyList.Add(2);
            doublyList.Add(3);
            doublyList.AddFirst(0);
            doublyList.Insert(2, 1.5);
            doublyList.Remove(2);
            doublyList.RemoveFirst();
            doublyList.RemoveLast();
            Console.WriteLine("DoublyLinkedList contains 2: " + doublyList.Contains(2));
            Console.WriteLine("DoublyLinkedList elements: " + string.Join(", ", doublyList.ToArray()));

           
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("Queue contains 2: " + queue.Contains(2));
            Console.WriteLine("Queue elements: " + string.Join(", ", queue.ToArray()));
            Console.WriteLine("Dequeued element: " + queue.Dequeue());
            Console.WriteLine("Queue elements after dequeue: " + string.Join(", ", queue.ToArray()));

            
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Stack contains 2: " + stack.Contains(2));
            Console.WriteLine("Stack elements: " + string.Join(", ", stack.ToArray()));
            Console.WriteLine("Popped element: " + stack.Pop());
            Console.WriteLine("Stack elements after pop: " + string.Join(", ", stack.ToArray()));
        }
    }
}