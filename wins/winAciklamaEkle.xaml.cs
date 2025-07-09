using ExtremeTaleplerV2.classes;
using System.Windows;

namespace ExtremeTaleplerV2.wins
{
    /// <summary>
    /// Interaction logic for winAciklamaEkle.xaml
    /// </summary>
    public partial class winAciklamaEkle : Window
    {
        int _talep_id;
        public winAciklamaEkle(int talep_id)
        {
            InitializeComponent();
            this._talep_id = talep_id;
            this.Title += $" - {this._talep_id}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpGorusmeTarihi.SelectedDate = DateTime.Now;
        }

        private void btnAciklamaEkle_Click(object sender, RoutedEventArgs e)
        {
            if (dpGorusmeTarihi.SelectedDate.HasValue)
            {
                DateTime selectedDate = dpGorusmeTarihi.SelectedDate.Value; // Nullable'dan DateTime'a dönüştür
                DBOperations.AciklamaEkle(selectedDate, txtGorusmeNotu, txtNot1, txtNot2, txtNot3, _talep_id);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tarih seçin.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
