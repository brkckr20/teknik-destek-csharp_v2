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
    /// <summary>
    /// Interaction logic for WinDetayEkle.xaml
    /// </summary>
    public partial class WinDetayEkle : Window
    {
        int id;
        public WinDetayEkle(int _id)
        {
            InitializeComponent();
            this.id = _id;
            Title += " (" + this.id + ")";
        }

        private void btnDetayNotEkle_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectDate = dpNotTarihi.SelectedDate.Value;
            if (DBOperations.AciklamaEkle(selectDate, txtGorusmeNotu, txtNot1, txtNot2, txtNot3, id))
            {
                MessageBox.Show("Not ekleme işlemi başarıyla gerçekleştirildi","Bilgilendirme",MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
            
        }
    }
}
