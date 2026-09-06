namespace DesignPatterns.Decorator;

/// <summary>
/// Base class for decorators: it is an <see cref="IProduct"/> and wraps one,
/// forwarding calls so concrete decorators only override what they change.
/// </summary>
internal abstract class ProductDecorator(IProduct product) : IProduct
{
    protected IProduct Product { get; } = product ?? throw new ArgumentNullException(nameof(product));

    public virtual double Cost() => Product.Cost();

    public virtual string GetDescription() => Product.GetDescription();
}
