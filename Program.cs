using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Levesek_BA20240417
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adatbázis kapcsolat létrehozása
            Adatbazis_kapcsolat kapcsolat = new Adatbazis_kapcsolat();

            // Levesek listájának lekérdezése
            List<Leves> levesek = kapcsolat.getLevesek();

            // Levesek száma az adatbázisban
            Console.WriteLine($"Levesek száma: {levesek.Count}");

            // Legmagasabb kalóriatartalmú leves megkeresése
            Leves legmagasabbKaloria = levesek[0];
            foreach (Leves leves in levesek)
            {
                if (leves.Kaloria > legmagasabbKaloria.Kaloria)
                {
                    legmagasabbKaloria = leves;
                }
            }
            Console.WriteLine($"Legmagasabb kalóriatartalmú leves: {legmagasabbKaloria.Megnevezes} ({legmagasabbKaloria.Kaloria} kcal)");

            // Levesek listázása, amelyek nevében nem szerepel a "leves" szó
            Console.WriteLine("\nLevesek, amelyek nevében nem szerepel a \"leves\" szó:");
            foreach (Leves leves in levesek)
            {
                if (!leves.Megnevezes.ToLower().Contains("leves"))
                {
                    Console.WriteLine($"- {leves.Megnevezes}");
                }
            }

            Console.ReadKey();
        }
    }
}
