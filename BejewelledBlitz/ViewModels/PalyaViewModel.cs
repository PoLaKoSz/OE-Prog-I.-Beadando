using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaViewModel : UI
    {
        public Palya Palya { get; protected set; }

        protected PalyaView PalyaView { get; set; }

        public Jatekos Jatekos { get; protected set; }



        public PalyaViewModel(Jatekos jatekos)
        {
            Jatekos = jatekos;

            Palya = new Palya(Jatekos.SorokSzama, Jatekos.OszlopokSzama);
            //Palya = PalyaFeltoltese(Palya);

            PalyaView = new PalyaView(Palya);
        }



        protected Golyo AlsoGolyoKivalasztasa(Golyo golyo1, Golyo golyo2, ref bool egyenloSorbanVannakE)
        {
            if (golyo1.SorIndex > golyo2.SorIndex)
            {
                egyenloSorbanVannakE = true;
            }

            if (golyo1.SorIndex > golyo2.SorIndex)
            {
                return Golyo.Klon(golyo2);
            }
            else
            {
                return Golyo.Klon(golyo1);
            }
        }

        // TODO: Kell egy olyan teszt, ahol 6db egyszinű golyó van egymás mellett :)
        /// <summary>
        /// Adott sorIndex-től felfele a Palya beállításaihoz mérten null-ra állítja a játékos számára pontokat érő golyókat
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="palyaBeallitasok"></param>
        /// <param name="jatekos"></param>
        /// <param name="sorIndex"></param>
        /// <returns></returns>
        protected int AzonosSzinuGolyokEltunteteseEgySorban(Golyo[,] palya, Palya palyaBeallitasok, Jatekos jatekos, int sorIndex)
        {
            int             oszlopokSzama = palya.GetLength(1),
                legalsoModositottSorIndex = -1;

            Golyo kituntetettGolyo = palya[sorIndex, oszlopokSzama];

            for (int i = sorIndex; i >= 0; i--)
            {
                int azonosSzinuGolyokSzama = 1;

                for (int j = oszlopokSzama - 2; j >= 0; j--)
                {
                    Golyo vizsgaltGolyo = palya[i, j];

                    if (kituntetettGolyo.Szine == vizsgaltGolyo.Szine)
                    {
                        azonosSzinuGolyokSzama++;
                    }
                    else
                    {
                        if (azonosSzinuGolyokSzama >= palyaBeallitasok.MinEgyszinuGolyokSzama)
                        {
                            kituntetettGolyo = null;
                        }

                        kituntetettGolyo = vizsgaltGolyo;
                        azonosSzinuGolyokSzama = 1;
                    }

                    if (azonosSzinuGolyokSzama < palyaBeallitasok.MaxEgyszinuGolyokSzama &&
                        azonosSzinuGolyokSzama >= palyaBeallitasok.MinEgyszinuGolyokSzama)
                    {
                        if (legalsoModositottSorIndex == -1)
                        {
                            legalsoModositottSorIndex = i;
                        }

                        vizsgaltGolyo = null;
                    }
                }
            }

            return legalsoModositottSorIndex;
        }
    }
}
