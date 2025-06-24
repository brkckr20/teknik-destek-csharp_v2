using ExtremeTaleplerV2.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ExtremeTaleplerV2
{
    /// <summary>
    /// Interaction logic for winTalepEkle.xaml
    /// </summary>
    public partial class winTalepEkle : Window
    {
        private int id = 0;
        public winTalepEkle()
        {
            InitializeComponent();
        }

        private void btnCloseTalepEkle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (DBOperations.Ekle(departman.Text, kullanici.Text, baslik.Text, aciklama.Text, "0", tarih.SelectedDate.Value, id))
            {
                MessageBox.Show("Kayıt işlemi başarılı bir şekilde gerçekleştirildi", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.KullanicilariGetir(kullanici);
            DBOperations.DepartmanlariGetir(departman);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
