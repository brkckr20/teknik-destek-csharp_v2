using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ExtremeTaleplerV2.classes;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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
            NewWins.WinTalepEkleGuncelle win = new NewWins.WinTalepEkleGuncelle(true,0);
            win.ShowDialog();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void talepGuncelle1_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(grdIslemler);
            NewWins.WinTalepEkleGuncelle win = new NewWins.WinTalepEkleGuncelle(false, row_id);
            win.ShowDialog();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void talepSil1_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(grdIslemler);
            DBOperations.Sil(row_id);
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void detayGoruntule_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(grdIslemler);
            NewWins.WinDetayGoruntule win = new NewWins.WinDetayGoruntule(row_id);
            win.ShowDialog();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void detayEkle_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(grdIslemler);
            NewWins.WinDetayEkle win = new NewWins.WinDetayEkle(row_id);
            win.ShowDialog();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void menuListeyiYenile_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                e.Handled = true;
                DBOperations.SetGrid(grdIslemler, filtreDurumu);
            }
        }

        private void excelAktar_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridColumn column in grdIslemler.Columns)
            {
                string header = column.Header?.ToString() ?? string.Empty;
                dt.Columns.Add(header);
            }
            foreach (var item in grdIslemler.Items)
            {
                if (item == null) continue;
                DataRow row = dt.NewRow();

                for (int i = 0; i < grdIslemler.Columns.Count; i++)
                {
                    var cellContent = grdIslemler.Columns[i].GetCellContent(item) as TextBlock;
                    if (cellContent != null)
                        row[i] = cellContent.Text;
                    else
                        row[i] = DBNull.Value;
                }

                dt.Rows.Add(row);
            }
            helpers.ExcelAktar(dt);
        }
    }
}
