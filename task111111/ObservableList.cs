using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections;
using System.Collections.Generic;
using DataStructuresLib.Interfaces;

namespace DataStructuresLib
{
    public class ObservableList<T> : IList<T>
    {
        private readonly List<T> _internalList = new List<T>();

        public event EventHandler<EventArgs> ItemAdded;
        public event EventHandler<EventArgs> ItemRemoved;

        public int Count => _internalList.Count;
        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => _internalList[index];
            set => _internalList[index] = value;
        }

        public void Add(T item)
        {
            _internalList.Add(item);
            ItemAdded?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            _internalList.Clear();
            ItemRemoved?.Invoke(this, EventArgs.Empty);
        }

        public bool Contains(T item)
        {
            return _internalList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(_internalList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _internalList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _internalList.Insert(index, item);
            ItemAdded?.Invoke(this, EventArgs.Empty);
        }

        public bool Remove(T item)
        {
            var removed = _internalList.Remove(item);
            if (removed)
            {
                ItemRemoved?.Invoke(this, EventArgs.Empty);
            }
            return removed;
        }

        public void RemoveAt(int index)
        {
            _internalList.RemoveAt(index);
            ItemRemoved?.Invoke(this, EventArgs.Empty);
        }

        private class ListEnumerator<T> : IEnumerator<T>
        {
            private readonly IList<T> _list;
            private int _position = -1;

            public ListEnumerator(IList<T> list)
            {
                _list = list;
            }

            public T Current => _list[_position];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _position++;
                return _position < _list.Count;
            }

            public void Reset()
            {
                _position = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
