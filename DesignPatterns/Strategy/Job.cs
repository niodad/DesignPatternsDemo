namespace DesignPatterns.Strategy;

internal class Job
{
    private IStrategy strategy;

    public Job(IStrategy strategy)
    {
        ArgumentNullException.ThrowIfNull(strategy);
        this.strategy = strategy;
    }

    public IStrategy Strategy
    {
        get => strategy;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            strategy = value;
        }
    }

    public void DoJob()
    {
        Strategy.DoJob();
    }
}
