using ExtremeTaleplerV2.classes;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ExtremeTaleplerV2.UControls
{
    /// <summary>
    /// Interaction logic for uTalepListesi.xaml
    /// </summary>
    public partial class uTalepListesi : UserControl
    {
        public uTalepListesi()
        {
            InitializeComponent();
        }
        //public void FilterByBaslik(string filterText)
        //{
        //    if (talepListesiDataGrid?.ItemsSource == null) return;

        //    ICollectionView view = CollectionViewSource.GetDefaultView(talepListesiDataGrid.ItemsSource);
        //    view.Filter = item =>
        //    {
        //        if (string.IsNullOrWhiteSpace(filterText))
        //            return true;

        //        dynamic dynamicItem = item;
        //        string baslik = dynamicItem.Başlık?.ToString() ?? "";
        //        return baslik.Contains(filterText, StringComparison.OrdinalIgnoreCase);
        //    };
        //    view.Refresh(); // Filtreyi güncelle
        //}
        //public DataGrid talepListesiDataGrid //başka bir ekrandan erişmek için
        //{
        //  //  get { return dtgTalepListei; }
        //}

        public void SetGridNoFilter()
        {
           // DBOperations.SetGrid(dtgTalepListei);
        }
        public void SetGridWithFilter(string filitre)
        {
          //  DBOperations.SetGridWithFilter(dtgTalepListei,filitre);
        }
        DataTable dataTable;
        public void Filtreleme(string FieldName, string txt)
        {
            //if (dataTable == null || talepListesiDataGrid == null)
            //    return;

            //try
            //{
            //    if (string.IsNullOrEmpty(txt))
            //    {
            //        talepListesiDataGrid.ItemsSource = dataTable.DefaultView;
            //    }
            //    else
            //    {
            //        // Case-insensitive arama ve null kontrolü
            //        var filteredRows = dataTable.AsEnumerable()
            //            .Where(row => !row.IsNull(FieldName) &&
            //                         row.Field<string>(FieldName).ToLower()
            //                         .Contains(txt.ToLower()))
            //            .ToList();

            //        DataTable filteredDataTable;

            //        if (filteredRows.Any())
            //        {
            //            filteredDataTable = filteredRows.CopyToDataTable();
            //        }
            //        else
            //        {
            //            filteredDataTable = dataTable.Clone();
            //            // Boş bir DataTable döndür
            //        }

            //        talepListesiDataGrid.ItemsSource = filteredDataTable.DefaultView;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Hata yönetimi
            //    MessageBox.Show($"Filtreleme hatası: {ex.Message}");
            //}
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //DBOperations.SetGrid(dtgTalepListei);
        }


        private void cmUpdate_Click(object sender, RoutedEventArgs e)
        {
            //if (dtgTalepListei.SelectedItem is System.Data.DataRowView selectedRow)
            //{
            //    if (selectedRow.Row.Table.Columns.Contains("Id"))
            //    {
            //        int talepId = Convert.ToInt32(selectedRow["Id"]);
            //        winTalepGuncelle win = new winTalepGuncelle(talepId);
            //        win.ShowDialog();
            //        DBOperations.SetGrid(dtgTalepListei);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Seçilen satırda 'Id' sütunu bulunamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen güncellenecek bir talep seçin.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void cmRefreshList_Click(object sender, RoutedEventArgs e)
        {
            //DBOperations.SetGrid(dtgTalepListei);
        }

        private void cmDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (dtgTalepListei.SelectedItem is System.Data.DataRowView selectedRow)
            //{
            //    if (selectedRow.Row.Table.Columns.Contains("Id"))
            //    {
            //        int talepId = Convert.ToInt32(selectedRow["Id"]);
            //        DBOperations.Sil(talepId);
            //        DBOperations.SetGrid(dtgTalepListei);
            //    }
            //}
        }
    }
}
