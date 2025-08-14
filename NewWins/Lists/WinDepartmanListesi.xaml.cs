using ExtremeTaleplerV2.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ExtremeTaleplerV2.NewWins.Lists.WinDepartmanListesi;

namespace ExtremeTaleplerV2.NewWins.Lists
{
    /// <summary>
    /// Interaction logic for WinDepartmanListesi.xaml
    /// </summary>
    public partial class WinDepartmanListesi : Window
    {
        public WinDepartmanListesi()
        {
            InitializeComponent();
            DBOperations.DepartmanlariGrideYansit(dgDepartman);
        }
        public int _id;
        public string _ad;

        private void dgDepartman_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgDepartman.SelectedItem != null)
            {
                var row = dgDepartman.SelectedItem as DataRowView;
                if (row != null)
                {
                    _id = Convert.ToInt32(row["id"]);
                    _ad = row["DepartmanAdi"].ToString();
                    Close();
                }
            }
        }
    }
}
