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

namespace ExtremeTaleplerV2.NewWins.Lists
{
    /// <summary>
    /// Interaction logic for WinDepartmanListesi.xaml
    /// </summary>
    public partial class WinDepartmanListesi : Window
    {
        public WinDepartmanListesi()
        {
            InitializeComponent();
            dgDepartman.ItemsSource = new List<Departman>
        {
            new Departman { Id = 1, Ad = "Muhasebe" },
            new Departman { Id = 2, Ad = "İK" },
            new Departman { Id = 3, Ad = "Satın Alma" }
        };
        }
        public class Departman
        {
            public int Id { get; set; }
            public string Ad { get; set; }
        }
    }
}
