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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtremeTaleplerV2.UControls
{
    /// <summary>
    /// Interaction logic for uTalepListesi.xaml
    /// </summary>
    public partial class uTalepListesi : UserControl
    {
        public uTalepListesi()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DBOperations.SetGrid(dtgTalepListei);
        }
    }
}
