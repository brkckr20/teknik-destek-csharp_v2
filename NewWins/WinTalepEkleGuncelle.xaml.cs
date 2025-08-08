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
            }
            else
            {
                Title = "Talep Güncelle [" + _recordId + "]";
                btnYeniKayit1.Content = "Güncelle";
                btnYeniKayit1.Width += 5;
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
    }
}
