namespace DesignPatterns.Iterator;

internal class ConcreteIterator<T> : IIterator<T>
{
    private readonly IAggregate<T> aggregate;
    private int current;

    public ConcreteIterator(IAggregate<T> aggregate)
    {
        ArgumentNullException.ThrowIfNull(aggregate);
        this.aggregate = aggregate;
    }

    public T? CurrentItem() => IsDone() ? default : aggregate[current];

    public T? First()
    {
        current = 0;
        return CurrentItem();
    }

    public bool IsDone() => current >= aggregate.Count;

    public T? Next()
    {
        if (!IsDone())
        {
            current++;
        }
        return CurrentItem();
    }
}
