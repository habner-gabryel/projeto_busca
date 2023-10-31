using projeto_busca.Exceptions;
using System.Collections.Generic;

namespace projeto_busca.Classes
{
    class Mapa
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private List<Premio> premios;
        private Saida saida;
        private List<TerrenoPosicao> tps;

        public Mapa(int linhas, int colunas, List<Premio> premios, Saida saida, List<TerrenoPosicao> tps)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.premios = premios;
            this.saida = saida;
            this.tps = tps;
        }

        public Premio ObterPremio(Posicao posicao)
        {
            Premio? premio = null;
            foreach (Premio p in this.premios)
            {
                if (p.terrenoPosicao != null && p.terrenoPosicao.posicao != null && p.terrenoPosicao.posicao == posicao)
                {
                    premio = p;
                    break;
                }
            }

            return premio;
        }

        public Saida obterSaida(Posicao posicao)
        {
            if (this.saida == null || this.saida.terrenoPosicao == null)
            {
                return null;
            }

            if(saida.terrenoPosicao.posicao == posicao)
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
