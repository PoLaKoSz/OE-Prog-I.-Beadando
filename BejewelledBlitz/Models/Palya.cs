using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Palya
    {
        int minEgyszinuGolyokSzama;
        public int MinEgyszinuGolyokSzama
        {
            get { return minEgyszinuGolyokSzama; }
            private set
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

        int maxEgyszinuGolyokSzama;
        public int MaxEgyszinuGolyokSzama
        {
            get { return maxEgyszinuGolyokSzama; }
            private set
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
    }
}
