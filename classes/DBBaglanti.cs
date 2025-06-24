//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;

namespace ExtremeTaleplerV2.classes
{
    public class DBBaglanti
    {
        public static string baglanti_adresi = @"Server=.;Database=ExtremeTalepler;User Id=brk;Password=brkckr20;";

        public static string baglanti_durumu;
        public static void baglanti_testi()
        {
            using (SqlConnection conn = new SqlConnection(baglanti_adresi))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    try
                    {
                        conn.Open();
                        baglanti_durumu = "Veritabanı bağlantı başarılı.";
                    }
                    catch (Exception ex)
                    {
                        baglanti_durumu = "Veritabanı bağlantı hatası..!";
                    }
                }
                else
                {
                    baglanti_durumu = "Veritabanı bağlantı başarılı.";
                }
            }
        }
    }
}

//https://www.youtube.com/watch?v=D3eVgfqL4As&list=PLi_9f1-X3vit_29s30akNn93krXT3Yalm&index=19 