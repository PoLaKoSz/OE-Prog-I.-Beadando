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
        
        public Golyo[,] Jatekter { get; set; }



        public Palya(int sorokSzama, int oszlopokSzama)
        {
            Jatekter = new Golyo[sorokSzama, oszlopokSzama];

            MinEgyszinuGolyokSzama = 2;
            MaxEgyszinuGolyokSzama = 5;
        }

        public Palya(Golyo[,] palya, int maxGolyok)
        {
            Jatekter = palya;

            MinEgyszinuGolyokSzama = 2;
            MaxEgyszinuGolyokSzama = maxGolyok;
        }
    }
}
