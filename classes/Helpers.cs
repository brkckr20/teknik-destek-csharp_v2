using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                MessageBox.Show("Filtreleme yapılamadı: Ana veri tablosu mevcut değil.");
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
    }
}
