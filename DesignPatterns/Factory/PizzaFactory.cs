namespace DesignPatterns.Factory;

/// <summary>Simple factory: one place that decides which concrete pizza to build.</summary>
internal static class PizzaFactory
{
    public static IPizza CreatePizza(PizzaType type) => type switch
    {
        PizzaType.Napoli => new PizzaNapoli(),
        PizzaType.Margherita => new PizzaMargherita(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown pizza type")
    };
}
