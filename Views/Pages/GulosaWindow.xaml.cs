﻿using projeto_busca.Classes;
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
    /// Lógica interna para GulosaWindow.xaml
    /// </summary>
    public partial class GulosaWindow : Window
    {
        public GulosaWindow()
        {
            InitializeComponent();

            Mapa mapa = MapaController.CriarMapa(10, 10);

            List<TerrenoPosicao> terrenos = MapaController.RenderCenario(mapa);

            AdicionarImagensNaGrade(terrenos);

            EfetuarBusca(mapa);
        }

        private void EfetuarBusca(Mapa mapa)
        {
            throw new NotImplementedException();
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
