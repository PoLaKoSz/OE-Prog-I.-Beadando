using System;
using System.Collections.Generic;

namespace PoLaKoSz.BejewelledBlitz
{
    public class RanglistaView
    {
        List<Jatekos> Ranglista;



        public RanglistaView(List<Jatekos> ranglista)
        {
            Ranglista = ranglista;
        }



        /// <summary>
        /// Ranglista kiíratása a képernyőre
        /// </summary>
        public void UiFrissitese()
        {
            Console.WriteLine("{0, 5}{1, 20}{2, 10}{3, 10}", "#", "Név", "Játékidő", "Pontszám");

            for (int i = 0; i < Ranglista.Count; i++)
            {
                Jatekos jatekos = Ranglista[i];

                Console.WriteLine("{0, 5}{1, 20}{2, 10}{3, 10}", (i + 1), jatekos.Nev, jatekos.Jatekido, jatekos.Pontszam);
            }
        }
    }
}
