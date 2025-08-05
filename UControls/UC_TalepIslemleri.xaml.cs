using ExtremeTaleplerV2.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.UControls
{
    /// <summary>
    /// Interaction logic for UC_TalepIslemleri.xaml
    /// </summary>
    public partial class UC_TalepIslemleri : UserControl
    {
        string filtreDurumu = "-1";
        Helpers helpers = new Helpers();
        private DataTable tumIslemlerDataTable;
        public UC_TalepIslemleri()
        {
            InitializeComponent();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
            if (grdIslemler.ItemsSource is DataView dataView)
            {
                tumIslemlerDataTable = dataView.Table;
            }
            else
            {
                // Bu senaryoda buraya düşmemelisiniz, ancak hata ayıklama için bırakmak iyi bir pratik.
                MessageBox.Show("DBOperations.SetGrid'in DataGrid'i beklenen DataView ile doldurmadığını anladım. Hata! Lütfen kontrol edin.");
                tumIslemlerDataTable = new DataTable(); // Boş bir DataTable ile başlat ki null olmasın
            }

            if (tumIslemlerDataTable == null || tumIslemlerDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Başlangıçta ana veri tablosu yüklenemedi veya boş. Filtreleme yapılamayabilir.");
            }
        }
        void RadioButtonaGoreFiltrele()
        {
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void chtumu_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "-1";
            RadioButtonaGoreFiltrele();
        }

        private void chtamamlan_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "2";
            RadioButtonaGoreFiltrele();
        }

        private void chbekleyen_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "1";
            RadioButtonaGoreFiltrele();
        }

        private void chiptal_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "0";
            RadioButtonaGoreFiltrele();
        }

        private void chincele_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "3";
            RadioButtonaGoreFiltrele();
        }
        void SetTableFilterMethod(object sender, string str)
        {
            TextBox? textBox = sender as TextBox;
            string aramaMetni = textBox.Text;
            helpers.SearchWithTextbox(aramaMetni, str, tumIslemlerDataTable, grdIslemler, true);
        }
        private void baslik1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTableFilterMethod(sender, "Baslik");
        }

        private void mailAciklama_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTableFilterMethod(sender, "Kullanici");
        }

        private void yeniTalep1_Click(object sender, RoutedEventArgs e)
        {
            NewWins.WinTalepEkleGuncelle win = new NewWins.WinTalepEkleGuncelle(true);
            win.ShowDialog();
        }
    }
}
