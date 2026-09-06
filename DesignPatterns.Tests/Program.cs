using DesignPatterns.Adapter;
using DesignPatterns.Decorator;
using DesignPatterns.Duck;
using DesignPatterns.Factory;
using DesignPatterns.Iterator;
using DesignPatterns.Observer;
using DesignPatterns.Strategy;

var tests = new (string Name, Action Run)[]
{
    ("Iterator can restart", () =>
    {
        var items = new ConcreteAggregate<string>();
        items.Add("A"); items.Add("B"); items.Add("C");
        var iterator = items.CreateIterator();
        Check(iterator.First() == "A", "First item");
        Check(iterator.Next() == "B", "Second item");
        Check(iterator.First() == "A", "Restart");
        Check(iterator.CurrentItem() == "A", "Current position after restart");
        Check(iterator.Next() == "B", "Next position after restart");
        iterator.Next(); iterator.Next();
        Check(iterator.IsDone(), "Completed");
        Check(iterator.First() == "A" && !iterator.IsDone(), "Restart after completion");
    }),
    ("Empty iterator and repeated completion are safe", () =>
    {
        var iterator = new ConcreteAggregate<string>().CreateIterator();
        Check(iterator.First() is null && iterator.IsDone(), "Empty first");
        Check(iterator.CurrentItem() is null, "Empty current");
        Check(iterator.Next() is null && iterator.Next() is null, "Repeated next");
    }),
    ("Iteration includes null and default values", () =>
    {
        var strings = new ConcreteAggregate<string?>();
        strings.Add(null); strings.Add("B");
        var iterator = strings.CreateIterator();
        var visited = new List<string?>();
        for (iterator.First(); !iterator.IsDone(); iterator.Next())
            visited.Add(iterator.CurrentItem());
        Check(visited.SequenceEqual(new string?[] { null, "B" }), "Null is an item");
        var numbers = new ConcreteAggregate<int>();
        numbers.Add(0); numbers.Add(1);
        var ints = numbers.CreateIterator();
        var values = new List<int>();
        for (ints.First(); !ints.IsDone(); ints.Next())
            values.Add(ints.CurrentItem());
        Check(values.SequenceEqual(new[] { 0, 1 }), "Zero is an item");
    }),
    ("Indexer replaces without inserting", () =>
    {
        var items = new ConcreteAggregate<string>();
        items.Add("A"); items.Add("B");
        items[0] = "New";
        Check(items.Count == 2 && items[0] == "New" && items[1] == "B", "Replacement");
    }),
    ("Observer can unsubscribe during notification", () =>
    {
        var publisher = new Publisher();
        var self = new CallbackObserver();
        var other = new CallbackObserver();
        self.OnUpdate = _ => publisher.RemoveObserver(self);
        publisher.RegisterObserver(self); publisher.RegisterObserver(other);
        publisher.SetValue(10); publisher.SetValue(20);
        Check(self.Values.SequenceEqual(new[] { 10 }), "Self unsubscribed");
        Check(other.Values.SequenceEqual(new[] { 10, 20 }), "Other observer continues");
    }),
    ("Observer registered during notification starts next time", () =>
    {
        var publisher = new Publisher();
        var added = new CallbackObserver();
        var first = new CallbackObserver();
        first.OnUpdate = _ =>
        {
            publisher.RegisterObserver(added);
            first.OnUpdate = null;
        };
        publisher.RegisterObserver(first);
        publisher.SetValue(10); publisher.SetValue(20);
        Check(added.Values.SequenceEqual(new[] { 20 }), "Snapshot semantics");
    }),
    ("Observer rejects a null subscriber", () =>
    {
        Throws<ArgumentNullException>(() => new Publisher().RegisterObserver(null!));
    }),
    ("Factory builds every pizza and rejects unknown types", () =>
    {
        foreach (var type in Enum.GetValues<PizzaType>())
        {
            var pizza = PizzaFactory.CreatePizza(type);
            var output = Capture(() =>
            {
                pizza.Prepare(); pizza.Bake(); pizza.Cut(); pizza.Box();
            });
            var lines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Check(lines.SequenceEqual(new[] { "Preparing", "Baking", "Cutting", "Boxing" }), type.ToString());
            Check(pizza.GetDescription().Contains(type.ToString()), $"{type} description");
        }
        Throws<ArgumentOutOfRangeException>(() => PizzaFactory.CreatePizza((PizzaType)999));
    }),
    ("Job requires a strategy and supports replacement", () =>
    {
        Throws<ArgumentNullException>(() => new Job(null!));
        var first = new CountingStrategy();
        var second = new CountingStrategy();
        var job = new Job(first);
        job.DoJob();
        job.Strategy = second;
        Throws<ArgumentNullException>(() => job.Strategy = null!);
        job.DoJob();
        Check(first.Count == 1 && second.Count == 1, "Valid strategy retained");
    }),
    ("Adapter exposes the adaptee through the target interface", () =>
    {
        IClient client = new Adapter(new ServiceToAdapt());
        var output = Capture(client.DoJob).Trim();
        Check(output == "Work done, Work done", $"Adapted output was '{output}'");
        Throws<ArgumentNullException>(() => new Adapter(null!));
    }),
    ("Decorators stack cost and description", () =>
    {
        IProduct product = new Sugar(new Milk(new Product()));
        Check(Math.Abs(product.Cost() - 2.30) < 1e-9, $"Cost was {product.Cost()}");
        Check(product.GetDescription() == "Koffie, melk, suiker", product.GetDescription());
        Throws<ArgumentNullException>(() => new Milk(null!));
    }),
    ("Duck swaps behaviour at runtime", () =>
    {
        var duck = new MallardDuck();
        Check(Capture(duck.Fly).Trim() == "I'm flying!", "Default fly behaviour");
        duck.FlyBehavior = new FlyNoWay();
        Check(Capture(duck.Fly).Trim() == "I can't fly :(", "Swapped fly behaviour");
        Throws<ArgumentNullException>(() => duck.QuackBehavior = null!);
    })
};

var failures = 0;
foreach (var test in tests)
{
    try { test.Run(); Console.WriteLine($"PASS {test.Name}"); }
    catch (Exception exception)
    {
        failures++;
        Console.Error.WriteLine($"FAIL {test.Name}: {exception.Message}");
    }
}
Console.WriteLine($"{tests.Length - failures}/{tests.Length} checks passed.");
return failures == 0 ? 0 : 1;

static void Check(bool condition, string message)
{
    if (!condition) throw new Exception(message);
}

static void Throws<T>(Action action) where T : Exception
{
    try { action(); }
    catch (T) { return; }
    throw new Exception($"Expected {typeof(T).Name}");
}

static string Capture(Action action)
{
    var original = Console.Out;
    using var output = new StringWriter();
    try
    {
        Console.SetOut(output);
        action();
    }
    finally { Console.SetOut(original); }
    return output.ToString();
}

sealed class CallbackObserver : DesignPatterns.Observer.IObserver
{
    public List<int> Values { get; } = [];
    public Action<int>? OnUpdate { get; set; }
    public void Update(int value) { Values.Add(value); OnUpdate?.Invoke(value); }
}

sealed class CountingStrategy : IStrategy
{
    public int Count { get; private set; }
    public void DoJob() => Count++;
}
