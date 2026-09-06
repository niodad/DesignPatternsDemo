// See https://aka.ms/new-console-template for more information
using System.Globalization;
using DesignPatterns.Adapter;
using DesignPatterns.Decorator;
using DesignPatterns.Duck;
using DesignPatterns.Factory;
using DesignPatterns.Iterator;
using DesignPatterns.Observer;
using DesignPatterns.Strategy;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Section("Strategy");
new FirstJob().DoJob();
new SecondJob().DoJob();

Section("Adapter");
IClient client = new Adapter();
client.DoJob();

Section("Observer");
var publisher = new Publisher();
var observer = new Observer();
publisher.RegisterObserver(observer);
publisher.SetValue(88);
publisher.RemoveObserver(observer);

Section("Decorator");
IProduct product = new Product();
product = new Milk(product);
product = new Sugar(product);
var price = product.Cost().ToString("F2", CultureInfo.InvariantCulture);
Console.WriteLine($"{product.GetDescription()}, costs € {price}.");

Section("Iterator");
var aggregate = new ConcreteAggregate<string>();
aggregate.Add("Item A");
aggregate.Add("Item B");
aggregate.Add("Item C");
aggregate.Add("Item D");
var iterator = aggregate.CreateIterator();
Console.WriteLine("Iterating over collection:");
for (iterator.First(); !iterator.IsDone(); iterator.Next())
{
    Console.WriteLine(iterator.CurrentItem());
}

Section("Factory");
var pizza = PizzaFactory.CreatePizza(PizzaType.Napoli);
Console.WriteLine(pizza.GetDescription());
pizza.Prepare();
pizza.Bake();
pizza.Cut();
pizza.Box();

Section("Duck");
Duck duck = new MallardDuck();
duck.Display();
duck.Fly();
duck.Quack();
duck.Swim();
duck.FlyBehavior = new FlyNoWay();
Console.WriteLine("After swapping the fly behaviour:");
duck.Fly();

static void Section(string title)
{
    Console.WriteLine();
    Console.WriteLine(title);
    Console.WriteLine(new string('-', title.Length));
}
