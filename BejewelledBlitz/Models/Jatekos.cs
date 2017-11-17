using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Jatekos
    {
        public string Nev { get; private set; }

        /// <summary>
        /// Játékos játékideje ezredmásodpercben
        /// </summary>
        public int Jatekido { get; private set; }

        public int SorokSzama { get; private set; }

        public int OszlopokSzama { get; private set; }

        public int Pontszam { get; set; }



        public Jatekos(string nev, int jatekMiliMP, int sorokSzama, int oszlopokSzama)
        {
            Nev = nev;
            Jatekido = jatekMiliMP;
            SorokSzama = sorokSzama;
            OszlopokSzama = oszlopokSzama;
        }
    }
}
