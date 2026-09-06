namespace DesignPatterns.Duck;

internal class MallardDuck() : Duck(new FlyWithWings(), new Quack())
{
    public override void Display() => Console.WriteLine("I'm a mallard duck.");
}
