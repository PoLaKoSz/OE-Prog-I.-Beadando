using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaViewModel
    {
        Palya Palya;

        PalyaView PalyaView;

        Jatekos Jatekos;



        public PalyaViewModel(Jatekos jatekos)
        {
            Jatekos = jatekos;

            Palya = new Palya(Jatekos.SorokSzama, Jatekos.OszlopokSzama);
            PalyaFeltolteseSzinesGolyokkal(Palya.Jatekter);

            PalyaView = new PalyaView(Palya);
        }



        /// <summary>
        /// A mátrix feltöltése színes golyókkal úgy, hogy egymás mellett ne legyen két egyforma színű golyó
        /// </summary>
        /// <param name="palya"></param>
        void PalyaFeltolteseSzinesGolyokkal(Golyo[,] palya)
        {
            int sorokSzama = palya.GetLength(0);
            int oszlopokSzama = palya.GetLength(1);

            for (int y = 0; y < oszlopokSzama; y++)
            {
                OszlopUresHelyeireRandomGolyok(palya, sorokSzama - 1, y);
            }
        }

        public void Leptetes()
        {
            PalyaView.RefreshUI();

            Golyo[] golyok = PalyaView.GolyokKoordinatainakBekerese();
            Lepes(golyok[0], golyok[1]);
        }

        protected void Lepes(Golyo golyo1, Golyo golyo2)
        {
            var egymasMellett = EgymasMellettE(golyo1, golyo2);
            var egymasFelett = EgymasFelettE(golyo1, golyo2);

            if (egymasMellett || egymasFelett)
            {
                int legalsoModositottSorindex = AzonosSzinuGolyokEltuntetese(Palya, Jatekos, 0);

                UresHelyekreGolyokLehozasa(Palya.Jatekter, legalsoModositottSorindex);
            }            
        }

        public bool EgymasMellettE(Golyo golyo1, Golyo golyo2)
        {
            return golyo1.SorIndex == golyo2.SorIndex &&
                   Math.Abs(golyo1.OszlopIndex - golyo2.OszlopIndex) == 1;
        }

        public bool EgymasFelettE(Golyo golyo1, Golyo golyo2)
        {
            return golyo1.OszlopIndex == golyo2.OszlopIndex &&
                   Math.Abs(golyo1.SorIndex - golyo2.SorIndex) == 1;
        }

        /// <summary>
        /// Adott sorIndex-től felfele a Palya beállításaihoz mérten null-ra állítja a játékos számára pontokat érő golyókat (és pontokat is ad a jétékosnak)
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="palyaBeallitasok"></param>
        /// <param name="jatekos"></param>
        /// <param name="sorIndex"></param>
        /// <returns></returns>
        public int AzonosSzinuGolyokEltuntetese(Palya palyaBeallitasok, Jatekos jatekos, int sorIndex)
        {
            Golyo[,] palya = palyaBeallitasok.Jatekter;

            int             oszlopokSzama = palya.GetLength(1),
                legalsoModositottSorIndex = 0;

            for (int x = sorIndex; x >= 0; x--)
            {
                for (int y = oszlopokSzama - 1; y >= 0; y--)
                {
                    int azonosSzinuGolyok = MegszamlalasTetel(palya, x, y);

                    if (azonosSzinuGolyok >= palyaBeallitasok.MinEgyszinuGolyokSzama)
                    {
                        jatekos.Pontszam += azonosSzinuGolyok;

                        PontokatEroGolyokEltuntetese(palya, x, y, azonosSzinuGolyok);

                        if (legalsoModositottSorIndex == 0)
                        {
                            legalsoModositottSorIndex = x;
                        }
                    }

                    y -= azonosSzinuGolyok - 1;
                }
            }

            return legalsoModositottSorIndex;
        }

        /// <summary>
        /// Megszámolja, hogy a paraméterként megadott sor- és oszlopindex-ű golyóval együtt hány vele egyszínű golyó van tőle balra
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="sorIndex"></param>
        /// <param name="oszlopIndex"></param>
        /// <returns></returns>
        public int MegszamlalasTetel(Golyo[,] palya, int sorIndex, int oszlopIndex)
        {
            int       oszlopokSzama = palya.GetLength(1);
            int egyszinuGolyokSzama = 1;

            for (int y = oszlopIndex - 1; y >= 0; y--)
            {
                if (palya[sorIndex, y].Szine == palya[sorIndex, oszlopIndex].Szine)
                {
                    egyszinuGolyokSzama++;
                }
                else
                {
                    y = -1;
                }
            }

            return egyszinuGolyokSzama;
        }

        /// <summary>
        /// A megadott indexű sorban, a megadott oszlopindexet is beleértve balra haladva a megadott darabszámnyi null érték beírása a táblázatba
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="x"></param>
        /// <param name="oszlopIndex"></param>
        /// <param name="darabszam"></param>
        public void PontokatEroGolyokEltuntetese(Golyo[,] palya, int x, int oszlopIndex, int darabszam)
        {
            for (int y = oszlopIndex; y > oszlopIndex - darabszam; y--)
            {
                palya[x, y] = null;
            }
        }

        /// <summary>
        /// Üres helyek helyére a fölötte lévő golyó kerül, vagy ha már nincs fölötte golyó, akkor generál egy véletlen színűt úgy,
        /// hogy egymás mellett ne legyen két azonos színű
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="sorIndex"></param>
        public void UresHelyekreGolyokLehozasa(Golyo[,] palya, int sorIndex)
        {
            int oszlopokSzama = palya.GetLength(1);

            for (int y = 0; y < oszlopokSzama; y++)
            {
                FuggolegesSzetvalogatasHelybenCserevel(palya, sorIndex, y);

                OszlopUresHelyeireRandomGolyok(palya, sorIndex, y);
            }
        }

        /// <summary>
        /// A megadott sorindextől felfele (a sorindexet is beleértve) minden üres helyet a tetejére visz, és a színes golyókat pedig az aljához "szorítja"
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="sorIndextolFelfele"></param>
        /// <param name="y"></param>
        public void FuggolegesSzetvalogatasHelybenCserevel(Golyo[,] palya, int sorIndextolFelfele, int y)
        {
            int belsoSorindex = int.MaxValue;

            for (int x = sorIndextolFelfele; x >= 0; x--)
            {
                if (palya[x, y] == null)
                {
                    belsoSorindex = x - 1;
                    for (int j = belsoSorindex; j >= 0; j--)
                    {
                        if (palya[j, y] != null)
                        {
                            belsoSorindex = j;
                            j = -1;
                        }
                    }

                    if (belsoSorindex >= 0 && palya[belsoSorindex, y] != null)
                    {
                        palya[x, y] = new Golyo(x, y, palya[belsoSorindex, y].Szine);
                        palya[belsoSorindex, y] = null;
                    }
                }
            }
        }

        /// <summary>
        /// A megadott oszlopban a megadott sortól felfele (a sor indexét is beleértve) minden üres helyre egy olyan színű golyót rak be, ami se az üres hely jobb, sem a bal oldalán nincs
        /// </summary>
        /// <param name="palya"></param>
        /// <param name="sorIndex"></param>
        /// <param name="y"></param>
        public void OszlopUresHelyeireRandomGolyok(Golyo[,] palya, int sorIndex, int y)
        {
            int oszlopokSzama = palya.GetLength(1);

            for (int x = 0; x <= sorIndex; x++)
            {
                if (palya[x, y] == null)
                {
                    var generaltGolyo = Golyo.RandomSzinuGolyo(x, y);

                    while (y > 0 && palya[x, (y - 1)] != null && generaltGolyo.Szine == palya[x, (y - 1)].Szine ||
                        y < oszlopokSzama - 2 && palya[x, (y + 1)] != null && generaltGolyo.Szine == palya[x, (y + 1)].Szine)
                    {
                        generaltGolyo = Golyo.RandomSzinuGolyo(x, y);
                    }

                    palya[x, y] = generaltGolyo;
                }
            }
        }
    }
}
