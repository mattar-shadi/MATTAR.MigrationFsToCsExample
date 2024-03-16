namespace BusinessLogic.Abstraction
{
    public interface IOHLC
    {
        double O { get; set; }
        double H { get; set; }
        double L { get; set; }
        double C { get; set; }
    }
}