using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Koordinata
    {
        public int XTengely { get; private set; }

        public int YTengely { get; private set; }



        public Koordinata(int sorIndex, int oszlopIndex)
        {
            XTengely = sorIndex;
            YTengely = oszlopIndex;
        }
    }
}
