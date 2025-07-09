using ExtremeTaleplerV2.classes;
using System.Data;
using System.Windows;

namespace ExtremeTaleplerV2
{
    public partial class winTalepGuncelle : Window
    {
        int KayitNo = 0;
        string durumu = "0";
        public winTalepGuncelle(int _kayitNo)
        {
            InitializeComponent();
            this.KayitNo = _kayitNo;
            lblKayitNo.Content = KayitNo.ToString();
        }

        private void btnGuncelleKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void talepGuncelleme_Loaded(object sender, RoutedEventArgs e)
        {
            DataRow selectedRow = DBOperations.TalepGetir(KayitNo);
            if (selectedRow != null)
            {
                baslik.Text = selectedRow["Baslik"].ToString();
                departman.Text = selectedRow["Departman"].ToString();
                kullanici.Text = selectedRow["Kullanici"].ToString();
                aciklama.Text = selectedRow["Aciklama"].ToString();
                tarih.SelectedDate = (DateTime)selectedRow["Tarih"];
                var durumu = selectedRow["Durumu"].ToString().Trim();
                switch (durumu)
                {
                    case "0":
                        r_iptal.IsChecked = true;
                        break;
                    case "1":
                        r_beklemede.IsChecked = true;
                        break;
                    case "2":
                        r_tamamlandi.IsChecked = true;
                        break;
                    case "3":
                        r_incelenecek.IsChecked = true;
                        break;                            
                    default:
                        break;
                }
            }
        }

        private void btnTalepGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (DBOperations.Guncelle(departman.Text, kullanici.Text, baslik.Text, aciklama.Text, durumu, tarih, this.KayitNo))
            {
                MessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleştirildi","Bilgi",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void r_iptal_Checked(object sender, RoutedEventArgs e)
        {
            durumu = "0";
        }

        private void r_beklemede_Checked(object sender, RoutedEventArgs e)
        {
            durumu = "1";
        }

        private void r_tamamlandi_Checked(object sender, RoutedEventArgs e)
        {
            durumu = "2";
        }

        private void r_incelenecek_Checked(object sender, RoutedEventArgs e)
        {
            durumu = "3";
        }
    }
}
