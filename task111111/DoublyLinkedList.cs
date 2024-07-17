using System;
using DataStructuresLib.Interfaces;

namespace DataStructuresLib
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        private int _count;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public int Count => _count;

        public void Add(T item)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            _count++;
        }

        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        _head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        _tail = current.Previous;
                    }

                    _count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = _head;
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
            DoublyLinkedListNode<T> current = _head;
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
