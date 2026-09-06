namespace DesignPatterns.Factory;

/// <summary>Shares the identical preparation steps so concrete pizzas only differ in their description.</summary>
internal abstract class Pizza : IPizza
{
    public abstract string GetDescription();

    public void Prepare() => Console.WriteLine("Preparing");

    public void Bake() => Console.WriteLine("Baking");

    public void Cut() => Console.WriteLine("Cutting");

    public void Box() => Console.WriteLine("Boxing");
}
