namespace DesignPatterns.Decorator;

/// <summary>The concrete component that decorators wrap.</summary>
internal class Product : IProduct
{
    public double Cost() => 2.0;

    public string GetDescription() => "Koffie";
}
