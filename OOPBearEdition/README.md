# OOP Bear Edition

This project is a very small C# console application, but it contains the core ideas needed to understand Object-Oriented Programming (OOP) without prior experience.

The file [Program.cs](./Program.cs) is the entire lesson. Every important idea appears there in a compact form:

1. A variable stores data.
2. A function performs work and returns a result.
3. A class defines a type of thing.
4. An object is a real instance of that class.
5. An interface defines a contract.
6. A constructor prepares an object to work.
7. Abstraction and polymorphism let different objects be used through the same common shape.

If OOP has ever felt abstract, this project makes it concrete.

## What the program does

When the current version runs, it:

1. Stores and prints a name.
2. Adds two numbers with a function.
3. Creates a sale, adds two amounts, and prints the total.
4. Creates another sale that can calculate tax.
5. Sends a message using a class that only depends on the `ISale` contract.

Current console output:

```text
MR Duff
5
$30.00
Enviando correo con la venta que tiene total $30.00
```

Important detail:

The program creates `saleWithTax`, but the current line in `Main` sends `sale` to `SenderSale`:

```csharp
var senderSale = new SenderSale(sale); // OR var senderSale = new SenderSale(saleWithTax);
```

Because of that, the final message uses the total of the plain sale, not the taxed sale.

## How to run

This project targets `.NET Framework 4.7.2`.

Using Visual Studio:

1. Open `OOPBearEdition.slnx`.
2. Set `OOPBearEdition` as the startup project if needed.
3. Press `F5` or run without debugging.

Using the command line:

```powershell
dotnet build OOPBearEdition.csproj
.\bin\Debug\OOPBearEdition.exe
```

## The big idea of Object-Oriented Programming

Object-Oriented Programming is a way to model software using small pieces that resemble real things or responsibilities.

Instead of putting all logic in one long list of instructions, OOP organizes code into units that:

1. Hold data
2. Perform actions
3. Protect internal state
4. Collaborate with other units through clear rules

In this project:

1. `Sale` represents a sale.
2. `SaleWithTax` represents a sale that also calculates tax.
3. `SenderSale` represents a service that sends information about a sale.
4. `ISale` is the rule both sale types agree to follow.

That is the essence of OOP: modeling behavior through related types that work together.

## How to read Program.cs

`Program.cs` has two layers:

1. `Main` shows the program in action.
2. The nested types below `Main` define the reusable pieces that make the behavior possible.

This is the simplest mental model:

1. `Main` says what happens.
2. The classes explain how it happens.

## 1. Variable

A variable is a named place in memory that stores a value.

Code block from `Program.cs`:

```csharp
string name = "MR Duff";
Console.WriteLine(name);
```

What it means:

1. `string` means text.
2. `name` is the variable name.
3. `"MR Duff"` is the stored value.
4. `Console.WriteLine(name);` prints that value.

Why it matters:

Every program starts by storing information. Without data, there is nothing to process.

## 2. Function

A function is a named block of code that does one job. It can receive input and return output.

Code block from `Program.cs`:

```csharp
int result = Add(2, 3);

int Add(int a, int b)
{
    return a + b;
}

Console.WriteLine(result);
```

What it means:

1. `Add(2, 3)` calls the function with two numbers.
2. `a` and `b` are parameters.
3. `return a + b;` sends the answer back.
4. The returned value is stored in `result`.

Why it matters:

Functions prevent repetition. Once logic has a name, it can be reused instead of rewritten.

## 3. Class

A class is a blueprint. It describes what an object knows and what an object can do.

Code block from `Program.cs`:

```csharp
class Sale : ISale
{
    private decimal _total = 0;
    public string Total => _total.ToString("C");

    public void Add(decimal amount)
    {
        _total += amount;
    }
}
```

What this class contains:

1. A private field named `_total`
2. A public property named `Total`
3. A public method named `Add`

Simple translation:

1. The sale keeps track of a total.
2. The sale can expose that total as formatted text.
3. The sale can increase the total when a new amount is added.

Why it matters:

