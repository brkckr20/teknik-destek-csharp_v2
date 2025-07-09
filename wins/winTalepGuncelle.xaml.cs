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
    /// Interaction logic for winTalepGuncelle.xaml
    /// </summary>
    public partial class winTalepGuncelle : Window
    {
        public int _id;
        public winTalepGuncelle(int id)
        {
            InitializeComponent();
            _id = id;
            this.Title += " | Kayıt numarası : [" + _id + "]";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var item = DBOperations.TalepGetir(this._id);
            dpTarih.SelectedDate = Convert.ToDateTime(item["Tarih"]);
            txtKullanici.Text = item["Kullanici"].ToString();
            txtDepartman.Text = item["Departman"].ToString();
            txtBaslik.Text = item["Baslik"].ToString();
            string baslikMetni = item["Aciklama"].ToString();
            FlowDocument flowDoc = new FlowDocument();
            Paragraph paragraph = new Paragraph(new Run(baslikMetni));
            flowDoc.Blocks.Add(paragraph);
            txtAciklama.Document = flowDoc;
            cmbDurum.SelectedValue = Convert.ToInt32(item["Durumu"]);
        }

        private void btnTalepGuncelle_Click(object sender, RoutedEventArgs e)
        {
            string aciklamaMetni = new TextRange(txtAciklama.Document.ContentStart, txtAciklama.Document.ContentEnd).Text;
            DBOperations.Ekle(txtDepartman.Text, txtKullanici.Text, txtBaslik.Text, aciklamaMetni, cmbDurum.SelectedIndex.ToString(), Convert.ToDateTime(dpTarih.SelectedDate), _id);
        }
    }
}
