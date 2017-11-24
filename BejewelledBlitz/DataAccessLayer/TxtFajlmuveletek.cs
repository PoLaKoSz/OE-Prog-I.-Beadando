using System.IO;

namespace PoLaKoSz.BejewelledBlitz
{
    public class TxtFajlmuveletek
    {
        string FileNev;



        public TxtFajlmuveletek(string fileNev)
        {
            FileNev = fileNev + ".txt";
        }



        /// <summary>
        /// Megadott fájl sorainak beolvasása egy string[]-be. Amennyiben nem létezik a fájl, egy üres tömböt ad vissza
        /// </summary>
        /// <returns></returns>
        public string[] FajlSorainakBeolvasasa()
        {
            // Nem túl jó Exception kezelés :)
            if (!File.Exists(FileNev))
            {
                return new string[0];
            }

            string sorokEgySorban = "";

            using (var streamReader = new StreamReader(FileNev))
            {
                while (!streamReader.EndOfStream)
                {
                    sorokEgySorban += streamReader.ReadLine() + "\n";
                }
            }

            return sorokEgySorban.Remove(sorokEgySorban.Length - 1).Split('\n');
        }

        /// <summary>
        /// String tömb elemeinek soronkénti mentése a fájlba
        /// </summary>
        /// <param name="sorok"></param>
        public void StringTombMentese(string[] sorok)
        {
            using (var streamWriter = new StreamWriter(FileNev))
            {
                foreach (string sor in sorok)
                {
                    streamWriter.WriteLine(sor);
                }
            }
        }
    }
}
