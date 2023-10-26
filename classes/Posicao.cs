using System;

namespace projeto_busca.Classes
{
    class Posicao
    {
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public int linha { get; set; }
        public int coluna { get; set; }

        public override string ToString()
        {
            return "Linha: " + linha + " - Coluna: " + coluna;
        }

        public Boolean isValidPosicaoInMapa(Mapa mapa, int linha, int coluna)
        {
            if (mapa == null)
            {
                return false;
            }

            if (mapa.linhas < linha || mapa.colunas < coluna)
            {
                return false;
            }

            return true;
        }
    }
}
