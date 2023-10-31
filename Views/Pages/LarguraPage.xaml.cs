using projeto_busca.Classes;
using projeto_busca.Controllers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace projeto_busca.Views.Pages
{
    /// <summary>
    /// Interação lógica para LarguraPage.xam
    /// </summary>
    public partial class LarguraWindow : Window
    {
        public LarguraWindow()
        {
            InitializeComponent();
            int linhas = 15;
            int colunas = 15;

            Mapa mapa = MapaController.criarMapa(linhas, colunas);

            List<TerrenoPosicao> terrenos = mapa.obterTerrenos();

            foreach (var terreno in terrenos)
            {
                Saida saida = mapa.obterSaida(terreno.posicao);
                Premio premio = mapa.ObterPremio(terreno.posicao);

                if (saida != null) {
                    terreno.mudarImagem("saida.png");
                } else if (premio != null) {
                    terreno.mudarImagem("premio.png");
                }
            }

            AdicionarImagensNaGrade(terrenos);

        }

        private void AdicionarImagensNaGrade(List<TerrenoPosicao> posicoes)
        {
            foreach (TerrenoPosicao pos in posicoes)
            {
                Image imagem = new()
                {
                    Source = new BitmapImage(new Uri("../Imagens/" + pos.imagem, UriKind.RelativeOrAbsolute)),
                    Width = 80,
                    Height = 80
                };

                gridContainer.Items.Add(imagem);
            }
        }
    }
}
