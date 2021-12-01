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
            XmlTextReader tr = new XmlTextReader(path); 
/*            while (tr.Read())
            {
                if (tr.NodeType == XmlNodeType.Element)
                    if (tr.Name == "nome")
                        if (tr.NodeType == XmlNodeType.Text)
                            ListaDeMusicas.Items.Add(tr.Value);
            }
*/
            while (tr.Read())
            {
                if (tr.NodeType == XmlNodeType.Text)
                    ListaDeMusicas.Items.Add(tr.Value);
            }
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            string ipServidor = Convert.ToString(ip.Text);
            string portaServidor = Convert.ToString(porta.Text);
            string servidor = ("Servidor: " + ipServidor + " Porta: " + portaServidor + " Data: " + dateTime.ToString() + Environment.NewLine);
            if (ipServidor != "" && portaServidor != "") //Se os campos forem diferentes de vazio, o botão fica habilidado           {
                btOK.IsEnabled = true;
            File.WriteAllTextAsync("WriteText.txt", servidor);
        }

        private void ListaDeMusicas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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



