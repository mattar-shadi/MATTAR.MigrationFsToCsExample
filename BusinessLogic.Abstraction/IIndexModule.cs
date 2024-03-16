using System.Collections.Generic;

namespace BusinessLogic.Abstraction
{
    public interface IIndexModule
    {
        IEnumerable<IOHLC> GetOHLC();
    }
}