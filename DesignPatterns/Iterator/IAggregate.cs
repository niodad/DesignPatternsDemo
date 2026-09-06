namespace DesignPatterns.Iterator;

internal interface IAggregate<T>
{
    int Count { get; }
    T this[int index] { get; set; }
    void Add(T item);
    IIterator<T> CreateIterator();
}
