namespace DesignPatterns.Adapter;

/// <summary>
/// The adaptee: an existing service with an interface the client cannot use directly.
/// It needs parameters and returns a result instead of writing to the console.
/// </summary>
internal class ServiceToAdapt
{
    public string RunTask(string taskName, int repeat)
    {
        return string.Join(", ", Enumerable.Repeat($"{taskName} done", repeat));
    }
}
