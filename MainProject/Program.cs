using BusinessLogic.Abstraction;
// .NET 8.0 ---> Windows <----
Action<IEnumerable<IOHLC>> print = (objects) =>
{
    Console.WriteLine("Open \t\t\t Hight \t\t\t Low \t\t\t Close");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
    foreach (var item in objects)
    {
        Console.WriteLine($"{item.O} \t {item.H} \t {item.L} \t {item.C}");
    }
};
Console.WriteLine("------------ Main Program -----------------");
Console.WriteLine("");
Console.WriteLine("------------ F# Implémentation -----------------");
IIndexModule fsharpIndexModule = new BusinessLogic.ImplementationWithFSharp.IndexModule();
print(fsharpIndexModule.GetOHLC());
Console.WriteLine("------------ C# Implémentation -----------------");
IIndexModule csharpIndexModule = new BusinessLogic.ImplementationWithCSharp.IndexModule();
print(csharpIndexModule.GetOHLC());