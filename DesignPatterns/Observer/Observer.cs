namespace DesignPatterns.Observer;

internal class Observer : IObserver
{
    public void Update(int value)
    {
        Console.WriteLine($"Value ({value}) from Publisher handled.");
    }
}
