namespace DataStructuresLib.Interfaces
{
    public interface IList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
        void Insert(int index, T item);
        void RemoveAt(int index);
        int IndexOf(T item);
    }
}

