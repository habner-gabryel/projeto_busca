using projeto_busca.Exceptions;
using System.Collections.Generic;

namespace projeto_busca.Classes
{
    class Mapa
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private List<Premio> premios;
        private Inicio inicio;
        private Saida saida;
        private List<TerrenoPosicao> tps;

        public Mapa(int linhas, int colunas, List<Premio> premios, Inicio inicio, Saida saida, List<TerrenoPosicao> tps)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.premios = premios;
            this.inicio = inicio;
            this.saida = saida;
            this.tps = tps;
        }

        public Premio ObterPremio(TerrenoPosicao posicao)
        {
            Premio? premio = null;
            foreach (Premio p in this.premios)
            {
                if (p.terrenoPosicao != null && p.terrenoPosicao == posicao)
                {
                    premio = p;
                    break;
                }
            }

            return premio;
        }

        public Inicio obterInicio(TerrenoPosicao posicao)
        {
            if(this.inicio == null || this.inicio.terrenoPosicao == null)
            {
                return null;
            }
            if(inicio.terrenoPosicao == posicao)
            {
                return this.inicio;
            }

            return null;
        }

        public Saida obterSaida(TerrenoPosicao posicao)
        {
            if (this.saida == null || this.saida.terrenoPosicao == null)
            {
                return null;
            }

            if(saida.terrenoPosicao == posicao)
            { 
                return this.saida;
            }

            return null;
        }

        public List<TerrenoPosicao> obterTerrenos()
        {
            return tps;
        }
    }
}
