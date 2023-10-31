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
    /// Lógica interna para ProfundidadeWindow.xaml
    /// </summary>
    public partial class ProfundidadeWindow : Window
    {
        public ProfundidadeWindow()
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
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image image = new Image();
                image.Width = 50;
                image.Height = 50;

                BitmapImage bitImagem = new BitmapImage();

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
        }
    }
}
