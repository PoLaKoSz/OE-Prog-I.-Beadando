using System;
using System.Collections.Generic;

namespace PoLaKoSz.BejewelledBlitz
{
    public class Jatekos
    {
        public string Nev { get; private set; }

        /// <summary>
        /// Játékos játékideje ezredmásodpercben
        /// </summary>
        public int Jatekido { get; private set; }

        public int SorokSzama { get; private set; }

        public int OszlopokSzama { get; private set; }

        public int Pontszam { get; set; }



        public Jatekos(string nev, int jatekMiliMP, int pontszam)
            : this(nev, jatekMiliMP, 0, 0)
        {
            Pontszam = pontszam;
        }

        public Jatekos(string nev, int jatekMiliMP, int sorokSzama, int oszlopokSzama)
        {
            Nev = nev;
            Jatekido = jatekMiliMP;
            SorokSzama = sorokSzama;
            OszlopokSzama = oszlopokSzama;
        }



        public static Jatekos Parse(string txtSor)
        {
            var stringDarabok = txtSor.Split(' ');

            return new Jatekos(stringDarabok[0], int.Parse(stringDarabok[1]), int.Parse(stringDarabok[2]));
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Nev, Jatekido, Pontszam);
        }

        public override bool Equals(object obj)
        {
            if (obj == null ||
                obj.GetType() != typeof(Jatekos))
            {
                return false;
            }

            Jatekos jatekos2 = (Jatekos)obj;

            if (!Nev.Equals(jatekos2.Nev) ||
                Jatekido != jatekos2.Jatekido ||
                SorokSzama != jatekos2.SorokSzama ||
                OszlopokSzama != jatekos2.OszlopokSzama ||
                Pontszam != jatekos2.Pontszam)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -1204076784;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nev);
            hashCode = hashCode * -1521134295 + Jatekido.GetHashCode();
            hashCode = hashCode * -1521134295 + SorokSzama.GetHashCode();
            hashCode = hashCode * -1521134295 + OszlopokSzama.GetHashCode();
            hashCode = hashCode * -1521134295 + Pontszam.GetHashCode();
            return hashCode;
        }
    }
}
