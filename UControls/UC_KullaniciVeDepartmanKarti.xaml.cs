using ExtremeTaleplerV2.classes;
using System.Windows;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.UControls
{
    public partial class UC_KullaniciVeDepartmanKarti : UserControl
    {
        Utils.Enums.CardType _cardType;
        public UC_KullaniciVeDepartmanKarti(Utils.Enums.CardType cardType)
        {
            InitializeComponent();
            _cardType = cardType;
            StartedDatas();
        }
        int Id = 0;
        private void btnYeni1_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }
        void StartedDatas()
        {
            if (_cardType == Utils.Enums.CardType.Departman)
            {
                pnlKullanici.Visibility = Visibility.Hidden;
                pnlKullanici.Visibility = Visibility.Collapsed;
                pnlDepartman.Width = 300;
            }
            else
            {
                pnlDepartman.Margin = new Thickness(0, 2, 0, 0);
            }
        }
        void Temizle()
        {
            txtAdi1.Text = string.Empty;
            txtKullaniciAdi1.Text = string.Empty;
            this.Id = 0;
        }

        private void btnKaydet1_Click(object sender, RoutedEventArgs e)
        {
            if (_cardType == Utils.Enums.CardType.Departman)
            {
                DBOperations.AddOrUpdateDepartment(Id, txtAdi1.Text);
            }
            else
            {
                DBOperations.AddOrUpdateUser(Id, txtAdi1.Text, txtKullaniciAdi1.Text);
            }
            //Temizle();
        }

        private void btnListe1_Click(object sender, RoutedEventArgs e)
        {
            if (_cardType == Utils.Enums.CardType.Departman)
            {
                NewWins.Lists.WinDepartmanListesi win = new NewWins.Lists.WinDepartmanListesi();
                win.ShowDialog();
                if (win._id != null)
                {
                    Id = win._id;
                    txtAdi1.Text = win._ad;
                }
            }
            else
            {
                NewWins.Lists.WinKullaniciListesi win = new NewWins.Lists.WinKullaniciListesi();
                win.ShowDialog();
                if (win._id != null)
                {
                    Id = win._id;
                    txtAdi1.Text = win._departman;
                    txtKullaniciAdi1.Text = win._ad;
                }
            }
        }

        private void btnSil1_Click(object sender, RoutedEventArgs e)
        {
            if (_cardType == Utils.Enums.CardType.Departman)
            {
                DBOperations.Sil(this.Id, "Departments", "id");
            }
            else
            {
                DBOperations.Sil(this.Id, "Users", "id");
            }
            Temizle();
        }

        private void openDepartments_Click(object sender, RoutedEventArgs e)
        {
            NewWins.Lists.WinDepartmanListesi liste = new NewWins.Lists.WinDepartmanListesi();
            liste.ShowDialog();
            txtAdi1.Text = liste._ad;
        }
    }
}
