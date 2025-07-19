using System.Windows;

namespace ExtremeTaleplerV2.wins
{
    public partial class winTalepDetayiGuncelle : Window
    {
        public int _id;
        public winTalepDetayiGuncelle(int id, string gorusmeNotu, string not1, string not2, string not3)
        {
            InitializeComponent();
            _id = id;
            txtGorusmeNotu.Text= gorusmeNotu;
            txtNot1.Text= not1;
            txtNot2.Text = not2;
            txtNot3.Text = not3;
        }
    }
}