A class groups related data and behavior into one coherent unit.

## 4. Object

An object is a real instance created from a class.

Code block from `Program.cs`:

```csharp
var sale = new Sale();
sale.Add(10);
sale.Add(20);
Console.WriteLine(sale.Total);
```

What happens step by step:

1. `new Sale()` creates an object in memory.
2. `sale` is the variable that refers to that object.
3. `sale.Add(10)` changes the internal state.
4. `sale.Add(20)` changes it again.
5. `sale.Total` reads the current result.

This is one of the most important OOP ideas:

An object is not just data. It is data plus behavior.

## 5. Encapsulation

Encapsulation means an object controls its own internal state instead of letting outside code change everything freely.

Code block from `Program.cs`:

```csharp
private decimal _total = 0;
public string Total => _total.ToString("C");

public void Add(decimal amount)
{
    _total += amount;
}
```

What to notice:

1. `_total` is `private`, so outside code cannot change it directly.
2. The object decides how totals are updated.
3. The object decides how totals are shown.

Why this matters:

If every part of a program could change everything at any time, mistakes would grow quickly. Encapsulation creates safety and order.

## 6. Interface

An interface is a contract. It says what a type must be able to do, without saying how it does it.

Code block from `Program.cs`:

```csharp
interface ISale
{
    string Total { get; }
    void Add(decimal amount);
}
```

What this contract requires:

1. A readable `Total`
2. An `Add` method that receives an amount

Why it matters:

An interface focuses on capability, not implementation.

That means:

1. One class can store only a total.
2. Another class can store subtotal and tax.
3. Both are still acceptable if they respect the same contract.

## 7. A class implementing an interface

The `Sale` class implements `ISale`:

```csharp
class Sale : ISale
{
    private decimal _total = 0;
    public string Total => _total.ToString("C");

    public void Add(decimal amount)
    {
        _total += amount;
    }
}
```

The `SaleWithTax` class also implements `ISale`:

```csharp
class SaleWithTax : ISale
{
    private decimal _subtotal = 0;
    private decimal _taxRate;
    private decimal _taxAmount;

    public SaleWithTax(decimal taxRate)
    {
        _taxRate = taxRate;
    }

    public string Total => (_subtotal + _taxAmount).ToString("C");

    public void Add(decimal amount)
    {
        _subtotal += amount;
        _taxAmount = _subtotal * _taxRate;
    }
}
```

This is a major OOP lesson:

Two classes can behave differently internally and still be treated as the same kind of thing if they follow the same interface.

## 8. Constructor

A constructor prepares an object when it is created.

Code block from `Program.cs`:

```csharp
public SaleWithTax(decimal taxRate)
{
    _taxRate = taxRate;
}
```

And also:

```csharp
public SenderSale(ISale sale)
{
    _sale = sale;
}
```

What constructors do here:

1. `SaleWithTax` receives the tax rate it needs to work correctly.
2. `SenderSale` receives a sale object it will use later.

Why it matters:

Constructors make dependencies explicit. An object begins life already configured with what it needs.

## 9. Abstraction

Abstraction means working with the essential idea of something instead of all its internal details.

Code block from `Program.cs`:

```csharp
private ISale _sale;

public SenderSale(ISale sale)
{
    _sale = sale;
}
```

`SenderSale` does not care whether the object is:

1. `Sale`
2. `SaleWithTax`

It only cares that the object behaves like an `ISale`.

That is abstraction:

The class depends on the important behavior, not on the concrete implementation details.

## 10. Polymorphism

Polymorphism means different objects can be used through the same interface.

Code blocks from `Program.cs`:

```csharp
var saleWithTax = new SaleWithTax(0.16m);
saleWithTax.Add(15);
saleWithTax.Add(25);
```

```csharp
var senderSale = new SenderSale(sale); // OR var senderSale = new SenderSale(saleWithTax);
senderSale.SendMail();
```

What this teaches:

1. `SenderSale` accepts any object that implements `ISale`.
2. `Sale` works.
3. `SaleWithTax` also works.
4. `SenderSale` does not need separate versions for each class.

