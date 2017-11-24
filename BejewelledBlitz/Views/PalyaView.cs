using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaView// : UI
    {
        Golyo[,] Palya;



        public PalyaView(Golyo[,] palya)
        {
            Palya = palya;
        }



        public Golyo[] GolyokKoordinatainakBekerese()
        {
            Golyo golyo1 = Palya[SorszamBeker(1), OszlopszamBeker(1)];
            Golyo golyo2 = Palya[SorszamBeker(2), OszlopszamBeker(2)];

            return new Golyo[]
            {
                golyo1, golyo2
            };
        }

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

        int SorszamBeker(int golyoSorszama)
        {
            int valasz;

            do
            {
                valasz = IntInputBeker("Kérlek add meg a(z) " + golyoSorszama + ". golyó sorának számát: ") - 1;
            } while (0 > valasz || valasz >= Palya.GetLength(0)); // Hogyha grafikus lenne a játék, akkor szerintem nem is kéne ellenőrizni ezt (View-ban nem ajánlott validálni)

            return valasz;
        }

        int OszlopszamBeker(int golyoSorszama)
        {
            int valasz;

            do
            {
                valasz = IntInputBeker("Kérlek add meg a(z) " + golyoSorszama + ". golyó oszlopának számát: ") - 1;
            } while (0 > valasz || valasz >= Palya.GetLength(1)); // Hogyha grafikus lenne a játék, akkor szerintem nem is kéne ellenőrizni ezt (View-ban nem ajánlott validálni)

            return valasz;
        }

        /// <summary>
        /// Jelenlegi pálya kiírása sorszámozással és oszlopszámozással a felhasználói felületre
        /// </summary>
        public void RefreshUI()
        {
            int sorokSzama = Palya.GetLength(0);
            int oszlopokSzama = Palya.GetLength(1);

            FejlecHozzadasa(sorokSzama, oszlopokSzama);

            SorszamozottTartalom(sorokSzama, oszlopokSzama);

            //ConsoleTorlese();//Ezt ide lehetne rakni, de szerintem jobb, ha látszódik a korábbi pálya állása is
        }

        /// <summary>
        /// A pálya oszlopainak száma megjelenítése a színes pálya felett
        /// </summary>
        /// <param name="sorokSzama"></param>
        /// <param name="oszlopokSzama"></param>
        void FejlecHozzadasa(int sorokSzama, int oszlopokSzama)
        {
            Console.Write("            ");

            for (int j = 0; j < oszlopokSzama; j++)
            {
                Console.Write(" {0, 2}  ", j + 1);
            }
        }

        /// <summary>
        /// Pálya tartalmának kiírása a képernyőre a sorszámozással együtt
        /// </summary>
        /// <param name="sorokSzama"></param>
        /// <param name="oszlopokSzama"></param>
        void SorszamozottTartalom(int sorokSzama, int oszlopokSzama)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < sorokSzama; i++)
            {
                Console.Write("{0, 3}        |", i + 1);

                for (int j = 0; j < oszlopokSzama; j++)
                {
                    // https://stackoverflow.com/a/2743263/7306734
                    Console.ForegroundColor = Palya[i, j].Szine;

                    Console.Write(" {0, 2}", 0);

                    Console.ResetColor();

                    Console.Write(" |");
                }

                Console.WriteLine();
            }
        }
    }
}
