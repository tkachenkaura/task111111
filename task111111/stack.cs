using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task111111
{
    using DataStructuresLib.Interfaces;
    {
        public class Stack
        {
            private SinglyLinkedListNode _top;
            private int _count;

            public int Count => _count;

            public void Push(object value)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(value);
                node.Next = _top;
                _top = node;
                _count++;
            }

            public object Pop()
            {
                if (_top == null)
                    throw new InvalidOperationException("Stack is empty.");

                object value = _top.Value;
                _top = _top.Next;
                _count--;
                return value;
            }

            public void Clear()
            {
                _top = null;
                _count = 0;
            }

            public bool Contains(object value)
            {
                SinglyLinkedListNode current = _top;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                        return true;
                    current = current.Next;
                }
                return false;
            }

            public object Peek()
            {
                if (_top == null)
                    throw new InvalidOperationException("Stack is empty.");
                return _top.Value;
            }

            public object[] ToArray()
            {
                object[] array = new object[_count];
                SinglyLinkedListNode current = _top;
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

}
