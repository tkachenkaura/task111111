using System;
using DataStructuresLib.Interfaces;

namespace DataStructuresLib
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        private SinglyLinkedListNode<T> _head;
        private int _count;

        public SinglyLinkedList()
        {
            _head = null;
            _count = 0;
        }

        public int Count => _count;

        public void Add(T item)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(item);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                SinglyLinkedListNode<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            _count++;
        }

        public bool Remove(T item)
        {
            SinglyLinkedListNode<T> current = _head;
            SinglyLinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    _count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            SinglyLinkedListNode<T> current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            SinglyLinkedListNode<T> current = _head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }
}
