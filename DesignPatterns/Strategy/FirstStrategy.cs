namespace DesignPatterns.Strategy;

internal class FirstStrategy : IStrategy
{
    public void DoJob()
    {
        Console.WriteLine("First strategy executed");
    }
}
