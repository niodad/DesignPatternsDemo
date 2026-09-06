namespace DesignPatterns.Iterator;

internal class ConcreteAggregate<T> : IAggregate<T>
{
    private readonly List<T> items = [];

    public void Add(T item) => items.Add(item);

    public IIterator<T> CreateIterator() => new ConcreteIterator<T>(this);

    public int Count => items.Count;

    /// <summary>Replaces the item at <paramref name="index"/>; it does not insert.</summary>
    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }
}
