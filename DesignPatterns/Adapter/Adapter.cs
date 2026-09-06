namespace DesignPatterns.Adapter;

/// <summary>
/// Wraps a <see cref="ServiceToAdapt"/> instance and exposes it through the
/// <see cref="IClient"/> interface, translating the parameterless call into the
/// arguments the adaptee needs and turning its return value into console output.
/// </summary>
internal class Adapter : IClient
{
    private readonly ServiceToAdapt adaptee;

    public Adapter(ServiceToAdapt adaptee)
    {
        ArgumentNullException.ThrowIfNull(adaptee);
        this.adaptee = adaptee;
    }

    public Adapter() : this(new ServiceToAdapt())
    {
    }

    public void DoJob()
    {
        var result = adaptee.RunTask("Work", 2);
        Console.WriteLine(result);
    }
}
