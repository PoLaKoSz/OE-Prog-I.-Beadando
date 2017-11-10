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

        public static Golyo Klon(Golyo golyo)
        {
            return new Golyo(golyo.SorIndex, golyo.OszlopIndex, golyo.Szine);
        }

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

        public override string ToString()
        {
            return string.Format("({0};{1}) : {2}", SorIndex, OszlopIndex, Szine);
        }

        public override int GetHashCode()
        {
            var hashCode = 453514109;
            hashCode = hashCode * -1521134295 + SorIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + OszlopIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + Szine.GetHashCode();
            return hashCode;
        }
    }
}
