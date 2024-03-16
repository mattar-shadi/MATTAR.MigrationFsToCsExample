using Chapter5.Abstraction;
using System.Diagnostics;

namespace Chapter5.MigrationTests
{
    public class Tests
    {
        private IFSChart _fsharpImplementation;
        private IFSChart _csharpImplementation;

        [SetUp]
        public void Setup()
        {
            _fsharpImplementation = new ImplementationWithFSharp.FSChart();
            _csharpImplementation = new ImplementationWithCSharp.FSChart();
        }

        [Test]
        public void GetOHLCTest()
        {
            // Implémentation 1
            var stopwatchFsharp = Stopwatch.StartNew();
            List<IOHLC> actual = _fsharpImplementation.GetOHLC().ToList();
            stopwatchFsharp.Stop();
            var timeFsharp = stopwatchFsharp.Elapsed;

            // Implémentation 2
            var stopwatchCsharp = Stopwatch.StartNew();
            List<IOHLC> expected = _csharpImplementation.GetOHLC().ToList();
            stopwatchCsharp.Stop();
            var timeCsharp = stopwatchCsharp.Elapsed;

            Assert.Multiple(() =>
            {
                // Comparaison des temps
                Warn.If(timeFsharp < timeCsharp, 
                    $"L'implémentation c# ({timeCsharp}) est significativement plus longue que l'implémentation f# ({timeFsharp}).");

                // Comparaison des résultats
                Assert.AreEqual(actual.Count, expected.Count);
                foreach (var (a, e) in actual.Zip(expected))
                {
                    Assert.AreEqual(a.o, e.o);
                    Assert.AreEqual(a.h, e.h);
                    Assert.AreEqual(a.l, e.l);
                    Assert.AreEqual(a.c, e.c);
                    Assert.AreEqual(a.t, e.t);
                }
            });
        }
    }
}