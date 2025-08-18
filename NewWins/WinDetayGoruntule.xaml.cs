using ExtremeTaleplerV2.classes;
using System;
using System.Collections.Generic;
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

namespace ExtremeTaleplerV2.NewWins
{
    public partial class WinDetayGoruntule : Window
    {
        int id = 0;
        Helpers helpers = new Helpers();
        public WinDetayGoruntule(int _id)
        {
            InitializeComponent();
            this.id = _id;
            BilgileriYansit();
        }
        void BilgileriYansit()
        {
            var item = DBOperations.TalepGetir(this.id);
            lbTarih1.Content = item["Tarih"].ToString().Substring(0,10);
            lbKullanici.Content = item["Kullanici"].ToString();
            lbDepartman.Content = item["Departman"].ToString();
            tbAciklama.Text = item["Aciklama"].ToString();
            DBOperations.DetaylariGetir(dgDetayListesi, id);
        }

        private void cmKaydiSil_Click(object sender, RoutedEventArgs e)
        {
            int row_id = helpers.GetRowId(dgDetayListesi);
            //DBOperations.GuncellemeSil(row_id);
        }
    }
}
