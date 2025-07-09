using ExtremeTaleplerV2.classes;
using ExtremeTaleplerV2.UControls;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExtremeTaleplerV2
{

    public partial class MainWindow : Window
    {
        uTalepListesi uTalepListesiInstance;
        private DataTable tumIslemlerDataTable;
        public MainWindow()
        {
            InitializeComponent();

            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            DBOperations.SetGrid(grdIslemler, "-1");
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
        private void FiltreIslemleri_Click(object sender, RoutedEventArgs e)
        {
            MenuItem clickedMenuItem = sender as MenuItem;
            if (clickedMenuItem != null)
            {
                string filtreKriteri = clickedMenuItem.Tag as string;
                string _filtre;
                switch (filtreKriteri)
                {
                    case "İptal Edilenler":
                        DBOperations.SetGrid(grdIslemler, "0");
                        break;
                    case "Bekleyenler":
                        DBOperations.SetGrid(grdIslemler, "1");
                        break;
                    case "Tamamlananlar":
                        DBOperations.SetGrid(grdIslemler, "2");
                        break;
                    case "İncelenecek":
                        DBOperations.SetGrid(grdIslemler, "3");
                        break;
                    default:
                        DBOperations.SetGrid(grdIslemler, "-1");
                        break;
                }
                //MessageBox.Show(filtreKriteri);
            }
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnKucult_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnBuyult_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {

        }
        private void btnYeni_Click(object sender, RoutedEventArgs e)
        {
            wins.winTalepKaydet win = new wins.winTalepKaydet();
            win.ShowDialog();
            // UC_getir.UC_Ekle(Content_icerik,new uTalepListesi());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.SetGrid(grdIslemler, "-1");
        }

        private void rbTum_Checked(object sender, RoutedEventArgs e)
        {
            if (uTalepListesiInstance != null)
            {
                uTalepListesiInstance.SetGridNoFilter();
            }
        }
        void filitreli(string ft)
        {
            if (uTalepListesiInstance != null)
            {
                uTalepListesiInstance.SetGridWithFilter(ft);
            }
        }
        private void rbTamamlandi_Checked(object sender, RoutedEventArgs e)
        {
            filitreli("2");
        }

        private void rbBekleyen_Checked(object sender, RoutedEventArgs e)
        {
            filitreli("1");
        }

        private void rbIptalEdilen_Checked(object sender, RoutedEventArgs e)
        {
            filitreli("0");
        }

        private void rbIncelenecek_Checked(object sender, RoutedEventArgs e)
        {
            filitreli("3");
        }


        private void closeApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void YukleVeFiltreleIslemleri(string filtreKriteri, string aramaTipi, bool isTextBoxSearch = false)
        {
            if (tumIslemlerDataTable == null)
            {
                // Eğer tumIslemlerDataTable hala null ise, verinin yüklenemediğini göster.
                MessageBox.Show("Filtreleme yapılamadı: Ana veri tablosu mevcut değil.");
                return;
            }

            DataView dataView = new DataView(tumIslemlerDataTable);
            string filterExpression = string.Empty;

            if (isTextBoxSearch)
            {

                if (!string.IsNullOrEmpty(filtreKriteri))
                {
                    filterExpression = //$"Kullanici LIKE '%{filtreKriteri}%' OR " +
                                       // $"Departman LIKE '%{filtreKriteri}%' OR " +
                                       $"{aramaTipi} LIKE '%{filtreKriteri}%'"; //+
                                                                                // $"Aciklama LIKE '%{filtreKriteri}%'";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(filtreKriteri) || filtreKriteri == "Tümü")
                {
                    filterExpression = string.Empty;
                }
                else
                {
                    filterExpression = $"Durumu = '{filtreKriteri}'";
                }
            }

            dataView.RowFilter = filterExpression;
            grdIslemler.ItemsSource = dataView;
        }

        private void baslik_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            string aramaMetni = textBox.Text;
            // TextBox'tan geldiği için isTextBoxSearch = true
            YukleVeFiltreleIslemleri(aramaMetni, "Baslik", true);
        }

        private void aciklama_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            string aramaMetni = textBox.Text;
            YukleVeFiltreleIslemleri(aramaMetni, "Aciklama", true);
        }

        private void yeniTalep_Click(object sender, RoutedEventArgs e)
        {
            wins.winYeniTalepEkle win = new wins.winYeniTalepEkle();
            win.ShowDialog();
            DBOperations.SetGrid(grdIslemler, "-1");
        }

        private void talepGuncelle_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedRowId_Click(sender, e);
        }
        private void GetSelectedRowId_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null && menuItem.CommandParameter is DataRowView selectedRow)
            {
                if (selectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(selectedRow["Id"]);
                    wins.winTalepGuncelle win = new wins.winTalepGuncelle(id);
                    win.ShowDialog();
                    DBOperations.SetGrid(grdIslemler, "-1");
                }
                else
                {
                    MessageBox.Show("Id sütunu bulunamadı.");
                }
            }
            else
            {
                if (grdIslemler.SelectedItem is DataRowView currentSelectedRow)
                {
                    if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                    {
                        int id = Convert.ToInt32(currentSelectedRow["Id"]);
                        MessageBox.Show($"Alternatif yolla alınan ID: {id}");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.");
                }
            }
        }

        private void talepSil_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null && menuItem.CommandParameter is DataRowView selectedRow)
            {
                if (selectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(selectedRow["Id"]);
                    DBOperations.Sil(id);
                    DBOperations.SetGrid(grdIslemler, "-1");
                }
                else
                {
                    MessageBox.Show("Id sütunu bulunamadı.");
                }
            }
            else
            {
                if (grdIslemler.SelectedItem is DataRowView currentSelectedRow)
                {
                    if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                    {
                        int id = Convert.ToInt32(currentSelectedRow["Id"]);
                        DBOperations.Sil(id);
                        DBOperations.SetGrid(grdIslemler, "-1");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.");
                }
            }
        }

        private void listeyiYenile_Click(object sender, RoutedEventArgs e)
        {
            DBOperations.SetGrid(grdIslemler, "-1");
        }

        private void BtnTalebeYeniAciklamaEkle_Click(object sender, RoutedEventArgs e)
        {
            if (grdIslemler.SelectedItem is DataRowView currentSelectedRow)
            {
                if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(currentSelectedRow["Id"]);
                    wins.winAciklamaEkle win = new wins.winAciklamaEkle(id);
                    win.ShowDialog();
                }
            }
        }

        private void BtnTalepAciklamalariniGoster_Click(object sender, RoutedEventArgs e)
        {
            if (grdIslemler.SelectedItem is DataRowView currentSelectedRow)
            {
                if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(currentSelectedRow["Id"]);
                    string tarih = currentSelectedRow["Tarih"].ToString();
                    string kullanici = currentSelectedRow["Kullanici"].ToString();
                    string departman = currentSelectedRow["Departman"].ToString();
                    string aciklama = currentSelectedRow["Aciklama"].ToString();
                    wins.winTalepAciklamalariniGoster win = new wins.winTalepAciklamalariniGoster(id, tarih, kullanici, departman, aciklama);
                    win.ShowDialog();
                }
            }
        }
    }
}