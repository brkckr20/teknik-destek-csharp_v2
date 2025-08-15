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

namespace ExtremeTaleplerV2.NewWins.Lists
{
    /// <summary>
    /// Interaction logic for WinKullaniciListesi.xaml
    /// </summary>
    public partial class WinKullaniciListesi : Window
    {
        public WinKullaniciListesi()
        {
            InitializeComponent();
            DBOperations.KullanicilariGrideYansit(dgKullanici);
        }
        public int _id;
        public string _ad,_departman;
        private void dgKullanici_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgKullanici.SelectedItem != null)
            {
                var row = dgKullanici.SelectedItem as DataRowView;
                if (row != null)
                {
                    _id = Convert.ToInt32(row["id"]);
                    _ad = row["adSoyad"].ToString();
                    _departman = row["departman"].ToString();
                    Close();
                }
            }
        }
    }
}
