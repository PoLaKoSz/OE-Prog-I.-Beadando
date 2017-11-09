using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System;

namespace PoLaKoSz.BejewelledBlitzTests
{
    [TestClass]
    public class PalyaViewModelTests
    {
        public PalyaViewModel PalyaViewModel { get; private set; }



        [TestInitialize]
        public void TestInitialize()
        {
            PalyaViewModel = new PalyaViewModel(new Jatekos("TestElek", 10, 5, 6));
        }



        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyokCserelhetokE__VertikalisanKelleneCserelodniuk()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Yellow), // <----
                    new Golyo(0, 2, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Black),  // <----
                    new Golyo(1, 2, ConsoleColor.Yellow),
                }
            };

            Palya palya = new Palya(matrix, 6);
            Golyo golyo1 = matrix[0, 1];
            Golyo golyo2 = matrix[1, 1];

            bool expected = true;
            bool actual = PalyaViewModel.GolyokCserelhetokE(palya, golyo1, golyo2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyokCserelhetokE__VertikalisanNemSzabadnaCserelodniuk()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Cyan), // <----
                    new Golyo(0, 2, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Yellow),
                    new Golyo(1, 2, ConsoleColor.DarkGray),  // <----
                }
            };

            Palya palya = new Palya(matrix, 6);
            Golyo golyo1 = matrix[0, 1];
            Golyo golyo2 = matrix[1, 2];

            bool expected = false;
            bool actual = PalyaViewModel.GolyokCserelhetokE(palya, golyo1, golyo2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyokCsereje()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Yellow), // <----
                    new Golyo(0, 2, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Black),  // <----
                    new Golyo(1, 2, ConsoleColor.Yellow),
                }
            };
            Golyo golyo1 = matrix[0, 1];
            Golyo golyo2 = matrix[1, 1];

            Golyo[,] expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Black), // <----
                    new Golyo(0, 2, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Yellow),  // <----
                    new Golyo(1, 2, ConsoleColor.Yellow),
                }
            };
            PalyaViewModel.GolyokCsereje(matrix, ref golyo1, ref golyo2);

            CollectionAssert.AreEqual(expected, matrix);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasFelettE__KetSorralLejebbUgyanAbbanAzOszlopban()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(2, 0, ConsoleColor.Red);

            bool expected = false;
            bool actual = PalyaViewModel.EgymasFelettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = false;
            actual = PalyaViewModel.EgymasFelettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasFelettE__EgymasAlattNemUgyanAbbanAzOszlopban()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(1, 2, ConsoleColor.Green);

            bool expected = false;
            bool actual = PalyaViewModel.EgymasFelettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = false;
            actual = PalyaViewModel.EgymasFelettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasFelettE__EgymasAlattVannak()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(1, 0, ConsoleColor.Yellow);

            bool expected = true;
            bool actual = PalyaViewModel.EgymasFelettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = true;
            actual = PalyaViewModel.EgymasFelettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasMellettE__KetSorralLejebbUgyanAbbanAzOszlopban()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(2, 0, ConsoleColor.Red);

            bool expected = false;
            bool actual = PalyaViewModel.EgymasMellettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = false;
            actual = PalyaViewModel.EgymasMellettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasMellettE__EgymasMellettiOszlopbanNemUgyanAbbanASorban()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(1, 1, ConsoleColor.Green);

            bool expected = false;
            bool actual = PalyaViewModel.EgymasMellettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = false;
            actual = PalyaViewModel.EgymasMellettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_EgymasMellettE__EgymasMellettVannak()
        {
            Golyo golyo1 = new Golyo(0, 0, ConsoleColor.Black);
            Golyo golyo2 = new Golyo(0, 1, ConsoleColor.Yellow);

            bool expected = true;
            bool actual = PalyaViewModel.EgymasMellettE(golyo1, golyo2);

            Assert.AreEqual(expected, actual);

            expected = true;
            actual = PalyaViewModel.EgymasMellettE(golyo2, golyo1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_VanEMelletteAzonosSzinuGolyo__NincsEgyikOldaltSem()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                }
            };
            Palya palya = new Palya(matrix, 6);
            Golyo golyo = matrix[0, 1];

            bool expected = false;
            bool actual = PalyaViewModel.VanEMelletteAzonosSzinuGolyo(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_VanEMelletteAzonosSzinuGolyo__VanABalOldalan()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                }
            };
            Palya palya = new Palya(matrix, 6);
            Golyo golyo = matrix[0, 1];

            bool expected = true;
            bool actual = PalyaViewModel.VanEMelletteAzonosSzinuGolyo(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_AzonosSzinuGolyokSzamaBalrol__NincsenABalOldalan()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                    new Golyo(0, 3, ConsoleColor.Yellow),
                }
            };
            Golyo golyo = palya[0, 2];

            int expected = 0;
            int actual = PalyaViewModel.AzonosSzinuGolyokSzamaBalrol(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_AzonosSzinuGolyokSzamaBalrol__VanABalOldalan()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                    new Golyo(0, 3, ConsoleColor.Yellow),
                }
            };
            Golyo golyo = palya[0, 2];

            int expected = 2;
            int actual = PalyaViewModel.AzonosSzinuGolyokSzamaBalrol(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_AzonosSzinuGolyokSzamaJobbrol__NincsenAJobbOldalan()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Red),
                    new Golyo(0, 3, ConsoleColor.Yellow),
                    new Golyo(0, 4, ConsoleColor.Red),
                }
            };
            Golyo golyo = palya[0, 2];

            int expected = 0;
            int actual = PalyaViewModel.AzonosSzinuGolyokSzamaJobbrol(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_AzonosSzinuGolyokSzamaJobbrol__VanAJobbOldalan()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                    new Golyo(0, 2, ConsoleColor.Yellow),
                    new Golyo(0, 3, ConsoleColor.Yellow),
                    new Golyo(0, 4, ConsoleColor.Red),
                }
            };
            Golyo golyo = palya[0, 1];

            int expected = 2;
            int actual = PalyaViewModel.AzonosSzinuGolyokSzamaJobbrol(palya, golyo);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyoEgySorralLejjebbHozasa__PalyanBelul()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                }
            };

            Golyo expected = new Golyo(1, 0, ConsoleColor.Green);
            Golyo actual = PalyaViewModel.GolyoEgySorralLejjebbHozasa(palya, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyoEgySorralLejjebbHozasa__PalyanKivulrolJon()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                },
            };

            Golyo expected = new Golyo(0, 0, ConsoleColor.Green);
            Golyo actual = PalyaViewModel.GolyoEgySorralLejjebbHozasa(palya, -1, 0);

            Assert.AreEqual(expected.SorIndex, actual.SorIndex);
            Assert.AreEqual(expected.OszlopIndex, actual.OszlopIndex);
        }

        [TestMethod]
        public void BejewelledBlitz_PalyaViewModel_GolyoKivalasztasaKoordinatakAlapjan()
        {
            Golyo[,] matrix = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Green),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                },
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Black),
                }
            };
            Palya palya = new Palya(matrix, 6);

            int    sorIndexe = 0,
                oszlopIndexe = 1;
            Golyo expected = matrix[sorIndexe, oszlopIndexe];
            Golyo actual = PalyaViewModel.GolyoKivalasztasaKoordinatakAlapjan(palya, sorIndexe, oszlopIndexe);

            Assert.AreEqual(expected, actual);


            sorIndexe = 1;
            oszlopIndexe = 0;
            expected = matrix[sorIndexe, oszlopIndexe];
            actual = PalyaViewModel.GolyoKivalasztasaKoordinatakAlapjan(palya, sorIndexe, oszlopIndexe);

            Assert.AreEqual(expected, actual);
        }
    }
}
