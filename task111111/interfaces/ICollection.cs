namespace DataStructuresLib.Interfaces
{
    public interface ICollection
    {
        int Count { get; }
        void Add(object item);
        bool Remove(object item);
        void Clear();
        bool Contains(object item);
        object[] ToArray();
    }
}

