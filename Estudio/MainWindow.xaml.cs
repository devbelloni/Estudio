using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Timers;
using System.Threading;



namespace Estudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "programacao.xml";

        public MainWindow()
        {
            InitializeComponent();

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList nodeList = (xml.SelectNodes("programacao/blocos/bloco/items/item"));
            List<string> nameList = new List<string>();
            List<string> timeList = new List<string>();

            foreach (XmlNode element in nodeList)
            {
                var node = element?.ChildNodes[0]?.ChildNodes[1];

                if (node != null)
                {
                    var name = node.FirstChild?.Value;
                    nameList.Add(name);
                    ListaDeMusicas.Items.Add(name);

                    var time = node.FirstChild?.Value;
                    timeList.Add(time);
                }
            }
        }


        public void BtOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            string ipServidor = Convert.ToString(ip.Text);
            string portaServidor = Convert.ToString(porta.Text);
            string servidor = ("Servidor: " + ipServidor + " Porta: " + portaServidor + " Data: " + dateTime.ToString() + Environment.NewLine);
            if (ipServidor != "" && portaServidor != "") //Se os campos forem diferentes de vazio, o botão fica habilidado           {
                btOK.IsEnabled = true;

            File.WriteAllTextAsync("WriteText.txt", servidor);


        }

        private void btEnviar_Ok(object sender, RoutedEventArgs e)
        {
            //            string mensagemServidor = Convert.ToString(Mensagem.Text);
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void Music_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        public void BtPlay_ClickAsync(object sender, RoutedEventArgs e)
        {

            playngMusic.Text = ListaDeMusicas.SelectedItem.ToString();

            int hora = 0;
            int min = 0;
            int seg = 0;

            while (hora < 12) 
            {
                timerbox.Text = ($"{hora} : {min} : {seg}");

                if (seg <= 59)
                {
                    seg++;
                }

                if (seg > 59)
                {
                    seg = 0;
                    min++;
                }

                if (min > 59)
                {
                    min = 0;
                    hora++;
                }
                Thread.Sleep(1000);
            }
        }
    }
}