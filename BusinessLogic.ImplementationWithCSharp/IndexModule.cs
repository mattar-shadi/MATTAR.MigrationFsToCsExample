using BusinessLogic.Abstraction;
using BusinessLogic.Models;

namespace BusinessLogic.ImplementationWithCSharp
{
    public class IndexModule : IIndexModule
    {
        public IEnumerable<IOHLC> GetOHLC()
        {
            var data = System.IO.File.ReadAllText($"data.csv");
            var dataArray = data.Split("\r\n");

            return dataArray
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new OHLC
                {
                    O = double.Parse(x[0]),
                    H = double.Parse(x[1]),
                    L = double.Parse(x[2]),
                    C = double.Parse(x[3])
                })
                .Take(20);
        }
    }
}