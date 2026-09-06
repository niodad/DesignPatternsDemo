namespace DesignPatterns.Decorator;

internal class Sugar(IProduct product) : ProductDecorator(product)
{
    public override double Cost() => Product.Cost() + 0.10;

    public override string GetDescription() => $"{Product.GetDescription()}, suiker";
}
