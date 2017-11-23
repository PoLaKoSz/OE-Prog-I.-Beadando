using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoLaKoSz.BejewelledBlitz;
using System.Collections.Generic;

namespace PoLaKoSz.BejewelledBlitzTests
{
    public class RanglistaViewModelMock : RanglistaViewModel
    {
        public List<Jatekos> Ranglista
        {
            get { return base.ranglista; }
            set { base.ranglista = value; }
        }


        
        public RanglistaViewModelMock(List<Jatekos> ranglista)
        {
            Ranglista = ranglista;
        }
    }

    [TestClass]
    public class RanglistaViewModelTests
    {
        RanglistaViewModelMock ranglistaViewModel;

        [TestMethod]
        public void RanglistaViewModel__JavitottBeillesztesesRendezes__IdoSzerintVannakForditva()
        {
            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 40000, 20),
                new Jatekos("PoLáKoSz", 30000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 20),
            };
            List<Jatekos> actual = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 30000, 20),
            };
            ranglistaViewModel = new RanglistaViewModelMock(actual);

            ranglistaViewModel.UjJatekeredmenyHozzaadasa(new Jatekos("PoLáKoSz", 40000, 20));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RanglistaViewModel__JavitottBeillesztesesRendezes__PontSzerintVannakForditva()
        {
            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 40),
                new Jatekos("PoLáKoSz", 10000, 30),
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
            };
            List<Jatekos> actual = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 10000, 20),
                new Jatekos("PoLáKoSz", 10000, 30),
            };
            ranglistaViewModel = new RanglistaViewModelMock(actual);

            ranglistaViewModel.UjJatekeredmenyHozzaadasa(new Jatekos("PoLáKoSz", 10000, 40));

            CollectionAssert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void RanglistaViewModel__JavitottBeillesztesesRendezes__KetEgyezoIdoKetKulonbozoPont()
        {
            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 30000, 40),
                new Jatekos("PoLáKoSz", 20000, 30),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
            };
            List<Jatekos> actual = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 20000, 30),
            };
            ranglistaViewModel = new RanglistaViewModelMock(actual);

            ranglistaViewModel.UjJatekeredmenyHozzaadasa(new Jatekos("PoLáKoSz", 30000, 40));

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RanglistaViewModel__JavitottBeillesztesesRendezes__KetEgyezoPontKetKulonbozoIdo()
        {
            List<Jatekos> expected = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 30000, 20),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 1000, 40),
            };
            List<Jatekos> actual = new List<Jatekos>()
            {
                new Jatekos("PoLáKoSz", 10000, 10),
                new Jatekos("PoLáKoSz", 20000, 20),
                new Jatekos("PoLáKoSz", 30000, 20),
            };
            ranglistaViewModel = new RanglistaViewModelMock(actual);

            ranglistaViewModel.UjJatekeredmenyHozzaadasa(new Jatekos("PoLáKoSz", 1000, 40));

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
