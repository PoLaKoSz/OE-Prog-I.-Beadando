using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System;

namespace PoLaKoSz.BejewelledBlitzTests
{
    [TestClass]
    public class PalyaViewModelTests
    {
        PalyaViewModel pvm = new PalyaViewModel(new Jatekos("TesztElek", 2, 2, 4));

        [TestMethod]
        public void KetGolyoCserejePalyan()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Red),
                }
            };
            Golyo[,] expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                }
            };

            pvm.KetGolyoCserejePalyan(palya, palya[0, 0], palya[0, 1]);

            CollectionAssert.AreEqual(expected, palya);
        }

        [TestMethod]
        public void EgymasMellettE_Igen()
        {
            var golyo1 = new Golyo(0, 0, ConsoleColor.Red);
            var golyo2 = new Golyo(0, 1, ConsoleColor.Red);

            Assert.AreEqual(true, pvm.EgymasMellettE(golyo1, golyo2));

            golyo1 = new Golyo(5, 3, ConsoleColor.Red);
            golyo2 = new Golyo(5, 2, ConsoleColor.Red);

            Assert.AreEqual(true, pvm.EgymasMellettE(golyo1, golyo2));
        }

        [TestMethod]
        public void EgymasMellettE_Nem()
        {
            var golyo1 = new Golyo(0, 0, ConsoleColor.Red);
            var golyo2 = new Golyo(1, 1, ConsoleColor.Red);

            Assert.AreEqual(false, pvm.EgymasMellettE(golyo1, golyo2));

            golyo1 = new Golyo(5, 3, ConsoleColor.Red);
            golyo2 = new Golyo(2, 2, ConsoleColor.Red);

            Assert.AreEqual(false, pvm.EgymasMellettE(golyo1, golyo2));
        }

        [TestMethod]
        public void EgymasFelettE_Igen()
        {
            var golyo1 = new Golyo(0, 0, ConsoleColor.Red);
            var golyo2 = new Golyo(1, 0, ConsoleColor.Red);

            Assert.AreEqual(true, pvm.EgymasFelettE(golyo1, golyo2));

            golyo1 = new Golyo(6, 0, ConsoleColor.Red);
            golyo2 = new Golyo(5, 0, ConsoleColor.Red);

            Assert.AreEqual(true, pvm.EgymasFelettE(golyo1, golyo2));
        }

        [TestMethod]
        public void AzonosSzinuGolyokEltuntetese_EgyszeruPalya()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Red),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Red),
                    new Golyo(1, 2, ConsoleColor.Red),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    new Golyo(2, 1, ConsoleColor.Red),
                    new Golyo(2, 2, ConsoleColor.Red),
                },
            };
            int maxGolyok = 5;
            Palya palyaBeallitasok = new Palya(palya, maxGolyok);
            var jatekos = new Jatekos("asdasd", 2000, 3, 3);
            Golyo[,] expected = new Golyo[,]
            {
                {
                    null,
                    null,
                    null,
                },
                {
                    null,
                    null,
                    null,
                },
                {
                    null,
                    null,
                    null,
                },
            };

            pvm.AzonosSzinuGolyokEltuntetese(palyaBeallitasok, jatekos, 2);

            CollectionAssert.AreEqual(expected, palya);
            Assert.AreEqual(9, jatekos.Pontszam);
        }

        [TestMethod]
        public void AzonosSzinuGolyokEltuntetese_OsszetettPalya()
        {
            int maxGolyok = 5;
            var jatekos = new Jatekos("asdasd", 2000, 3, 3);

            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Green),
                    new Golyo(0, 3, ConsoleColor.Black),
                    new Golyo(0, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Cyan),
                    new Golyo(1, 2, ConsoleColor.Red),
                    new Golyo(1, 3, ConsoleColor.DarkGray),
                    new Golyo(1, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    new Golyo(2, 1, ConsoleColor.Green),
                    new Golyo(2, 2, ConsoleColor.Green),
                    new Golyo(2, 3, ConsoleColor.White),
                    new Golyo(2, 4, ConsoleColor.White),
                },
            };
            var palyaBeallitasok = new Palya(palya, maxGolyok);
            var expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Green),
                    new Golyo(0, 3, ConsoleColor.Black),
                    new Golyo(0, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Cyan),
                    new Golyo(1, 2, ConsoleColor.Red),
                    new Golyo(1, 3, ConsoleColor.DarkGray),
                    new Golyo(1, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    null,
                    null,
                    null,
                    null,
                },
            };

            int modositottSorindex = pvm.AzonosSzinuGolyokEltuntetese(palyaBeallitasok, jatekos, 2);

            Assert.AreEqual(4, jatekos.Pontszam);
            Assert.AreEqual(2, modositottSorindex);
            CollectionAssert.AreEqual(expected, palya);
        }

        [TestMethod]
        public void AzonosSzinuGolyokEltuntetese_TobbSorbanIsPontok()
        {
            int maxGolyok = 5;
            var jatekos = new Jatekos("asdasd", 2000, 3, 3);

            Golyo[,] palya = new Golyo[,]
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
                    new Golyo(2, 0, ConsoleColor.Red),
                    new Golyo(2, 1, ConsoleColor.Green),
                    new Golyo(2, 2, ConsoleColor.Green),
                    new Golyo(2, 3, ConsoleColor.Green),
                    new Golyo(2, 4, ConsoleColor.Red),
                },
            };
            var palyaBeallitasok = new Palya(palya, maxGolyok);
            var expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Yellow),
                    new Golyo(0, 1, ConsoleColor.Red),
                    new Golyo(0, 2, ConsoleColor.Green),
                    null,
                    null,
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.DarkGray),
                    null,
                    null,
                    new Golyo(1, 4, ConsoleColor.Red),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    null,
                    null,
                    null,
                    new Golyo(2, 4, ConsoleColor.Red),
                },
            };

            int modositottSorindex = pvm.AzonosSzinuGolyokEltuntetese(palyaBeallitasok, jatekos, 2);

            Assert.AreEqual(7, jatekos.Pontszam);
            Assert.AreEqual(2, modositottSorindex);
            CollectionAssert.AreEqual(expected, palya);
        }

        [TestMethod]
        public void MegszamlalasTetel()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                    new Golyo(0, 2, ConsoleColor.Red),
                    new Golyo(0, 3, ConsoleColor.Red),
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                }
            };
            int actual = pvm.MegszamlalasTetel(palya, 0, 5);

            Assert.AreEqual(1, actual);


            actual = pvm.MegszamlalasTetel(palya, 0, 3);

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void PontokatEroGolyokEltuntetese()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    new Golyo(0, 1, ConsoleColor.Yellow),
                    new Golyo(0, 2, ConsoleColor.Red),
                    new Golyo(0, 3, ConsoleColor.Red),
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                }
            };
            Golyo[,] expected = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    null,
                    null,
                    null,
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                }
            };
            pvm.PontokatEroGolyokEltuntetese(palya, 0, 3, 3);

            CollectionAssert.AreEqual(expected, palya);
        }

        [TestMethod]
        public void UresHelyekreGolyokLehozasa()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    null,
                    null,
                    null,
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                },
                {
                    null,
                    new Golyo(1, 1, ConsoleColor.Yellow),
                    null,
                    new Golyo(1, 3, ConsoleColor.Red),
                    null,
                    new Golyo(1, 5, ConsoleColor.Black),
                },
            };

            pvm.UresHelyekreGolyokLehozasa(palya, 0);

            Assert.AreNotEqual(null, palya[0, 1]);
            Assert.AreNotEqual(null, palya[0, 2]);
            Assert.AreNotEqual(null, palya[0, 3]);

            Assert.AreEqual(null, palya[1, 0]);
            Assert.AreEqual(null, palya[1, 2]);
            Assert.AreEqual(null, palya[1, 4]);



            pvm.UresHelyekreGolyokLehozasa(palya, 1);

            Assert.AreNotEqual(null, palya[0, 0]);
            Assert.AreNotEqual(null, palya[0, 1]);
            Assert.AreNotEqual(null, palya[0, 2]);
            Assert.AreNotEqual(null, palya[0, 3]);
            Assert.AreNotEqual(null, palya[0, 4]);
            Assert.AreEqual(new Golyo(0, 5, ConsoleColor.Black), palya[0, 5]);

            Assert.AreEqual(new Golyo(1, 0, ConsoleColor.Red),    palya[1, 0]);
            Assert.AreEqual(new Golyo(1, 1, ConsoleColor.Yellow), palya[1, 1]);
            Assert.AreNotEqual(null,                              palya[1, 2]);
            Assert.AreEqual(new Golyo(1, 3, ConsoleColor.Red),    palya[1, 3]);
            Assert.AreEqual(new Golyo(1, 4, ConsoleColor.Blue),   palya[1, 4]);
            Assert.AreEqual(new Golyo(1, 5, ConsoleColor.Black),  palya[1, 5]);
        }

        [TestMethod]
        public void FuggolegesSzetvalogatasHelybenCserevel()
        {
            Golyo[,] palya = new Golyo[,]
            {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    null,
                    null,
                    null,
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                },
                {
                    null,
                    new Golyo(1, 1, ConsoleColor.Yellow),
                    null,
                    new Golyo(1, 3, ConsoleColor.Red),
                    null,
                    new Golyo(1, 5, ConsoleColor.Black),
                },
            };
            Golyo[,] expected = new Golyo[,]
            {
                {
                    null,
                    null,
                    null,
                    null,
                    new Golyo(0, 4, ConsoleColor.Blue),
                    new Golyo(0, 5, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Yellow),
                    null,
                    new Golyo(1, 3, ConsoleColor.Red),
                    null,
                    new Golyo(1, 5, ConsoleColor.Black),
                },
            };
            pvm.FuggolegesSzetvalogatasHelybenCserevel(palya, 1, 0);

            CollectionAssert.AreEqual(expected, palya);



            pvm.FuggolegesSzetvalogatasHelybenCserevel(palya, 1, 4);
            expected = new Golyo[,]
            {
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                    new Golyo(0, 5, ConsoleColor.Black),
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Yellow),
                    null,
                    new Golyo(1, 3, ConsoleColor.Red),
                    new Golyo(1, 4, ConsoleColor.Blue),
                    new Golyo(1, 5, ConsoleColor.Black),
                },
            };
            CollectionAssert.AreEqual(expected, palya);



            palya = new Golyo[,]
            {
                {
                    null,
                    null,
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    new Golyo(1, 1, ConsoleColor.Yellow),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    null,
                },
                {
                    null,
                    new Golyo(3, 1, ConsoleColor.Yellow),
                },
            };
            expected = new Golyo[,]
            {
                {
                    null,
                    null,
                },
                {
                    null,
                    new Golyo(1, 1, ConsoleColor.Yellow),
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(3, 0, ConsoleColor.Red),
                    new Golyo(3, 1, ConsoleColor.Yellow),
                },
            };
            pvm.FuggolegesSzetvalogatasHelybenCserevel(palya, 3, 0);
            CollectionAssert.AreEqual(expected, palya);
        }

        [TestMethod]
        public void OszlopUresHelyeireRandomGolyok()
        {
            for (int i = 0; i < 999; i++)
            {

                Golyo[,] palya = new Golyo[,]
                {
                {
                    new Golyo(0, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(1, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(2, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(3, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(4, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(5, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(6, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(7, 0, ConsoleColor.Red),
                    null,
                },
                {
                    new Golyo(8, 0, ConsoleColor.Red),
                    null,
                },
                };
                pvm.OszlopUresHelyeireRandomGolyok(palya, 8, 1);

                Assert.AreNotEqual(null, palya[0, 1]);
                Assert.AreNotEqual(null, palya[1, 1]);
                Assert.AreNotEqual(null, palya[2, 1]);
                Assert.AreNotEqual(null, palya[3, 1]);
                Assert.AreNotEqual(null, palya[4, 1]);
                Assert.AreNotEqual(null, palya[5, 1]);
                Assert.AreNotEqual(null, palya[6, 1]);
                Assert.AreNotEqual(null, palya[7, 1]);
                Assert.AreNotEqual(null, palya[8, 1]);

                Assert.AreNotEqual(ConsoleColor.Red, palya[0, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[1, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[2, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[3, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[4, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[5, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[6, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[7, 1].Szine);
                Assert.AreNotEqual(ConsoleColor.Red, palya[8, 1].Szine);
            }
        }
    }
}
