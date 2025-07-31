using ExtremeTaleplerV2.classes;
using System.Windows.Controls;

namespace ExtremeTaleplerV2.UControls
{
    /// <summary>
    /// Interaction logic for UC_TalepIslemleri.xaml
    /// </summary>
    public partial class UC_TalepIslemleri : UserControl
    {
        string filtreDurumu = "-1";
        public UC_TalepIslemleri()
        {
            InitializeComponent();
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }
        void RadioButtonaGoreFiltrele()
        {
            DBOperations.SetGrid(grdIslemler, filtreDurumu);
        }

        private void chtumu_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "-1";
            RadioButtonaGoreFiltrele();
        }

        private void chtamamlan_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "2";
            RadioButtonaGoreFiltrele();
        }

        private void chbekleyen_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "1";
            RadioButtonaGoreFiltrele();
        }

        private void chiptal_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "0";
            RadioButtonaGoreFiltrele();
        }

        private void chincele_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            filtreDurumu = "3";
            RadioButtonaGoreFiltrele();
        }

        private void baslik1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // buradan devam edilecek
        }
    }
}
