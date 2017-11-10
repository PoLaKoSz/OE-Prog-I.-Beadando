using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System;

namespace PoLaKoSz.BejewelledBlitzTests
{
    public class TestPalyaViewModel : PalyaViewModel
    {
        public TestPalyaViewModel(Jatekos jatekos) : base(jatekos)
        {
        }

        public int AzonosSzinuGolyokEltunteteseEgySorbanTest(Golyo[,] palya, Palya palyaBeallitasok, Jatekos jatekos, int sorIndex)
        {
            return base.AzonosSzinuGolyokEltunteteseEgySorban(palya, palyaBeallitasok, jatekos, sorIndex);
        }
    }



    [TestClass]
    public class PalyaViewModelTests
    {
        private TestPalyaViewModel palyaViewModel;



        [ClassInitialize]
        public void TestInitializeasd()
        {
            palyaViewModel = new TestPalyaViewModel(new Jatekos("TestElek", 10, 5, 6));
        }



        [TestMethod]
        public void PalyaViewModel__AzonosSzinuGolyokEltunteteseEgySorban()
        {
            var palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Black),
                    new Golyo(0, 0, ConsoleColor.Black),
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 0, ConsoleColor.Green),
                }
            };
            var expected = new Golyo[,]
            {
                {
                    null,
                    null,
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    null,
                    null,
                    null,
                }
            };
            palyaViewModel.AzonosSzinuGolyokEltunteteseEgySorbanTest(palya, palyaViewModel.Palya, palyaViewModel.Jatekos, 0);

            CollectionAssert.AreEqual(expected, palya);
        }
    }
}
