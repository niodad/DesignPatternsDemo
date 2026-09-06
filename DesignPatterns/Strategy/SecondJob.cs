namespace DesignPatterns.Strategy;

internal class SecondJob : Job
{
    public SecondJob() : base(new SecondStrategy())
    {
    }
}
