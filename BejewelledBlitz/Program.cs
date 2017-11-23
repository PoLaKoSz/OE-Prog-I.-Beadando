using System;
using System.Timers;

namespace PoLaKoSz.BejewelledBlitz
{
    class Program
    {
        static DateTime JatekKezdetenekIdoPontja;
        static TimeSpan ElteltIdo;
        static Jatekos jatekos;



        static void Main(string[] args)
        {
            var ranglistaViewModel = new RanglistaViewModel();
            var   jatekosViewModel = new JatekosViewModel();
                           jatekos = jatekosViewModel.Jatekos;
            var          palyaView = new PalyaViewModel(jatekosViewModel.Jatekos);
            var            idoMero = new Timer(1000);
            idoMero.Elapsed += IdoMero_Mulas;
            JatekKezdetenekIdoPontja = DateTime.Now;
            idoMero.Start();

            while (ElteltIdo.TotalMilliseconds <= jatekos.Jatekido)
            {
                palyaView.Leptetes();
            }

            ranglistaViewModel.UjJatekeredmenyHozzaadasa(jatekos);

            Console.WriteLine();
            ranglistaViewModel.RanglistaKiirasa();

            Console.Read();
        }

        private static void IdoMero_Mulas(object sender, ElapsedEventArgs e)
        {
            ElteltIdo = e.SignalTime.Subtract(JatekKezdetenekIdoPontja);

            UI.ConsoleAblakNev(Math.Round(ElteltIdo.TotalSeconds) + " másodperc     " + jatekos.Pontszam + " pont");
        }
    }
}
