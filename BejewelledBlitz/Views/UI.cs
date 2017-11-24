using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class UI
    {
        protected void ConsoleTorlese()
        {
            Console.Clear();
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

        /// <summary>
        /// Console ablak nevének megváltoztatása
        /// </summary>
        /// <param name="nev"></param>
        public static void ConsoleAblakNev(string nev)
        {
            Console.Title = nev;
        }
    }
}
