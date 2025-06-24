using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.classes
{
    public class DBOperations
    {
        //datagride veri doldurma işlemi
        public static bool SetGrid(DataGrid grd)
        {
            sbyte i = 0;
            SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi);
            string query = @"SELECT 
                                    TS.Id,
                                    Departman, 
                                    Kullanici, 
                                    Baslik, 
                                    Aciklama, 
                                    CASE Durumu 
                                        WHEN '0' THEN 'İptal'
                                        WHEN '1' THEN 'Beklemede'
                                        WHEN '2' THEN 'Tamamlandı'
                                        WHEN '3' THEN 'İncelenecek'
                                        ELSE 'Belirsiz'
                                    END as Durumu, 
                                    FORMAT(CAST(Tarih AS DATETIME), 'dd.MM.yyyy', 'tr-TR') as Tarih,
                                    CASE 
                                        WHEN MAX(N.RefNo) IS NOT NULL THEN 'Güncelleme var' 
                                        ELSE '' 
                                    END AS Güncelleme
                                FROM 
                                    TechnicalSupport TS
                                LEFT JOIN 
                                    Notes N ON TS.Id = N.RefNo
	                                --WHERE (@durumFiltre IS NULL OR Durumu = @durumFiltre)
                                GROUP BY
                                    TS.Id, Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih
                                ORDER BY 
                                    Tarih DESC;";
            SqlCommand command = new SqlCommand(query,conn);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
            finally
            {
                conn.Dispose();
            }
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Ekle(string departman, string kullanici, string baslik, string aciklama, string durum, DateTime tarih, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string sql;

                    if (id == 0)
                    {
                        sql = @"INSERT INTO TechnicalSupport (Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih,Durum) 
                               VALUES (@departman, @kullanici, @baslik, @aciklama, @durum, @kayitTarihi,0)";
                    }
                    else
                    {
                        sql = @"UPDATE TechnicalSupport 
                               SET Departman = @departman,
                                   Kullanici = @kullanici, 
                                   Baslik = @baslik,
                                   Aciklama = @aciklama,
                                   Durumu = @durum,
                                   Tarih = @kayitTarihi
                               WHERE Id = @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@departman", departman);
                        cmd.Parameters.AddWithValue("@kullanici", kullanici);
                        cmd.Parameters.AddWithValue("@baslik", baslik);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@durum", durum);
                        cmd.Parameters.AddWithValue("@kayitTarihi", tarih);

                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static void KullanicilariGetir(ComboBox kullanici)
        {
            using (SqlConnection con = new SqlConnection(DBBaglanti.baglanti_adresi))
            {
                SqlDataAdapter da = new SqlDataAdapter("select id,adSoyad from Users", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                kullanici.ItemsSource = dt.DefaultView;
                kullanici.DisplayMemberPath = "adSoyad";
                kullanici.SelectedValuePath = "adSoyad";
            }
        }
        public static void DepartmanlariGetir(ComboBox kullanici)
        {
            using (SqlConnection con = new SqlConnection(DBBaglanti.baglanti_adresi))
            {
                SqlDataAdapter da = new SqlDataAdapter("select id,DepartmanAdi from Departments", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                kullanici.ItemsSource = dt.DefaultView;
                kullanici.DisplayMemberPath = "DepartmanAdi";
                kullanici.SelectedValuePath = "DepartmanAdi";
            }
        }
    }
}
