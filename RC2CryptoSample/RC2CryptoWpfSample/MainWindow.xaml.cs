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
using RC2CryptoSample;

namespace RC2CryptoWpfSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var iv = this.EncryptIv.Text;
            var key = this.EncryptCryptoKey.Text;
            var message = this.EncryptNomalMessage.Text;

            var crp = new RC2(key, message);
            crp.IV = iv;

            crp.Encrypt();

            this.EncryptResult.Text = crp.EncryptMessage;

        }
    }
}
