using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class JatekosView// : UI
    {
        protected string InputBeker(string kiseroSzoveg)
        {
            Console.Write(kiseroSzoveg);

            return Console.ReadLine();
        }

        protected int IntInputBeker(string kiseroSzoveg)
        {
            try
            {
                return int.Parse(InputBeker(kiseroSzoveg));
            }
            catch (FormatException)
            {
                IntInputBeker(kiseroSzoveg);
            }

            return -1;
        }

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
