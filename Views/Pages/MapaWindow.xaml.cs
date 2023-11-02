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
using System.Xml.Linq;

namespace projeto_busca.Views.Pages
{
    /// <summary>
    /// Lógica interna para MapaWindow.xaml
    /// </summary>
    public partial class MapaWindow : Window
    {
        private String tipoBusca;

        private readonly Mapa mapa;

        private Gato gato;
        public MapaWindow(String tipoBusca)
        {
            InitializeComponent();

            this.tipoBusca = tipoBusca;

            this.mapa = MapaController.CriarMapa(10, 10);

            this.gato = new Gato(this.mapa.Inicio.terrenoPosicao);

            List<TerrenoPosicao> terrenos = MapaController.RenderCenario(this.mapa);

            AdicionarImagensNaGrade(terrenos);
        }

        private void AdicionarImagensNaGrade(List<TerrenoPosicao> posicoes)
        {
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image image = renderImagem(pos.imagem, 80, 80, String.Empty);

                matrizGrid.Children.Add(image);
                Grid.SetRow(image, pos.posicao.linha);
                Grid.SetColumn(image, pos.posicao.coluna);

            }
        }

        private void ExecutarMovimento(List<TerrenoPosicao> posicoes)
        {

            Task.Run(() =>
            {
                foreach (TerrenoPosicao pos in posicoes)
                {
                    System.Threading.Thread.Sleep(900);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MoverGato(pos);
                    });
                }

            });

        }

        private void MoverGato(TerrenoPosicao pos)
        {
            TerrenoPosicao posAtual = gato.posicaoAtual();

            UIElement gatoElement = matrizMoveGato.Children
                    .Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == posAtual.posicao.linha && Grid.GetColumn(e) == posAtual.posicao.coluna);

            gato.mudarPosicao(pos);

            Grid.SetRow(gatoElement, pos.posicao.linha);
            Grid.SetColumn(gatoElement, pos.posicao.coluna);
        }

        private void EfetuarBusca(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                List<TerrenoPosicao> caminho;

                switch (this.tipoBusca)
                {
                    case "largura" :
                        caminho = gato.buscaLargura(this.mapa, this.mapa.Saida);
                    break;
                    case "profundidade" :
                        caminho = gato.buscaProfundidade(this.mapa, this.mapa.Inicio.terrenoPosicao ,this.mapa.Saida, new HashSet<TerrenoPosicao>());
                    break;
                    default :
                        caminho = new List<TerrenoPosicao>();
                    break;
                }

                 

                foreach (TerrenoPosicao pos in caminho)
                {

                    if (pos == mapa.Saida.terrenoPosicao || pos == mapa.Inicio.terrenoPosicao)
                    {
                        continue;
                    }

                    UIElement imagemAnterior = matrizGrid.Children
                    .Cast<UIElement>()
                    .First(e => Grid.GetRow(e) == pos.posicao.linha && Grid.GetColumn(e) == pos.posicao.coluna);
                    matrizGrid.Children.Remove(imagemAnterior);

                    Image image = renderImagem("caminho.png", 80, 80, "caminho");

                    matrizGrid.Children.Add(image);
                    Grid.SetRow(image, pos.posicao.linha);
                    Grid.SetColumn(image, pos.posicao.coluna);
                }

                Image imageGato = renderImagem("gato.png", 60, 60, "gato");

                matrizMoveGato.Children.Add(imageGato);
                Grid.SetRow(imageGato, gato.posicaoAtual().posicao.linha);
                Grid.SetColumn(imageGato, gato.posicaoAtual().posicao.coluna);

                ExecutarMovimento(caminho);
            }
        }

        private Image renderImagem(String nomeImg, int width, int height, String nomeObj)
        {
            Image image = new()
            {
                Width = width,
                Height = height,
                Name = nomeObj
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



    }
}
