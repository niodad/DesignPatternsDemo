namespace DesignPatterns.Decorator;

internal class Milk(IProduct product) : ProductDecorator(product)
{
    public override double Cost() => Product.Cost() + 0.20;

    public override string GetDescription() => $"{Product.GetDescription()}, melk";
}
