using System;
using DataStructuresLib.Interfaces;

namespace DataStructuresLib
{
    public class List<T> : IList<T>
    {
        private T[] _items;
        private int _count;

        public List()
        {
            _items = new T[4];
            _count = 0;
        }

        public List(int capacity)
        {
            _items = new T[capacity];
            _count = 0;
        }

        public int Count => _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            EnsureCapacity(_count + 1);
            _items[_count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();
            EnsureCapacity(_count + 1);
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = item;
            _count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException();
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[--_count] = default;
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = default;
            }
            _count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item)) return i;
            }
            return -1;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_items, array, _count);
            return array;
        }

        public void Reverse()
        {
            for (int i = 0, j = _count - 1; i < j; i++, j--)
            {
                T temp = _items[i];
                _items[i] = _items[j];
                _items[j] = temp;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (min > _items.Length)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                if (newCapacity < min) newCapacity = min;
                T[] newItems = new T[newCapacity];
                Array.Copy(_items, newItems, _count);
                _items = newItems;
            }
        }
    }
}


