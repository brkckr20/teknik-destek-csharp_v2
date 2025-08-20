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
        public static bool SetGrid(DataGrid grd, string durumu)
        {
            sbyte i = 0;
            string query;
            SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi);
            if (durumu == "-1")
            {
                query = @"SELECT 
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
            }
            else
            {
                query = $@"SELECT 
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
	                                where Durumu = {durumu}
                                GROUP BY
                                    TS.Id, Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih
                                ORDER BY 
                                    Tarih DESC;";
            }
            SqlCommand command = new SqlCommand(query, conn);
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
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool SetGridWithFilter(DataGrid grd, string durumu)
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
	                                WHERE (@durumFiltre IS NULL OR Durumu = @durumFiltre)
                                GROUP BY
                                    TS.Id, Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih
                                ORDER BY 
                                    Tarih DESC;";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@durumFiltre", durumu);
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
            };

            if (i > 0)
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
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
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
        public static DataRow NotGetir(int id)
        {
            DataRow dataRow = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string query = "SELECT * FROM Notes WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataRow = dt.Rows[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                dataRow = null;
            }
            return dataRow;
        }
        public static DataRow TalepGetir(int id)
        {
            DataRow resultRow = null; // Başlangıçta null olarak ayarla, eğer kayıt bulunamazsa veya hata olursa null dönecek.
            try
            {
                // SQL bağlantısını 'using' bloğu içinde tanımlayarak otomatik kapanmasını sağlıyoruz.
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open(); // Veritabanı bağlantısını aç

                    string query = "SELECT * FROM TechnicalSupport WHERE Id = @Id"; // ID'ye göre tek satır sorgusu
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        // SQL Injection'ı önlemek için parametre kullanıyoruz.
                        command.Parameters.AddWithValue("@Id", id);

                        // SqlDataAdapter, sorguyu çalıştırır ve sonuçları bir DataTable'a doldurur.
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable(); // Yeni bir DataTable oluştur
                            da.Fill(dt); // Sorgu sonucunu DataTable'a doldur

                            if (dt.Rows.Count > 0)
                            {
                                // Eğer en az bir satır bulunduysa, ilk satırı al (ID benzersiz olduğu için tek satır beklenir).
                                resultRow = dt.Rows[0];
                            }
                            // else: Kayıt bulunamazsa resultRow null kalacak, bu da beklenen bir durum.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Herhangi bir veritabanı veya kod hatasında kullanıcıya bilgi ver.
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                resultRow = null; // Hata durumunda da null dönerek çağrı yapanı bilgilendir.
            }
            return resultRow; // Elde edilen DataRow'u veya null'u döndür.
        }
        public static bool NotGuncelle(string gorusmenotu, string not1, string not2, string not3, DatePicker tarih, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string uSql = "Update Notes set GorusmeNotu = @gorusmenotu, Not1 = @Not1,Not2 = @Not2,Not3 = @Not3,GorusmeTarihi = @tarih WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(uSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@gorusmenotu",gorusmenotu);
                        cmd.Parameters.AddWithValue("@Not1", not1);
                        cmd.Parameters.AddWithValue("@Not2", not2);
                        cmd.Parameters.AddWithValue("@Not3", not3);
                        cmd.Parameters.AddWithValue("@tarih", tarih.SelectedDate);
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
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static bool Guncelle(string departman, string kullanici, string baslik, string aciklama, string durum, DatePicker tarih, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string sql = @"UPDATE TechnicalSupport 
                               SET Departman = @departman,
                                   Kullanici = @kullanici, 
                                   Baslik = @baslik,
                                   Aciklama = @aciklama,
                                   Durumu = @durum,
                                   Tarih = @kayitTarihi
                               WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@departman", departman);
                        cmd.Parameters.AddWithValue("@kullanici", kullanici);
                        cmd.Parameters.AddWithValue("@baslik", baslik);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@durum", durum);
                        cmd.Parameters.AddWithValue("@kayitTarihi", tarih.SelectedDate);

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
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static bool Sil(int id, string tablename = "TechnicalSupport", string wheretype = "Id")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string sql = $@"DELETE FROM {tablename} WHERE {wheretype} = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }
                        if (MessageBox.Show("Kayıt silinecek. Emin misiniz?\nBu işlem geri alınamaz!", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static bool AciklamaEkle(DateTime tarih, TextBox gorusmenotu, TextBox not1, TextBox not2, TextBox not3, int talepId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string sql = $@"insert into Notes (RefNo,GorusmeNotu,Not1,Not2,Not3,GorusmeTarihi)
                                                values (@RefNo,@GorusmeNotu,@Not1,@Not2,@Not3,@GorusmeTarihi)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RefNo", talepId);
                        cmd.Parameters.AddWithValue("@GorusmeNotu", gorusmenotu.Text);
                        cmd.Parameters.AddWithValue("@Not1", not1.Text);
                        cmd.Parameters.AddWithValue("@Not2", not2.Text);
                        cmd.Parameters.AddWithValue("@Not3", not3.Text);
                        cmd.Parameters.AddWithValue("@GorusmeTarihi", tarih);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static bool DetaylariGetir(DataGrid grd, int refno)
        {
            sbyte i = 0;
            SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi);
            string query = @"select * from Notes where RefNo = @RefNo";
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@RefNo", refno);
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
            };

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool GuncellemeSil(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    conn.Open();
                    string sql = @"DELETE FROM Notes WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }
                        if (MessageBox.Show("Kayıt silinecek. Emin misiniz?\nBu işlem geri alınamaz!", "Uyarı", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public static void AddOrUpdateDepartment(int id, string val)
        {
            if (val == string.Empty)
            {
                MessageBox.Show("Departman adı boş geçilemez!", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                    {
                        conn.Open();
                        string sql;
                        if (id == 0)
                        {
                            sql = $"insert into Departments (DepartmanAdi) values (@DepartmanAdi)";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@DepartmanAdi", val);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt işlemi başarılı!", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            sql = $"update Departments set DepartmanAdi = @DepartmanAdi where id = @id";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@DepartmanAdi", val);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt güncelleme işlemi başarılı!", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata : " + ex.Message);
                }
            }
        }
        public static void DepartmanlariGrideYansit(DataGrid dg)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    connection.Open();
                    string sql = "select id,DepartmanAdi from Departments";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dg.ItemsSource = dt.DefaultView;
                    if (dg.Columns.Count > 0)
                    {
                        dg.Columns[0].Visibility = Visibility.Hidden;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        public static void AddOrUpdateUser(int id, string val, string user)
        {
            if (user == string.Empty || val == string.Empty)
            {
                MessageBox.Show("Kullanıcı ve departman adı boş geçilemez!", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DBBaglanti.baglanti_adresi))
                    {
                        conn.Open();
                        string sql;
                        if (id == 0)
                        {
                            sql = $"insert into Users (adSoyad,departman) values (@Kullanici,@DepartmanAdi)";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Kullanici", user);
                                cmd.Parameters.AddWithValue("@DepartmanAdi", val);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt işlemi başarılı!", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            sql = $"update Users set departman = @departman,adSoyad = @Kullanici where id = @id";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@departman", val);
                                cmd.Parameters.AddWithValue("@Kullanici", user);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt güncelleme işlemi başarılı!", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata : " + ex.Message);
                }
            }
        }
        public static void KullanicilariGrideYansit(DataGrid dg)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBBaglanti.baglanti_adresi))
                {
                    connection.Open();
                    string sql = "select id,adSoyad,departman from Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dg.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
