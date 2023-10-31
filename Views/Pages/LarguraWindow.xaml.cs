using projeto_busca.Classes;
using projeto_busca.Controllers;
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

namespace projeto_busca.Views.Pages
{
    /// <summary>
    /// Lógica interna para LarguraWindow.xaml
    /// </summary>
    public partial class LarguraWindow : Window
    {
        public LarguraWindow()
        {
            InitializeComponent();

            int linhas = 10;
            int colunas = 10;

            Mapa mapa = MapaController.criarMapa(linhas, colunas);

            List<TerrenoPosicao> terrenos = mapa.obterTerrenos();

            foreach (TerrenoPosicao terreno in terrenos)
            {
                Saida saida = mapa.obterSaida(terreno.posicao);
                Premio premio = mapa.ObterPremio(terreno.posicao);

                if (saida != null)
                {
                    terreno.mudarImagem("saida.jpg");
                }
                else if (premio != null)
                {
                    terreno.mudarImagem("premio.jpg");
                }
            }

            AdicionarImagensNaGrade(terrenos);
        }

        private void AdicionarImagensNaGrade(List<TerrenoPosicao> posicoes)
        {
            int counter2 = 0, counter = 0;
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image image = new Image();
                image.Width = 50;
                image.Height = 50;

                BitmapImage bitImagem = new BitmapImage();

                if(pos.imagem == null || pos.imagem.Equals(""))
                {
                    counter++;
                }

                counter2++;

                String url = "C:\\repositorios\\VisualStudio\\projeto_busca\\Views\\Imagens\\" + pos.imagem;

                bitImagem.BeginInit();
                bitImagem.UriSource = new Uri(@url);
                bitImagem.DecodePixelWidth = 50;
                bitImagem.DecodePixelHeight = 50;
                bitImagem.EndInit();
                
                image.Source = bitImagem;
                Grid.SetRow(image, pos.posicao.linha);
                Grid.SetColumn(image, pos.posicao.coluna);

                gridContainer.Items.Add(image);
            }

            if(counter != 0)
            {
                MessageBox.Show("posições sem imagem: " + counter + " de " + counter2 + " posições");
            }
        }
    }
}
