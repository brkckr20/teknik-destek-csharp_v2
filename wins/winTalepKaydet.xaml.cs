using ExtremeTaleplerV2.classes;
using System.Windows;
using System.Windows.Input;

namespace ExtremeTaleplerV2.wins
{
    public partial class winTalepKaydet : Window
    {
        private int id = 0;
        public winTalepKaydet()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (DBOperations.Ekle(departman.Text, kullanici.Text, baslik.Text, aciklama.Text, "1", tarih.SelectedDate.Value, id))
            {
                MessageBox.Show("Kayıt işlemi başarılı bir şekilde gerçekleştirildi", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCloseTalepEkle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.KullanicilariGetir(kullanici);
            DBOperations.DepartmanlariGetir(departman);
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
