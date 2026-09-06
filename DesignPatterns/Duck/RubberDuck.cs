namespace DesignPatterns.Duck;

internal class RubberDuck() : Duck(new FlyNoWay(), new Squeak())
{
    public override void Display() => Console.WriteLine("I'm a rubber duck.");
}
