using projeto_busca.Classes;
using projeto_busca.Controllers;
using System.Windows.Controls;

namespace projeto_busca.Views.Pages
{
    /// <summary>
    /// Interação lógica para LarguraPage.xam
    /// </summary>
    public partial class LarguraPage : Page
    {
        public LarguraPage()
        {
            int linhas = 15;
            int colunas = 15;

            Mapa mapa = MapaController.criarMapa(linhas, colunas);

            for (int x = 0; x <= mapa.linhas; x++)
            {
                for (int y = 0; y <= mapa.colunas; y++)
                {

                    if (mapa.obterSaida().posicao == new Posicao(x, y))
                    {
                        // --- print da saida ---
                    }

                    if (mapa.ObterPremio(new Posicao(x, y)) != null)
                    {
                        // --- print do premio ---
                    }

                }
            }

            InitializeComponent();
        }
    }
}
