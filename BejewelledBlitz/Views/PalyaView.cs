using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class PalyaView : UI
    {
        public Palya Jatekter { get; private set; }



        public PalyaView(Palya jatekter)
        {
            Jatekter = jatekter;
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

        private void FejlecHozzadasa(int sorokSzama, int oszlopokSzama)
        {
            Console.Write("            ");

            for (int j = 0; j < oszlopokSzama; j++)
            {
                Console.Write(" {0, 2}  ", j + 1);
            }
        }

        private void SorszamozottTartalom(Golyo[,] matrix, int sorokSzama, int oszlopokSzama)
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
