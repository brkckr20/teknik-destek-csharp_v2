using ClosedXML.Excel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ExtremeTaleplerV2.classes
{
    public class Helpers
    {
        public void SearchWithTextbox(string filtreKriteri, string aramaTipi, DataTable tb, DataGrid dg, bool isTextBoxSearch = false)
        {
            if (tb == null)
            {
                System.Windows.MessageBox.Show("Filtreleme yapılamadı: Ana veri tablosu mevcut değil.");
                return;
            }

            DataView dataView = new DataView(tb);
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
            dg.ItemsSource = dataView;
        }
        public int GetRowId(DataGrid dataGrid)
        {
            if (dataGrid.SelectedItem is DataRowView currentSelectedRow)
            {
                if (currentSelectedRow.Row.Table.Columns.Contains("Id"))
                {
                    int id = Convert.ToInt32(currentSelectedRow["Id"]);
                    return id;
                }
                return 0;
            }
            else
            {
                System.Windows.MessageBox.Show("Lütfen bir satır seçtiğinizden emin olun.");
                return 0;
            }
        }
        public void ExcelAktar(DataTable dataTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyaları|.xlsx";
            saveFileDialog.Title = "Excel olarak kaydet";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    DataTable dt = dataTable;
                    var worksheet = workbook.AddWorksheet("Sayfa1");
                    worksheet.Cell(1, 1).InsertTable(dt);
                    workbook.SaveAs(filePath);
                }
                //MessageBox.Show("Veriler başarıyla dışa aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Windows.MessageBox.Show("Veriler başarıyla dışa aktarıldı!", "Başarılı");
            }
        }
    }
}
