namespace DesignPatterns.Strategy;

internal class FirstJob : Job
{
    public FirstJob() : base(new FirstStrategy())
    {
    }
}
