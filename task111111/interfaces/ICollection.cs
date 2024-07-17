namespace DataStructuresLib.Interfaces
{
    public interface ICollection<T>
    {
        int Count { get; }
        void Add(T item);
        bool Remove(T item);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}


