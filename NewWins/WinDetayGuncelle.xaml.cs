using ExtremeTaleplerV2.classes;
using System.Windows;

namespace ExtremeTaleplerV2.NewWins
{
    /// <summary>
    /// Interaction logic for WinDetayGuncelle.xaml
    /// </summary>
    public partial class WinDetayGuncelle : Window
    {
        int id;
        public WinDetayGuncelle(int _id)
        {
            InitializeComponent();
            this.id = _id;
            var item = DBOperations.NotGetir(this.id);
            dpNotTarihi.SelectedDate = Convert.ToDateTime(item["GorusmeTarihi"]);
            txtGorusmeNotu.Text = item["GorusmeNotu"].ToString();
            txtNot1.Text = item["Not1"].ToString();
            txtNot2.Text = item["Not2"].ToString();
            txtNot3.Text = item["Not3"].ToString();
        }
        private void btnDetayNotEkle_Click(object sender, RoutedEventArgs e)
        {
            if (DBOperations.NotGuncelle(txtGorusmeNotu.Text,txtNot1.Text,txtNot2.Text,txtNot3.Text,dpNotTarihi,this.id))
            {
                MessageBox.Show("Not / Detay güncelleme işlemi başarılı","Bilgilendirme",MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
