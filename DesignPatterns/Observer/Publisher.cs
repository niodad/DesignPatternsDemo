namespace DesignPatterns.Observer;

internal class Publisher : IPublisher
{
    private readonly List<IObserver> observers = [];

    public int Value { get; private set; }

    public void RegisterObserver(IObserver o)
    {
        ArgumentNullException.ThrowIfNull(o);
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        // Iterate a snapshot so observers added or removed during a notification
        // only take effect on the next one.
        foreach (var observer in observers.ToArray())
        {
            observer.Update(Value);
        }
    }

    public void SetValue(int value)
    {
        Value = value;
        NotifyObservers();
    }
}
