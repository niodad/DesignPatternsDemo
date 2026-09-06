# DesignPatterns

C# examples of Strategy (a `Job`/`IStrategy` pair and the Head First `Duck`),
Adapter, Observer, Decorator, Iterator and a Simple Factory.
Requires the .NET 8 SDK or a compatible newer SDK.

```sh
dotnet build DesignPatterns.sln
dotnet run --project DesignPatterns
```

Run the dependency-free regression checks (exit code 1 on failure):

```sh
dotnet run --project DesignPatterns.Tests
```

The checks are a console executable, so run them with `dotnet run`, not `dotnet test`.

## Notes on the examples

- **Strategy** – A `Job` requires a non-null strategy, which can be replaced at
  runtime. The `Duck` hierarchy swaps its `FlyBehavior`/`QuackBehavior` the same way.
- **Adapter** – `Adapter` wraps a `ServiceToAdapt` instance and exposes it through
  the parameterless `IClient` interface, supplying the arguments the adaptee needs.
- **Decorator** – `Milk` and `Sugar` wrap an `IProduct` (via the `ProductDecorator`
  base) and each add to its cost and description; they stack in any order.
- **Iterator** – Collections use `Add()` to append and the indexer to replace
  existing items. `First()` resets the iterator. Use `IsDone()` to determine
  completion; `default(T)` can also be a valid item, so empty or completed
  iterators returning `default(T)` is expected. `ConcreteIterator` depends only on
  `IAggregate<T>`.
- **Observer** – `Observers` added or removed during a notification affect the next
  notification. `Value` changes only through `SetValue`, which then notifies.
- **Factory** – `PizzaFactory.CreatePizza` takes a `PizzaType` enum and throws
  `ArgumentOutOfRangeException` for an unknown value.
