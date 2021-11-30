using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;

namespace Estudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void BtOK_ClickAsync(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            string ipServidor = Convert.ToString(ip.Text);
            string portaServidor = Convert.ToString(porta.Text);
            string servidor = ("Servidor: " + ipServidor + " Porta: " + portaServidor + " Data: " + dateTime.ToString() + Environment.NewLine);
            if (ipServidor != "" && portaServidor != "") //Se os campos forem diferentes de vazio, o botão fica habilidado           {
                btOK.IsEnabled = true;
            await File.WriteAllTextAsync("WriteText.txt", servidor);
        }

        private void ListaDeMusicas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] vs = File.ReadAllLines("bdMusical.xml");
            XElement xml = XElement.Parse("vs");

            foreach (XElement el in xml.Elements())
            {
                ListBoxItem item = new ListBoxItem();
                string NomeArquivo = el.Attribute("nomearquivo").Value;
                string TempoTotal = el.Attribute("tempototal").Value;
                item.Content = NomeArquivo + ": " + TempoTotal;
                _ = ListaDeMusicas.Items.Add(item);
            }
        }

        private void BtPlay_ClickAsync(object sender, RoutedEventArgs e)
        {

        }

        private void btEnviar_Ok(object sender, RoutedEventArgs e)
        {
            string mensagemServidor = Convert.ToString(Mensagem.Text);
        }
    }
}



