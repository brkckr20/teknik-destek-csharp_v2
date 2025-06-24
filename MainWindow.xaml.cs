using ExtremeTaleplerV2.classes;
using ExtremeTaleplerV2.UControls;
using System.Windows;
using System.Windows.Input;

namespace ExtremeTaleplerV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnKucult_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnBuyult_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            
        }
        private void btnYeni_Click(object sender, RoutedEventArgs e)
        {
            winTalepEkle win = new winTalepEkle();
            win.ShowDialog();
           // UC_getir.UC_Ekle(Content_icerik,new uTalepListesi());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DBBaglanti.baglanti_testi();
            //MessageBox.Show(DBBaglanti.baglanti_durumu);
            UC_getir.UC_Ekle(Content_icerik, new uTalepListesi());
        }
    }
}