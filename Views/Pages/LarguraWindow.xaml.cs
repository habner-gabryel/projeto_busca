using projeto_busca.Classes;
using projeto_busca.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly Mapa mapa;
        public LarguraWindow()
        {
            InitializeComponent();

            this.mapa = MapaController.CriarMapa(10, 10);

            List<TerrenoPosicao> terrenos = MapaController.RenderCenario(this.mapa);

            AdicionarImagensNaGrade(terrenos);
        }

        private void AdicionarImagensNaGrade(List<TerrenoPosicao> posicoes)
        {
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image image = renderImagem(pos.imagem, 80, 80);

                matrizGrid.Children.Add(image);
                Grid.SetRow(image, pos.posicao.linha);
                Grid.SetColumn(image, pos.posicao.coluna);

            }
        }

        private void EfetuarBusca()
        {
            Gato gato = new Gato(this.mapa.Inicio.terrenoPosicao);

            List<TerrenoPosicao> caminho = gato.buscaLargura(this.mapa, this.mapa.Saida);

            foreach (TerrenoPosicao pos in caminho) {

                if(pos == mapa.Saida.terrenoPosicao || pos == mapa.Inicio.terrenoPosicao) {
                    continue;
                }

                UIElement imagemAnterior = matrizGrid.Children
                .Cast<UIElement>()
                .First(e => Grid.GetRow(e) == pos.posicao.linha && Grid.GetColumn(e) == pos.posicao.coluna);
                matrizGrid.Children.Remove(imagemAnterior);
               
                Image image = renderImagem("caminho.png", 80, 80);

                matrizGrid.Children.Add(image);
                Grid.SetRow(image, pos.posicao.linha);
                Grid.SetColumn(image, pos.posicao.coluna);
            }
        }

        private Image renderImagem(String nomeImg, int width, int height)
        {
            Image image = new()
            {
                Width = width,
                Height = height
            };

            BitmapImage bitImagem = new();

            String url = "C:\\repositorios\\VisualStudio\\projeto_busca\\Views\\Imagens\\" + nomeImg;

            bitImagem.BeginInit();
            bitImagem.UriSource = new(@url);
            bitImagem.DecodePixelWidth = width;
            bitImagem.DecodePixelHeight = height;
            bitImagem.EndInit();
            image.Source = bitImagem;
            return image;
        }

        private void btBuscar_Click(object sender, EventArgs e) {
            EfetuarBusca();
            myPopup.IsOpen = false;
        }

    }
}
