using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace ExtremeTaleplerV2.UControls
{
    /// <summary>
    /// Interaction logic for UC_DosyaOlustur.xaml
    /// </summary>
    public partial class UC_DosyaOlustur : UserControl
    {
        public UC_DosyaOlustur()
        {
            InitializeComponent();
        }
        private byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length / 2)
                             .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                             .ToArray();
        }
        private void btnHexToFrx_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hex = txtHex.Text.Trim();
                if (hex.StartsWith("0x")) hex = hex.Substring(2);

                byte[] bytes = HexStringToByteArray(hex);

                // GZip decompress (FRX açmak için)
                byte[] frxBytes = bytes;
                if (bytes.Length > 2 && bytes[0] == 0x1F && bytes[1] == 0x8B)
                {
                    using (var ms = new MemoryStream(bytes))
                    using (var gzip = new GZipStream(ms, CompressionMode.Decompress))
                    using (var outMs = new MemoryStream())
                    {
                        gzip.CopyTo(outMs);
                        frxBytes = outMs.ToArray();
                    }
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "FastReport (*.frx)|*.frx";
                if (sfd.ShowDialog() == true)
                {
                    File.WriteAllBytes(sfd.FileName, frxBytes);
                    MessageBox.Show("FRX dosyası oluşturuldu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
