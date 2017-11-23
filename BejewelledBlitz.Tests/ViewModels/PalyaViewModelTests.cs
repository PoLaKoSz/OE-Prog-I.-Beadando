using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System;

namespace PoLaKoSz.BejewelledBlitzTests
{
    public class PalyaViewModelMock : PalyaViewModel
    {
        public Golyo[,] JatekMezo
        {
            get { return Palya.Jatekter; }
            set { Palya.Jatekter = value; }
        }

        public new Jatekos Jatekos
        {
            get { return base.Jatekos; }
            set { base.Jatekos = value; }
        }



        public PalyaViewModelMock(Jatekos jatekos)
            : base(jatekos)
        {

        }



        public new void Lepes(Golyo golyo1, Golyo golyo2)
        {
            base.Lepes(golyo1, golyo2);
        }
    }

    [TestClass]
    public class PalyaViewModelTests
    {
        PalyaViewModelMock pvm = new PalyaViewModelMock(new Jatekos("PoLáKoSz", 2, 2, 4));

        [TestMethod]
        public void PalyaViewModel__KetNemEgymasMellettiGolyoCsereje_NemSzabadnaMegtortennie()
        {
            pvm.JatekMezo = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Red),
                },
            };
            Golyo[,] expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Red),
                },
            };

            pvm.Lepes(pvm.JatekMezo[0, 0], pvm.JatekMezo[0, 2]);

            CollectionAssert.AreEqual(expected, pvm.JatekMezo, "A golyóknak nem szabadott volna megváltozniuk, mivel a két kijelölt golyó nincs egymás mellett.");
        }

        [TestMethod]
        public void PalyaViewModel__KetNemEgymasFelettiGolyoCsereje_NemSzabadnaMegtortennie()
        {
            pvm.JatekMezo = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                },
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Red),
                },
            };
            Golyo[,] expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                },
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Green),
                    new Golyo(0, 2, ConsoleColor.Red),
                },
            };

            pvm.Lepes(pvm.JatekMezo[0, 2], pvm.JatekMezo[1, 0]);

            CollectionAssert.AreEqual(expected, pvm.JatekMezo, "A golyóknak nem szabadott volna megváltozniuk, mivel a két kijelölt golyó nincs egymás felett.");
        }

        [TestMethod]
        public void PalyaViewModel__AzonosSzinuGolyokEltunteteseTobbSorbanIs()
        {
            pvm.JatekMezo = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Green),
                    new Golyo(0, 3, ConsoleColor.Red),
                    new Golyo(0, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.DarkGray),
                    new Golyo(1, 2, ConsoleColor.White),
                    new Golyo(1, 3, ConsoleColor.White),
                    new Golyo(1, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Green),
                    new Golyo(2, 1, ConsoleColor.Red),
                    new Golyo(2, 2, ConsoleColor.Green),
                    new Golyo(2, 3, ConsoleColor.Green),
                    new Golyo(2, 4, ConsoleColor.Red),
                },
            };

            pvm.Lepes(pvm.JatekMezo[2, 0], pvm.JatekMezo[2, 1]);

            Assert.AreEqual(true, pvm.Jatekos.Pontszam >= 7);
        }
    }
}
