namespace DesignPatterns.Observer;

internal interface IPublisher
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
    void SetValue(int value);
}
