using ExtremeTaleplerV2.classes;
using System.Windows;

namespace ExtremeTaleplerV2.NewWins
{
    /// <summary>
    /// Interaction logic for WinTalepEkleGuncelle.xaml
    /// </summary>
    public partial class WinTalepEkleGuncelle : Window
    {
        bool _isNewRecord;
        int _recordId;
        string _durumu;
        public WinTalepEkleGuncelle(bool isNewRecord, int recordId)
        {
            InitializeComponent();
            _isNewRecord = isNewRecord;
            _recordId = recordId;
            StartedDatas();
        }
        void StartedDatas()
        {
            if (_isNewRecord)
            {
                brdrDurumu.Visibility = Visibility.Collapsed;
                this.MaxHeight = 355;
                this.Height = 355;
                dpTarih.SelectedDate = DateTime.Now;
            }
            else
            {
                Title = "Talep Güncelle [" + _recordId + "]";
                btnYeniKayit1.Content = "Güncelle 💢";
                btnYeniKayit1.Width += 25;
                GetRequest();
            }
        }

        void GetRequest()
        {
            var item = DBOperations.TalepGetir(this._recordId);
            dpTarih.SelectedDate = Convert.ToDateTime(item["Tarih"]);
            txtKullanici1.Text = item["Kullanici"].ToString();
            txtDepartman1.Text = item["Departman"].ToString();
            txtBaslik1.Text = item["Baslik"].ToString();
            txtAciklama1.Text = item["Aciklama"].ToString();
            SetRadioButtonValue(Convert.ToInt32(item["Durumu"]));
        }

        void SetRadioButtonValue(int radiobtnval)
        {
            switch (radiobtnval)
            {
                case 0:
                    iptal1.IsChecked = true;
                    break;
                case 1:
                    bekle1.IsChecked = true;
                    break;
                case 2:
                    tamam1.IsChecked = true;
                    break;
                case 3:
                    incele1.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void openUserList_Click(object sender, RoutedEventArgs e)
        {
            Lists.WinKullaniciListesi win = new Lists.WinKullaniciListesi();
            win.ShowDialog();
            if (win._id != 0)
            {
                txtKullanici1.Text = win._ad;
                txtDepartman1.Text = win._departman;
            }
        }

        private void btnYeniKayit1_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewRecord)
            {
                DBOperations.Ekle(txtDepartman1.Text, txtKullanici1.Text, txtBaslik1.Text, txtAciklama1.Text, "1", dpTarih.SelectedDate.Value, 0);
                MessageBox.Show("Yeni kayıt işlemi başarıyla gerçekleştirildi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                //MessageBox.Show("Yeni kayıt ekleme işlemi");
            }
            else
            {
                DBOperations.Ekle(txtDepartman1.Text, txtKullanici1.Text, txtBaslik1.Text, txtAciklama1.Text, _durumu, dpTarih.SelectedDate.Value, _recordId);
                MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                //MessageBox.Show("Kayıt güncelleme ekleme işlemi. Durumu : " + _durumu);
            }
        }

        private void tamam1_Checked(object sender, RoutedEventArgs e)
        {
            _durumu = "2";
        }

        private void bekle1_Checked(object sender, RoutedEventArgs e)
        {
            _durumu = "1";
        }

        private void incele1_Checked(object sender, RoutedEventArgs e)
        {
            _durumu = "3";
        }

        private void iptal1_Checked(object sender, RoutedEventArgs e)
        {
            _durumu = "0";
        }
    }
}
