using BusinessLogic.Abstraction;
using BusinessLogic.Models;

namespace BusinessLogic.ImplementationWithFSharp
{
    public class IndexModule : IIndexModule
    {
        public IEnumerable<IOHLC> GetOHLC()
        {
            return BusinessLogicInFSharpProject.IndexModule.getOHLC()
                .Select(x => new OHLC { C = x.c, H = x.h, L = x.l, O = x.o });
        }
    }
}