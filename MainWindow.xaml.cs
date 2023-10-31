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
            LarguraWindow largura = new();
            largura.Show();
        }

        private void btProfundidade_Click(object sender, EventArgs e)
        {
            ProfundidadeWindow profundidade = new();
            profundidade.Show();
        }

        private void btGulosa_Click(object sender, EventArgs e)
        {
            GulosaWindow gulosa = new();
            gulosa.Show();
        }

        private void btEstrela_Click(object sender, EventArgs e)
        {
            EstrelaWindow estrela = new();
            estrela.Show();
        }
    }
}
