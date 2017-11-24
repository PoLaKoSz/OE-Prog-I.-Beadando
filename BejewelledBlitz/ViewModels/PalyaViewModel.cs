using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaViewModel
    {
        protected Jatekos Jatekos;
        protected Palya Palya;
        PalyaView PalyaView;



        public PalyaViewModel(Jatekos jatekos)
        {
            Jatekos = jatekos;

            Palya = new Palya(Jatekos.SorokSzama, Jatekos.OszlopokSzama);
            PalyaFeltolteseSzinesGolyokkal();

            PalyaView = new PalyaView(Palya.Jatekter);
        }



        /// <summary>
        /// A mátrix feltöltése színes golyókkal úgy, hogy egymás mellett ne legyen két egyforma színű golyó
        /// </summary>
        /// <param name="palya"></param>
        void PalyaFeltolteseSzinesGolyokkal()
        {
            int    sorokSzama = Palya.Jatekter.GetLength(0);
            int oszlopokSzama = Palya.Jatekter.GetLength(1);

            for (int y = 0; y < oszlopokSzama; y++)
            {
                OszlopUresHelyeireRandomGolyok(sorokSzama - 1, y);
            }
        }

        /// <summary>
        /// Jelenlegi pálya kirajzolása, majd 2 golyó koordinátáinak bekérése, illetve a csere elvégzése a következményeivel együtt
        /// </summary>
        public void Leptetes()
        {
            PalyaView.RefreshUI();

            Golyo[] golyok = PalyaView.GolyokKoordinatainakBekerese();
            Lepes(golyok[0], golyok[1]);
        }

        /// <summary>
        /// Ha a megadott két golyó egymás mellett, vagy felett van, és az így kialakult cserével (1-es rész) egymás mellé vagy fölé kerül
        /// minimum a Palya osztályban beállított egyszínű golyó, akkor eltünteti azokat, pontokat ad utánuk és a helyükre
        /// a fölöttük lévő golyó, vagy random színű kerül, majd a módosult sortól újraindul az 1-es rész
        /// </summary>
        /// <param name="golyo1"></param>
        /// <param name="golyo2"></param>
        protected void Lepes(Golyo golyo1, Golyo golyo2)
        {
            var egymasMellett = EgymasMellettE(golyo1, golyo2);
            var  egymasFelett = EgymasFelettE(golyo1, golyo2);

            if (egymasMellett || egymasFelett)
            {
                int legalsoModositottSorindex = (golyo1.SorIndex > golyo2.SorIndex) ? golyo1.SorIndex: golyo2.SorIndex;

                KetGolyoCserejePalyan(golyo1, golyo2);
                
                do
                {
                    legalsoModositottSorindex = AzonosSzinuGolyokEltuntetese(Palya, Jatekos, legalsoModositottSorindex);

                    UresHelyekreGolyokLehozasa(legalsoModositottSorindex);

                    legalsoModositottSorindex--;
                } while (legalsoModositottSorindex >= 0);
            }
        }

        void KetGolyoCserejePalyan(Golyo golyo1, Golyo golyo2)
        {
            ConsoleColor golyo1Szine = golyo1.Szine;
            Palya.Jatekter[golyo1.SorIndex, golyo1.OszlopIndex] = new Golyo(golyo1.SorIndex, golyo1.OszlopIndex, golyo2.Szine);
            Palya.Jatekter[golyo2.SorIndex, golyo2.OszlopIndex] = new Golyo(golyo2.SorIndex, golyo2.OszlopIndex, golyo1Szine);
        }


        bool EgymasMellettE(Golyo golyo1, Golyo golyo2)
        {
            return golyo1.SorIndex == golyo2.SorIndex &&
                   Math.Abs(golyo1.OszlopIndex - golyo2.OszlopIndex) == 1;
        }

        bool EgymasFelettE(Golyo golyo1, Golyo golyo2)
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
        int AzonosSzinuGolyokEltuntetese(Palya palyaBeallitasok, Jatekos jatekos, int sorIndex)
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

                        PontokatEroGolyokEltuntetese(x, y, azonosSzinuGolyok);

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
        int MegszamlalasTetel(Golyo[,] palya, int sorIndex, int oszlopIndex)
        {
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
        /// <param name="x"></param>
        /// <param name="oszlopIndex"></param>
        /// <param name="darabszam"></param>
        void PontokatEroGolyokEltuntetese(int x, int oszlopIndex, int darabszam)
        {
            for (int y = oszlopIndex; y > oszlopIndex - darabszam; y--)
            {
                Palya.Jatekter[x, y] = null;
            }
        }

        /// <summary>
        /// Üres helyek helyére a fölötte lévő golyó kerül, vagy ha már nincs fölötte golyó, akkor generál egy véletlen színűt úgy,
        /// hogy egymás mellett ne legyen két azonos színű
        /// </summary>
        /// <param name="sorIndex"></param>
        void UresHelyekreGolyokLehozasa(int sorIndex)
        {
            int oszlopokSzama = Palya.Jatekter.GetLength(1);

            for (int y = 0; y < oszlopokSzama; y++)
            {
                FuggolegesSzetvalogatasHelybenCserevel(sorIndex, y);

                OszlopUresHelyeireRandomGolyok(sorIndex, y);
            }
        }

        /// <summary>
        /// A megadott sorindextől felfele (a sorindexet is beleértve) minden üres helyet a tetejére visz, és a színes golyókat pedig az aljához "szorítja"
        /// </summary>
        /// <param name="sorIndextolFelfele"></param>
        /// <param name="y"></param>
        void FuggolegesSzetvalogatasHelybenCserevel(int sorIndextolFelfele, int y)
        {
            Golyo[,] palya = Palya.Jatekter;
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
        /// <param name="sorIndex"></param>
        /// <param name="y"></param>
        void OszlopUresHelyeireRandomGolyok(int sorIndex, int y)
        {
            var         palya = Palya.Jatekter;
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
