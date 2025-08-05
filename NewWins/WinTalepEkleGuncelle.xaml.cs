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
    /// Interaction logic for WinTalepEkleGuncelle.xaml
    /// </summary>
    public partial class WinTalepEkleGuncelle : Window
    {
        bool _isNewRecord;
        public WinTalepEkleGuncelle(bool isNewRecord)
        {
            InitializeComponent();
            _isNewRecord = isNewRecord;
            StartedDatas();
        }
        void StartedDatas()
        {
            if (_isNewRecord)
            {
                brdrDurumu.Visibility = Visibility.Collapsed;
                this.MaxHeight = 355;
                this.Height = 355;
                /*
                  MaxHeight="422" Height="422"
                 */
            }
            else
            {
                Title = "Talep Güncelle";
                btnYeniKayit1.Content = "Güncelle";
                btnYeniKayit1.Width += 5;
            }
        }
    }
}
