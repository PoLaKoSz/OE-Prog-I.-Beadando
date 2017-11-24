using System;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Golyo
    {
        public int SorIndex { get; private set; }

        public int OszlopIndex { get; private set; }

        public ConsoleColor Szine { get; private set; }
        
        static Random random = new Random();

        static ConsoleColor[] MegengedettSzinek = new ConsoleColor[]
        {
            ConsoleColor.DarkGreen,
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
        };



        public Golyo(int sorIndex, int oszlopIndex, ConsoleColor golyoSzine)
        {
            SorIndex = sorIndex;
            OszlopIndex = oszlopIndex;
            Szine = golyoSzine;
        }



        public static Golyo RandomSzinuGolyo(int sorIndex, int oszlopIndex)
        {
            ConsoleColor randomGolyoSzin = MegengedettSzinek[random.Next(MegengedettSzinek.Length)];

            return new Golyo(sorIndex, oszlopIndex, randomGolyoSzin);
        }

        /// <summary>
        /// UnitTest-hez
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null ||
                obj.GetType() != typeof(Golyo))
            {
                return false;
            }

            Golyo golyo2 = (Golyo)obj;

            if (SorIndex != golyo2.SorIndex ||
                OszlopIndex != golyo2.OszlopIndex ||
                Szine != golyo2.Szine)
            {
                return false;
            }

            return true;
        }
    }
}
