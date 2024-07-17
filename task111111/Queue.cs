using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using DataStructuresLib.Interfaces;

namespace DataStructuresLib
{
    public class Queue : ICollection
    {
        private object[] _items;
        private int _count;
        private int _head;
        private int _tail;

        public Queue()
        {
            _items = new object[4];
            _count = 0;
            _head = 0;
            _tail = 0;
        }

        public int Count => _count;

        public void Enqueue(object item)
        {
            EnsureCapacity(_count + 1);
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        public object Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty");

            object value = _items[_head];
            _items[_head] = null;
            _head = (_head + 1) % _items.Length;
            _count--;
            return value;
        }

        public bool Remove(object item)
        {
            if (_count == 0)
                return false;

            int index = Array.IndexOf(_items, item, _head, _count);
            if (index >= 0)
            {
                for (int i = index; i < _tail - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _items[_tail - 1] = null;
                _tail = (_tail - 1) % _items.Length;
                _count--;
                return true;
            }
            return false;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _items.Length);
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public bool Contains(object item)
        {
            return Array.IndexOf(_items, item, _head, _count) >= 0;
        }

        public object[] ToArray()
        {
            object[] array = new object[_count];
            for (int i = 0; i < _count; i++)
            {
                array[i] = _items[(_head + i) % _items.Length];
            }
            return array;
        }

        private void EnsureCapacity(int min)
        {
            if (min > _items.Length)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if (newCapacity < min) newCapacity = min;
                object[] newItems = new object[newCapacity];
                if (_count > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_items, _head, newItems, 0, _count);
                    }
                    else
                    {
                        Array.Copy(_items, _head, newItems, 0, _items.Length - _head);
                        Array.Copy(_items, 0, newItems, _items.Length - _head, _tail);
                    }
                }
                _items = newItems;
                _head = 0;
                _tail = _count == newCapacity ? 0 : _count;
            }
        }
    }
}
