using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ExtremeTaleplerV2
{
    public partial class MainScreen: Window
    {
        public MainScreen()
        {
            InitializeComponent();
        }
        private void AddOrSelectTab(string header, UserControl content)
        {
            foreach (TabItem item in mainTabControl.Items)
            {
                if (item.Header is StackPanel sp &&
                    sp.Children.OfType<TextBlock>().FirstOrDefault()?.Text == header)
                {
                    mainTabControl.SelectedItem = item;
                    return;
                }
            }

            // Header için StackPanel: Başlık + X butonu
            StackPanel headerPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            TextBlock headerText = new TextBlock
            {
                Text = header,
                Margin = new Thickness(0, 0, 5, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            Button closeButton = new Button
            {
                Content = "❌",
                Width = 16,
                Height = 16,
                Padding = new Thickness(0),
                Margin = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = Cursors.Hand,
                ToolTip = "Sekmeyi Kapat"
            };

            closeButton.Click += (s, e) =>
            {
                mainTabControl.Items.Remove(
                    mainTabControl.Items
                        .Cast<TabItem>()
                        .FirstOrDefault(t => t.Header == headerPanel)
                );
            };

            headerPanel.Children.Add(headerText);
            headerPanel.Children.Add(closeButton);

            TabItem newTabItem = new TabItem
            {
                Header = headerPanel,
                Content = content
            };

            mainTabControl.Items.Add(newTabItem);
            mainTabControl.SelectedItem = newTabItem;
        }
        private void btnTalepIslemleri_Click(object sender, RoutedEventArgs e)
        {
            UControls.UC_TalepIslemleri uc = new UControls.UC_TalepIslemleri();
            AddOrSelectTab("Talep İşlemleri", uc);
        }

        private void btnDepartmanKarti_Click(object sender, RoutedEventArgs e)
        {
            UControls.UC_KullaniciVeDepartmanKarti uc = new UControls.UC_KullaniciVeDepartmanKarti(Utils.Enums.CardType.Departman);
            AddOrSelectTab("Departman Kartı", uc);
        }

        private void btnKullaniciKarti_Click(object sender, RoutedEventArgs e)
        {
            UControls.UC_KullaniciVeDepartmanKarti uc = new UControls.UC_KullaniciVeDepartmanKarti(Utils.Enums.CardType.Kullanici);
            AddOrSelectTab("Kullanıcı Kartı", uc);
        }

        private void btnDosyaOlustur_Click(object sender, RoutedEventArgs e)
        {
            UControls.UC_DosyaOlustur uc = new UControls.UC_DosyaOlustur();
            AddOrSelectTab("Rapor Dosyası Dluştur", uc);
        }
    }
}
