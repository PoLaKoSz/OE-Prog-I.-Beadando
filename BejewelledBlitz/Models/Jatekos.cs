using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Jatekos
    {
        public string Nev { get; private set; }

        public int Jatekido { get; private set; }

        public int SorokSzama { get; private set; }

        public int OszlopokSzama { get; private set; }

        public int Pontszam { get; set; }



        public Jatekos(string nev, int jatekIdo, int sorokSzama, int oszlopokSzama)
        {
            Nev = nev;
            Jatekido = jatekIdo;
            SorokSzama = sorokSzama;
            OszlopokSzama = oszlopokSzama;
        }
    }
}
