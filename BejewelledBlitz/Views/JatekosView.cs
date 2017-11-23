using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class JatekosView : UI
    {
        public string JatekosnevBekerese()
        {
            return InputBeker("Adja meg a nevét: ");
        }

        public int JatekidoBekerese()
        {
            return IntInputBeker("Adja meg, hogy hány percig szeretne játszani: ");
        }

        public int SorokBekerese()
        {
            return IntInputBeker("Adja meg, hogy hány sorból álljon a pálya: ");
        }

        public int OszlopokBekerese()
        {
            return IntInputBeker("Adja meg, hogy hány oszlopból álljon a pálya: ");
        }
    }
}
