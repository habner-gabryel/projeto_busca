using System.Configuration;

namespace projeto_busca.classes
{
    class Mapa
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private Premio[,] premios;
        private Saida saida;

        public Mapa(int linhas, int colunas, Saida saida) { 
            this.linhas = linhas; 
            this.colunas = colunas;
            this.premios = new Premio[linhas, colunas];
            this.saida = saida;
        }

        public Premio ObterPremio(int linha, int coluna) { 
            return premios[linha, coluna];
        }

        public Saida obterSaida(int linha, int coluna) {
            return saida;
        }
    }
}
