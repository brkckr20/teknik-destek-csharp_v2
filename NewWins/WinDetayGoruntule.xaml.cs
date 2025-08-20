using ExtremeTaleplerV2.classes;
using System.Windows;

namespace ExtremeTaleplerV2.NewWins
{
    public partial class WinDetayGoruntule : Window
    {
        int id = 0;
        Helpers helpers = new Helpers();
        public WinDetayGoruntule(int _id)
        {
            InitializeComponent();
            this.id = _id;
            BilgileriYansit();
        }
        void BilgileriYansit()
        {
            var item = DBOperations.TalepGetir(this.id);
            lbTarih1.Content = item["Tarih"].ToString().Substring(0,10);
            lbKullanici.Content = item["Kullanici"].ToString();
            lbDepartman.Content = item["Departman"].ToString();
            tbAciklama.Text = item["Aciklama"].ToString();
            DBOperations.DetaylariGetir(dgDetayListesi, id);
        }

        private void cmKaydiSil_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(dgDetayListesi);
            DBOperations.GuncellemeSil(row_id);
            DBOperations.DetaylariGetir(dgDetayListesi, id);
        }

        private void cmKaydiGuncelle_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(dgDetayListesi);
            WinDetayGuncelle win = new WinDetayGuncelle(row_id);
            win.ShowDialog();
            DBOperations.DetaylariGetir(dgDetayListesi, id);
        }

        private void cmYenile_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.DetaylariGetir(dgDetayListesi, id);
        }
    }
}
