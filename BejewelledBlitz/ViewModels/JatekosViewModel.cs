using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class JatekosViewModel
    {
        JatekosView View;

        public Jatekos Jatekos { get; private set; }



        public JatekosViewModel()
        {
            View = new JatekosView();

#if DEBUG
            string  jatekosNeve = "PoLáKoSz";
            int jatekidoPercben = 2;
            int      sorokSzama = 5;
            int   oszlopokSzama = 10;
#else
            string  jatekosNeve = View.JatekosnevBekerese();
            int jatekidoPercben = View.JatekidoBekerese();
            int      sorokSzama = View.SorokBekerese();
            int   oszlopokSzama = View.OszlopokBekerese();
#endif

            Jatekos = new Jatekos(jatekosNeve, jatekidoPercben * 60 * 1000, sorokSzama, oszlopokSzama);
        }
    }
}
