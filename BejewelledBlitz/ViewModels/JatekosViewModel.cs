using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class JatekosViewModel : UI
    {
        public Jatekos Jatekos { get; private set; }



        public JatekosViewModel()
        {
#if DEBUG
            string jatekosNeve = "TesztElek";
            int jatekido = 2;
            int sorokSzama = 5;
            int oszlopokSzama = 10;
#else
            string jatekosNeve = InputBeker("Adja meg a nevét: ");
            int jatekido = IntInputBeker("Adja meg, hogy hány percig szeretne játszani: ");
            int sorokSzama = IntInputBeker("Adja meg, hogy hány sorból álljon a pálya: ");
            int oszlopokSzama = IntInputBeker("Adja meg, hogy hány oszlopból álljon a pálya: ");
#endif

            Jatekos = new Jatekos(jatekosNeve, jatekido * 60 * 1000, sorokSzama, oszlopokSzama);

            ConsoleTorlese();
        }
    }
}
