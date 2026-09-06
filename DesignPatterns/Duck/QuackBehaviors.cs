namespace DesignPatterns.Duck;

// Explicit interface implementation: C# forbids a method that has the same name
// as its enclosing type ("Quack"), so both behaviors implement it this way to stay consistent.
internal class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack() => Console.WriteLine("Quack");
}

internal class Squeak : IQuackBehavior
{
    void IQuackBehavior.Quack() => Console.WriteLine("Squeak");
}
