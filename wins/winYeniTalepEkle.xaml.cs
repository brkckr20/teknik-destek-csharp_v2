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

namespace ExtremeTaleplerV2.wins
{
    /// <summary>
    /// Interaction logic for winYeniTalepEkle.xaml
    /// </summary>
    public partial class winYeniTalepEkle : Window
    {
        public winYeniTalepEkle()
        {
            InitializeComponent();
            dpTarih.SelectedDate = DateTime.Now;
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (DBOperations.Ekle(txtDepartman.Text, txtKullanici.Text, txtBaslik.Text, txtAciklama.Text, "1", Convert.ToDateTime(dpTarih.SelectedDate), 0))
            {
                MessageBox.Show("Kayıt işlemi başarıyla gerçekleştirildi", "Bilgilendir", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
