using BusinessLogic.Abstraction;
// .NET 8.0 Multiplateform ---> Windows, Linux, MacOS <----
Action<IEnumerable<IOHLC>> print = (objects) =>
{
    foreach (var item in objects)
    {
        Console.WriteLine($"{item.O} - {item.H} - {item.L} - {item.C}");
    }
};
Console.WriteLine("------------ Main Program -----------------");
Console.WriteLine("");
Console.WriteLine("------------ C# Implémentation -----------------");
IIndexModule csharpIndexModule = new BusinessLogic.ImplementationWithCSharp.IndexModule();
print(csharpIndexModule.GetOHLC());