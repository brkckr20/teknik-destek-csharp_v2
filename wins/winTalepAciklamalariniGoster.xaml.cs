using ExtremeTaleplerV2.classes;
using System.Windows;

namespace ExtremeTaleplerV2.wins
{
    /// <summary>
    /// Interaction logic for winTalepAciklamalariniGoster.xaml
    /// </summary>
    public partial class winTalepAciklamalariniGoster : Window
    {
        int _talepId;
        public winTalepAciklamalariniGoster(int talepId, string tarih,string kullanici,string departman, string aciklama)
        {
            InitializeComponent();
            _talepId = talepId;
            this.Title += $" - {this._talepId}";
            tarih_.Content = tarih;
            kullanici_.Content = kullanici;
            departman_.Content = departman;
            aciklama_.Text = aciklama;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.DetaylariGetir(grdDetaylar,_talepId);
        }
    }
}
