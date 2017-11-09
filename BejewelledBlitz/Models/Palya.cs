using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Palya
    {
        private int minEgyszinuGolyokSzama;
        public int MinEgyszinuGolyokSzama
        {
            get { return minEgyszinuGolyokSzama; }
            set
            {
                if (value > 1)
                {
                    minEgyszinuGolyokSzama = value;
                }
                else
                {
                    minEgyszinuGolyokSzama = 2;
                }
            }
        }

        private int maxEgyszinuGolyokSzama;
        public int MaxEgyszinuGolyokSzama
        {
            get { return maxEgyszinuGolyokSzama; }
            set
            {
                if (value > MinEgyszinuGolyokSzama)
                {
                    maxEgyszinuGolyokSzama = value;
                }
                else
                {
                    maxEgyszinuGolyokSzama = MinEgyszinuGolyokSzama + 1;
                }
            }
        }
        
        public Golyo[,] Jatekter { get; private set; }



        public Palya(int sorokSzama, int oszlopokSzama, int maxGolyok)
        {
            Jatekter = new Golyo[sorokSzama, oszlopokSzama];

            MinEgyszinuGolyokSzama = 2;
            MaxEgyszinuGolyokSzama = maxGolyok;
        }

        public Palya(Golyo[,] palya, int maxGolyok)
        {
            Jatekter = palya;

            MinEgyszinuGolyokSzama = 2;
            MaxEgyszinuGolyokSzama = maxGolyok;
        }
    }
}
