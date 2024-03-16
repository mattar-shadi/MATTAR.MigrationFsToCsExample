using BusinessLogic.Abstraction;

namespace BusinessLogic.Models
{
    public class OHLC : IOHLC
    {
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
    }
}