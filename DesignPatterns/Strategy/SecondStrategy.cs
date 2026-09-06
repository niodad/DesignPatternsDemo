namespace DesignPatterns.Strategy;

internal class SecondStrategy : IStrategy
{
    public void DoJob()
    {
        Console.WriteLine("Second strategy executed");
    }
}
