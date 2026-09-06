namespace DesignPatterns.Duck;

/// <summary>
/// Strategy pattern: a duck delegates flying and quacking to behaviour objects
/// that can be swapped at runtime.
/// </summary>
internal abstract class Duck
{
    private IFlyBehavior flyBehavior;
    private IQuackBehavior quackBehavior;

    protected Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
    {
        ArgumentNullException.ThrowIfNull(flyBehavior);
        ArgumentNullException.ThrowIfNull(quackBehavior);
        this.flyBehavior = flyBehavior;
        this.quackBehavior = quackBehavior;
    }

    public IFlyBehavior FlyBehavior
    {
        get => flyBehavior;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            flyBehavior = value;
        }
    }

    public IQuackBehavior QuackBehavior
    {
        get => quackBehavior;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            quackBehavior = value;
        }
    }

    public abstract void Display();

    public void Fly() => FlyBehavior.Fly();

    public void Quack() => QuackBehavior.Quack();

    public void Swim() => Console.WriteLine("I'm swimming.");
}
