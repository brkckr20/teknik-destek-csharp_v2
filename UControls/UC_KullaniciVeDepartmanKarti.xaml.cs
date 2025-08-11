using ExtremeTaleplerV2.classes;
using System.Windows;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.UControls
{
    public partial class UC_KullaniciVeDepartmanKarti : UserControl
    {
        public UC_KullaniciVeDepartmanKarti()
        {
            InitializeComponent();
        }
        int Id = 0;
        private void btnYeni1_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }
        void Temizle()
        {
            txtAdi1.Text = string.Empty;
        }

        private void btnKaydet1_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.AddOrUpdateDepartment(Id, txtAdi1.Text);
        }

        private void btnListe1_Click(object sender, RoutedEventArgs e)
        {
            NewWins.Lists.WinDepartmanListesi win = new NewWins.Lists.WinDepartmanListesi();
            win.ShowDialog();
        }
    }
}
