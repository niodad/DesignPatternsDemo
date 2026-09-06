namespace DesignPatterns.Duck;

internal class FlyWithWings : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying!");
}

internal class FlyNoWay : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I can't fly :(");
}
