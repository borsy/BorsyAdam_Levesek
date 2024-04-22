using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Levesek_BA20240417
{
    class Adatbazis_kapcsolat
    {
        MySqlCommand sql_parancsok = null;
        MySqlConnection adatbazis_kapcsolat = null;

        public Adatbazis_kapcsolat()
        {
            MySqlConnectionStringBuilder mscsb = new MySqlConnectionStringBuilder();
            mscsb.Server = "localhost";
            mscsb.UserID = "root";
            mscsb.Password = "";
            mscsb.Database = "levesek";
            mscsb.CharacterSet = "utf8";

            adatbazis_kapcsolat = new MySqlConnection(mscsb.ConnectionString);
            sql_parancsok = adatbazis_kapcsolat.CreateCommand();
        }

        public List<Leves> getLevesek()
        {
            List<Leves> levesek = new List<Leves>();
            sql_parancsok.CommandText = "select * from levesek";
            adatbazis_kapcsolat.Open();
            MySqlDataReader adatbazis_olvasas = sql_parancsok.ExecuteReader();
            while (adatbazis_olvasas.Read())
            {
                levesek.Add(new Leves()
                {
                   Megnevezes = adatbazis_olvasas.GetString("megnevezes"),
                   Kaloria = adatbazis_olvasas.GetInt32("kaloria"),
                   Feherje = adatbazis_olvasas.GetDouble("feherje"),
                   Zsir = adatbazis_olvasas.GetDouble("zsir"),
                   Szenhidrat = adatbazis_olvasas.GetDouble("szenhidrat"),
                   Hamu = adatbazis_olvasas.GetDouble("hamu"),
                   Rost = adatbazis_olvasas.GetDouble("rost")
                });
            }

            adatbazis_olvasas.Close();
            adatbazis_kapcsolat.Close();

            return levesek;
        }
    }
}