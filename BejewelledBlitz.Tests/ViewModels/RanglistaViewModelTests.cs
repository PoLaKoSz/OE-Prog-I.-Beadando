using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System.Collections.Generic;

namespace PoLaKoSz.BejewelledBlitzTests
{
    [TestClass]
    public class RanglistaViewModelTests
    {
        RanglistaViewModel ranglistaViewModel = new RanglistaViewModel();

        [TestMethod]
        public void JavitottBeillesztesesRendezes__IdoSzerintVannakForditva()
        {
            List<Jatekos> jatekosok = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 30000, 20),
            };

            ranglistaViewModel.JavitottBeillesztesesRendezes(jatekosok);


            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 30000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 20),
            };

            CollectionAssert.AreEqual(expected, jatekosok);
        }

        [TestMethod]
        public void JavitottBeillesztesesRendezes__PontSzerintVannakForditva()
        {
            List<Jatekos> jatekosok = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 10000, 30),
            };

            ranglistaViewModel.JavitottBeillesztesesRendezes(jatekosok);


            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 30),
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
            };

            CollectionAssert.AreEqual(expected, jatekosok);
        }

        [TestMethod]
        public void JavitottBeillesztesesRendezes__KetEgyezoIdoKetKulonbozoPont()
        {
            List<Jatekos> jatekosok = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 20000, 30),
            };

            ranglistaViewModel.JavitottBeillesztesesRendezes(jatekosok);


            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 20000, 30),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
            };

            CollectionAssert.AreEqual(expected, jatekosok);
        }

        [TestMethod]
        public void JavitottBeillesztesesRendezes__KetEgyezoPontKetKulonbozoIdo()
        {
            List<Jatekos> jatekosok = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 30000, 20),
            };

            ranglistaViewModel.JavitottBeillesztesesRendezes(jatekosok);


            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 30000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
            };

            CollectionAssert.AreEqual(expected, jatekosok);
        }
    }
}
