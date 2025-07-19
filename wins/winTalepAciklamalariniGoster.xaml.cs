using ExtremeTaleplerV2.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.wins
{
    /// <summary>
    /// Interaction logic for winTalepAciklamalariniGoster.xaml
    /// </summary>
    public partial class winTalepAciklamalariniGoster : Window
    {
        int _talepId;
        public winTalepAciklamalariniGoster(int talepId, string tarih, string kullanici, string departman, string aciklama)
        {
            InitializeComponent();
            _talepId = talepId;
            this.Title += $" - {this._talepId}";
            tarih_.Content = tarih;
            kullanici_.Content = kullanici;
            departman_.Content = departman;
            aciklama_.Text = aciklama;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.DetaylariGetir(grdDetaylar, _talepId);
        }

        private void guncellemeYenile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void guncellemeSil_Click(object sender, RoutedEventArgs e)
        {
            if (grdDetaylar.SelectedItem is DataRowView currentSelectedRow)
            {
                if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(currentSelectedRow["Id"]);
                    DBOperations.GuncellemeSil(id);
                    DBOperations.DetaylariGetir(grdDetaylar, _talepId);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.");
            }
        }

        private void talepGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (grdDetaylar.SelectedItem is DataRowView currentSelectedRow)
            {
                if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(currentSelectedRow["Id"]);
                    string gorusmeNotu = currentSelectedRow["GorusmeNotu"].ToString();
                    string not1 = currentSelectedRow["Not1"].ToString();
                    string not2 = currentSelectedRow["Not2"].ToString();
                    string not3 = currentSelectedRow["Not3"].ToString();
                    winTalepDetayiGuncelle win = new winTalepDetayiGuncelle(id, gorusmeNotu, not1, not2, not3);
                    win.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.");
            }
        }
    }
}
