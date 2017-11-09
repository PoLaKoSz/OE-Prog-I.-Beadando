using System;

namespace PoLaKoSz.BejewelledBlitz
{
    // TODO: Újragondolni az osztályt
    public class PalyaViewModel : UI
    {
        public Palya Palya { get; private set; }

        private PalyaView PalyaView { get; set; }

        public Jatekos Jatekos { get; private set; }



        public PalyaViewModel(Jatekos jatekos)
        {
            Jatekos = jatekos;

            Palya = new Palya(Jatekos.SorokSzama, Jatekos.OszlopokSzama, 5);
            Palya = PalyaFeltoltese(Palya);

            PalyaView = new PalyaView(Palya);
        }



        private Palya PalyaFeltoltese(Palya jatekter)
        {
            int sorokSzama = jatekter.Jatekter.GetLength(0);
            int oszlopokSzama = jatekter.Jatekter.GetLength(1);

            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < oszlopokSzama; j++)
                {
                    if (jatekter.Jatekter[i, j] == null)
                    {
                        jatekter.Jatekter[i, j] = Golyo.RandomSzinuGolyo(i, j);
                    }
                }
            }

            return jatekter;
        }
        
        public  bool GolyokCserelhetokE(Palya palya, Golyo golyo1, Golyo golyo2)
        {
            GolyokCsereje(palya.Jatekter, ref golyo1, ref golyo2);

            // TODO: Csere után kell vizsgálni, hogy került-e így egymás mellé min. 2 azonos színű golyó
            if (EgymasMellettE(golyo1, golyo2) || EgymasFelettE(golyo1, golyo2)
                &&
                VanEMelletteAzonosSzinuGolyo(palya, golyo1) || VanEMelletteAzonosSzinuGolyo(palya, golyo2))
            {
                GolyokCsereje(palya.Jatekter, ref golyo1, ref golyo2);

                return true;
            }

            GolyokCsereje(palya.Jatekter, ref golyo1, ref golyo2);

            return false;
        }

        // TODO: UnitTest miatt public, egyébként a módosító metódusokat private-re kéne állítani
        public Golyo[,] GolyokCsereje(Golyo[,] palya, ref Golyo golyo1, ref Golyo golyo2)
        {
            // Valójában csak a színek kerülnek cserére
            var tmpGolyoSzine = golyo1.Szine;

            golyo1 = new Golyo(golyo1.SorIndex, golyo1.OszlopIndex, golyo2.Szine);
            golyo2 = new Golyo(golyo2.SorIndex, golyo2.OszlopIndex, tmpGolyoSzine);

            palya[golyo1.SorIndex, golyo1.OszlopIndex] = golyo1;
            palya[golyo2.SorIndex, golyo2.OszlopIndex] = golyo2;
            
            return palya;
        }

        public bool EgymasFelettE(Golyo golyo1, Golyo golyo2)
        {
            if (golyo1.OszlopIndex != golyo2.OszlopIndex ||
                Math.Abs(golyo1.SorIndex - golyo2.SorIndex) != 1)
            {
                return false;
            }

            return true;
        }

        public bool EgymasMellettE(Golyo golyo1, Golyo golyo2)
        {
            if (golyo1.SorIndex != golyo2.SorIndex ||
                Math.Abs(golyo1.OszlopIndex - golyo2.OszlopIndex) != 1)
            {
                return false;
            }

            return true;
        }

        public bool VanEMelletteAzonosSzinuGolyo(Palya palya, Golyo golyo)
        {
            int talaltEgyszinuGolyokSzama  = AzonosSzinuGolyokSzamaBalrol(palya.Jatekter, golyo);
                talaltEgyszinuGolyokSzama += AzonosSzinuGolyokSzamaJobbrol(palya.Jatekter, golyo);

            return talaltEgyszinuGolyokSzama >= palya.MinEgyszinuGolyokSzama - 1;
        }

        public int AzonosSzinuGolyokSzamaBalrol(Golyo[,] palya, Golyo golyo)
        {
            int oszlopokSzama = palya.GetLength(1);
            int talaltEgyszinuGolyokSzama = 0;

            for (int i = golyo.OszlopIndex - 1; i >= 0; i--)
            {
                if (palya[golyo.SorIndex, i].Szine == golyo.Szine)
                {
                    talaltEgyszinuGolyokSzama++;
                }
                else
                {
                    return talaltEgyszinuGolyokSzama;
                }
            }

            return talaltEgyszinuGolyokSzama;
        }

        public int AzonosSzinuGolyokSzamaJobbrol(Golyo[,] palya, Golyo golyo)
        {
            int oszlopokSzama = palya.GetLength(1);
            int talaltEgyszinuGolyokSzama = 0;

            for (int i = golyo.OszlopIndex + 1; i < oszlopokSzama; i++)
            {
                if (palya[golyo.SorIndex, i].Szine == golyo.Szine)
                {
                    talaltEgyszinuGolyokSzama++;
                }
                else
                {
                    return talaltEgyszinuGolyokSzama;
                }
            }

            return talaltEgyszinuGolyokSzama;
        }

        public void UpdateUI()
        {
            PalyaView.RefreshUI();

            var golyo1Koordinatak = GolyoKoordinatainakBekerese(1);

            var golyo2Koordinatak = GolyoKoordinatainakBekerese(2);

            Golyo golyo1 = GolyoKivalasztasaKoordinatakAlapjan(Palya, golyo1Koordinatak.XTengely, golyo1Koordinatak.YTengely),
                  golyo2 = GolyoKivalasztasaKoordinatakAlapjan(Palya, golyo2Koordinatak.XTengely, golyo2Koordinatak.YTengely);

            if (GolyokCserelhetokE(Palya, golyo1, golyo2))
            {
                GolyokCsereje(Palya.Jatekter, ref golyo1, ref golyo2);

                AzonosSzinuGolyokEltuntetese(Palya.Jatekter);

                UresHelyekFeltolteseGolyokkal(Palya.Jatekter);
            }

            UpdateUI();
        }

        // TODO: Azonos színű golyók eltüntetése (ez még legyen az easy játék mód, hogy a kezdeti generált golyókat is beleszámítja)
        private void AzonosSzinuGolyokEltuntetese(Golyo[,] jatekter)
        {
            int sorokSzama = jatekter.GetLength(0);
            int oszlopokSzama = jatekter.GetLength(1);

            Golyo kituntetettGolyo = jatekter[sorokSzama - 1, oszlopokSzama - 1];

            for (int i = sorokSzama - 1; i >= 0; i--)
            {
                for (int j = oszlopokSzama - 2; j >= 0; j++)
                {
                    if (jatekter[i, j].Szine == kituntetettGolyo.Szine)
                    {
                        jatekter[i, j] = GolyoEgySorralLejjebbHozasa(jatekter, i + 1, j);
                    }
                }
            }
        }

        public Golyo GolyoEgySorralLejjebbHozasa(Golyo[,] palya, int felsoGolyoSorindex, int felsoGolyoOszlopIndex)
        {
            if (felsoGolyoSorindex < 0)
            {
                return Golyo.RandomSzinuGolyo(felsoGolyoSorindex + 1, felsoGolyoOszlopIndex);
            }

            ConsoleColor ujGolyoSzine = palya[felsoGolyoSorindex, felsoGolyoOszlopIndex].Szine;

            return new Golyo(felsoGolyoSorindex + 1, felsoGolyoOszlopIndex, ujGolyoSzine);
        }

        private void UresHelyekFeltolteseGolyokkal(Golyo[,] jatekter)
        {
            int sorokSzama = jatekter.GetLength(0);
            int oszlopokSzama = jatekter.GetLength(1);

            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < oszlopokSzama; j++)
                {
                    if (jatekter[i, j] == null)
                    {
                        jatekter[i, j] = Golyo.RandomSzinuGolyo(i, j);
                    }
                }
            }
        }

        private Koordinata GolyoKoordinatainakBekerese(int golyoIndex)
        {
            int xTengely,
                yTengely,

                  jatekterSorainakSzama = Palya.Jatekter.GetLength(0),
                jatekterOszlopainkSzama = Palya.Jatekter.GetLength(1);

            do
            {
                xTengely = IntInputBeker("Kérlek add meg a(z) " + golyoIndex + ". cserélendö golyó sorának számát: ");
            } while (xTengely < 1 || xTengely > jatekterSorainakSzama);

            do
            {
                yTengely = IntInputBeker("Kérlek add meg a(z) " + golyoIndex + ". cserélendö golyó oszlopának számát: ");
            } while (yTengely < 1 || yTengely > jatekterOszlopainkSzama);

            return new Koordinata(xTengely - 1,
                                  yTengely - 1);
        }

        public Golyo GolyoKivalasztasaKoordinatakAlapjan(Palya palya, int sorIndex, int oszlopIndex)
        {
            return palya.Jatekter[sorIndex, oszlopIndex];
        }
    }
}