This is one of the strongest benefits of OOP:

New behavior can be added without rewriting the code that already depends on the shared contract.

## 11. Collaboration between objects

Objects become powerful when they collaborate.

Code block from `Program.cs`:

```csharp
class SenderSale
{
    private ISale _sale;

    public SenderSale(ISale sale)
    {
        _sale = sale;
    }

    public void SendMail()
    {
        Console.WriteLine($"Enviando correo con la venta que tiene total {_sale.Total}");
    }
}
```

What happens here:

1. `SenderSale` does not calculate totals.
2. `Sale` and `SaleWithTax` do not send messages.
3. Each class has one clear responsibility.

This separation is good design because each type stays focused and easier to change.

## 12. Full walkthrough of the current execution

The easiest way to internalize the code is to follow the runtime flow in order.

### Step 1: store and print text

```csharp
string name = "MR Duff";
Console.WriteLine(name);
```

Result:

```text
MR Duff
```

### Step 2: call a function

```csharp
int result = Add(2, 3);
Console.WriteLine(result);
```

Result:

```text
5
```

### Step 3: create a sale and add amounts

```csharp
var sale = new Sale();
sale.Add(10);
sale.Add(20);
Console.WriteLine(sale.Total);
```

Internal idea:

1. Start at `0`
2. Add `10`
3. Add `20`
4. Total becomes `30`

Result:

```text
$30.00
```

### Step 4: create a sale with tax

```csharp
var saleWithTax = new SaleWithTax(0.16m);
saleWithTax.Add(15);
saleWithTax.Add(25);
```

Internal idea:

1. Tax rate is `0.16`, which means `16%`
2. Subtotal after first add: `15`
3. Tax after first add: `2.4`
4. Subtotal after second add: `40`
5. Tax after second add: `6.4`
6. Total would be `46.4`

Important:

The current program does not print this value directly, because the next line passes `sale`, not `saleWithTax`, to `SenderSale`.

### Step 5: send the sale information

```csharp
var senderSale = new SenderSale(sale); // OR var senderSale = new SenderSale(saleWithTax);
senderSale.SendMail();
```

Result in the current version:

```text
Enviando correo con la venta que tiene total $30.00
```

If `saleWithTax` were passed instead, the same `SenderSale` class would still work. That is the clearest proof of polymorphism in this project.

## 13. Why this project is a good OOP example

This file is small, but it demonstrates the most important OOP principles in one place:

1. State lives inside objects.
2. Behavior is attached to the data it affects.
3. Internal details stay hidden behind public members.
4. Interfaces define shared behavior.
5. Constructors provide required data.
6. One class can depend on a contract instead of a concrete type.
7. Different implementations can be swapped with minimal change.

That is not just syntax. That is software design.

## 14. A beginner-friendly mental model

A simple analogy helps:

1. `ISale` is the job description.
2. `Sale` is one worker who follows that job description.
3. `SaleWithTax` is another worker who follows the same job description but does extra calculation.
4. `SenderSale` is a coworker who only needs someone that fits the job description.

Because both workers satisfy the same contract, `SenderSale` can collaborate with either one.

That is exactly how interfaces, abstraction, and polymorphism fit together.

## 15. Key terms, in plain English

1. `Variable`: a named value.
2. `Function`: a reusable action.
3. `Class`: a blueprint for creating objects.
4. `Object`: a real instance of a class.
5. `Field`: internal data stored inside a class.
6. `Property`: a controlled way to expose data.
7. `Method`: a function that belongs to a class.
8. `Interface`: a contract that defines required members.
9. `Constructor`: special code that runs when an object is created.
10. `Encapsulation`: keeping internal details protected.
11. `Abstraction`: focusing on what something does, not how it does it internally.
12. `Polymorphism`: using different objects through the same shared contract.

## 16. Final takeaway

If one sentence had to summarize OOP, it would be this:

OOP organizes code into cooperating objects that protect their own state and interact through clear contracts.

This project shows that idea in its simplest practical form.
