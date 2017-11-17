using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaView : UI
    {
        Palya Jatekter;



        public PalyaView(Palya jatekter)
        {
            Jatekter = jatekter;
        }



        public Golyo[] GolyokKoordinatainakBekerese()
        {
            Golyo golyo1 = Jatekter.Jatekter[SorszamBeker(1), OszlopszamBeker(1)];
            Golyo golyo2 = Jatekter.Jatekter[SorszamBeker(2), OszlopszamBeker(2)];

            return new Golyo[]
            {
                golyo1, golyo2
            };
        }

        private int SorszamBeker(int golyoSorszama)
        {
            int valasz;

            do
            {
                valasz = IntInputBeker("Kérlek add meg a(z) " + golyoSorszama + ". golyó sorának számát: ") - 1;
            } while (0 > valasz || valasz >= Jatekter.Jatekter.GetLength(0)); // Hogyha grafikus lenne a játék, akkor szerintem nem is kéne ellenőrizni ezt (View-ban nem ajánlott validálni)

            return valasz;
        }

        private int OszlopszamBeker(int golyoSorszama)
        {
            int valasz;

            do
            {
                valasz = IntInputBeker("Kérlek add meg a(z) " + golyoSorszama + ". golyó oszlopának számát: ") - 1;
            } while (0 > valasz || valasz >= Jatekter.Jatekter.GetLength(1)); // Hogyha grafikus lenne a játék, akkor szerintem nem is kéne ellenőrizni ezt (View-ban nem ajánlott validálni)

            return valasz;
        }

        public void RefreshUI()
        {
            // https://stackoverflow.com/a/2743263/7306734
            Golyo[,] matrix = Jatekter.Jatekter;

            int sorokSzama = matrix.GetLength(0);
            int oszlopokSzama = matrix.GetLength(1);

            FejlecHozzadasa(sorokSzama, oszlopokSzama);

            SorszamozottTartalom(matrix, sorokSzama, oszlopokSzama);            
        }

        void FejlecHozzadasa(int sorokSzama, int oszlopokSzama)
        {
            Console.Write("            ");

            for (int j = 0; j < oszlopokSzama; j++)
            {
                Console.Write(" {0, 2}  ", j + 1);
            }
        }

        void SorszamozottTartalom(Golyo[,] matrix, int sorokSzama, int oszlopokSzama)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < sorokSzama; i++)
            {
                Console.Write("{0, 3}        |", i + 1);

                for (int j = 0; j < oszlopokSzama; j++)
                {
                    Console.ForegroundColor = matrix[i, j].Szine;

                    Console.Write(" {0, 2}", 0);

                    Console.ResetColor();

                    Console.Write(" |");
                }

                Console.WriteLine();
            }
        }
    }
}
