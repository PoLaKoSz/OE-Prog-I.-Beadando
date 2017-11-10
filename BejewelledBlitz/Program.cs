using System;

namespace PoLaKoSz.BejewelledBlitz
{
    class Program
    {
        static void Main(string[] args)
        {
            new PalyaViewModel(new JatekosViewModel().Jatekos)/*.UpdateUI()*/;

            Console.Read();
        }
    }
}
