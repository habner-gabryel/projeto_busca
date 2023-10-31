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
    /// Lógica interna para EstrelaWindow.xaml
    /// </summary>
    public partial class EstrelaWindow : Window
    {
        public EstrelaWindow()
        {
            InitializeComponent();

            List<TerrenoPosicao> terrenos = MapaController.RenderCenario();

            AdicionarImagensNaGrade(terrenos);
        }

        private void AdicionarImagensNaGrade(List<TerrenoPosicao> posicoes)
        {
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image image = new()
                {
                    Width = 50,
                    Height = 50
                };

                BitmapImage bitImagem = new();

                String url = "C:\\repositorios\\VisualStudio\\projeto_busca\\Views\\Imagens\\" + pos.imagem;

                bitImagem.BeginInit();
                bitImagem.UriSource = new(@url);
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
