using System.Collections.Generic;

namespace PoLaKoSz.BejewelledBlitz
{
    public class RanglistaViewModel
    {
        TxtFajlmuveletek txtFajlmuveletek;
        /* Megjegyzés:
         * Tudom, hogy nem szabadna Listát alkalmazni, de ha azzal csináltam volna, akkor minden egyes Ranglista kiíráskor át kellett volna
         * először adjam a Ranglista tömböt, mert az UjJatekeredmenyHozzaadasa() metódusban ahhoz, hogy új elemet tudjak hozzáadni a
         * tömbhöz egy új tömböt kell létrehozzak, így a konstruktorban a RanglistaView-nek átadott tömb elvesztette volna a referenciáját.
        */
        List<Jatekos> Ranglista;
        RanglistaView View;



        public RanglistaViewModel()
        {
            txtFajlmuveletek = new TxtFajlmuveletek("Dicsosegtabla.txt");

            KorabbiRanglistaBetolteseFajlbol();

            View = new RanglistaView(Ranglista);
        }
        

        
        void KorabbiRanglistaBetolteseFajlbol()
        {
            string[] sorok = txtFajlmuveletek.FajlSorainakBeolvasasa();

            if (sorok.Length == 0)
            {
                Ranglista = new List<Jatekos>();
            }
            else
            {
                Ranglista = new List<Jatekos>();

                foreach (string sor in sorok)
                {
                    Ranglista.Add(Jatekos.Parse(sor));
                }                
            }
        }

        /// <summary>
        /// Új játékos hozzáadása a ranglistához, majd ranglista rendezése, illetve mentése adattárolóra
        /// </summary>
        /// <param name="jatekos"></param>
        public void UjJatekeredmenyHozzaadasa(Jatekos jatekos)
        {
            Ranglista.Add(jatekos);

            JavitottBeillesztesesRendezes(Ranglista);

            RanglistaMenteseFajlba();
        }

        /// <summary>
        /// Ranglista a játék időtartama és azon belül a játékos pontszáma szerinti rendezése
        /// Lista első helyére kerül a leghosszabb ideig játszó, legtöbb pontot elért játékos
        /// </summary>
        /// <param name="x"></param>
        public void JavitottBeillesztesesRendezes(List<Jatekos> x)
        {
            for (int i = 1; i < x.Count; i++)
            {
                int j = i - 1;
                Jatekos seged = x[i];

                while ( (j >= 0) &&
                    (x[j].Jatekido < seged.Jatekido ||
                        (x[j].Jatekido == seged.Jatekido && x[j].Pontszam < seged.Pontszam)))
                {
                    x[j + 1] = x[j];
                    j--;
                }

                x[j + 1] = seged;
            }
        }

        void RanglistaMenteseFajlba()
        {
            string[] sorok = new string[Ranglista.Count];

            for (int i = 0; i < Ranglista.Count; i++)
            {
                sorok[i] = Ranglista[i].ToString();
            }

            txtFajlmuveletek.StringTombMentese(sorok);
        }

        /// <summary>
        /// Ranglista megjelenítése a képernyőn
        /// </summary>
        public void RanglistaKiirasa()
        {
            View.UiFrissitese();
        }
    }
}
