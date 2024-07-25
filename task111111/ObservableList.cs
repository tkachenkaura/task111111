using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task111111
{
    

    namespace DataStructuresLib
    {
        public class ItemAddedEventArgs<T> : EventArgs
        {
            public T Item { get; }

            public ItemAddedEventArgs(T item)
            {
                Item = item;
            }
        }

        public class ItemRemovedEventArgs<T> : EventArgs
        {
            public T Item { get; }

            public ItemRemovedEventArgs(T item)
            {
                Item = item;
            }
        }

        public class ItemInsertedEventArgs<T> : EventArgs
        {
            public T Item { get; }
            public int Index { get; }

            public ItemInsertedEventArgs(T item, int index)
            {
                Item = item;
                Index = index;
            }
        }

        public class ObservableList<T> : IList<T>
        {
            private readonly List<T> _internalList = new List<T>();

            public event EventHandler<ItemAddedEventArgs<T>> ItemAdded;
            public event EventHandler<ItemRemovedEventArgs<T>> ItemRemoved;
            public event EventHandler<ItemInsertedEventArgs<T>> ItemInserted;

            protected virtual void OnItemAdded(T item)
            {
                ItemAdded?.Invoke(this, new ItemAddedEventArgs<T>(item));
            }

            protected virtual void OnItemRemoved(T item)
            {
                ItemRemoved?.Invoke(this, new ItemRemovedEventArgs<T>(item));
            }

            protected virtual void OnItemInserted(T item, int index)
            {
                ItemInserted?.Invoke(this, new ItemInsertedEventArgs<T>(item, index));
            }

            public T this[int index]
            {
                get => _internalList[index];
                set => _internalList[index] = value;
            }

            public int Count => _internalList.Count;
            public bool IsReadOnly => ((ICollection<T>)_internalList).IsReadOnly;

            public void Add(T item)
            {
                _internalList.Add(item);
                OnItemAdded(item);
            }

            public void Clear()
            {
                var items = new List<T>(_internalList);
                _internalList.Clear();
                foreach (var item in items)
                {
                    OnItemRemoved(item);
                }
            }

            public bool Contains(T item) => _internalList.Contains(item);

            public void CopyTo(T[] array, int arrayIndex) => _internalList.CopyTo(array, arrayIndex);

            public IEnumerator<T> GetEnumerator() => _internalList.GetEnumerator();

            public int IndexOf(T item) => _internalList.IndexOf(item);

            public void Insert(int index, T item)
            {
                _internalList.Insert(index, item);
                OnItemInserted(item, index);
            }

            public bool Remove(T item)
            {
                bool removed = _internalList.Remove(item);
                if (removed)
                {
                    OnItemRemoved(item);
                }
                return removed;
            }

            public void RemoveAt(int index)
            {
                var item = _internalList[index];
                _internalList.RemoveAt(index);
                OnItemRemoved(item);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _internalList.GetEnumerator();
        }
    }

}
