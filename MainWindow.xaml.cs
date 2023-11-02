using projeto_busca.Views.Pages;
using System;
using System.Windows;
using System.Windows.Controls;

namespace projeto_busca
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btLargura_Click(object sender, EventArgs e)
        {
            MapaWindow mapaWindow = new("largura");
            mapaWindow.Show();
        }

        private void btProfundidade_Click(object sender, EventArgs e)
        {
            MapaWindow mapaWindow = new("profundidade");
            mapaWindow.Show();
        }

        private void btGulosa_Click(object sender, EventArgs e)
        {
            MapaWindow mapaWindow = new("gulosa");
            mapaWindow.Show();
        }

        private void btEstrela_Click(object sender, EventArgs e)
        {
            MapaWindow mapaWindow = new("estrela");
            mapaWindow.Show();
        }
    }
}
