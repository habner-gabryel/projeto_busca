using projeto_busca.Exceptions;
using System.Collections.Generic;
using System.Configuration;

namespace projeto_busca.Classes
{
    class Mapa
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private List<Premio> premios;
        private Saida saida;
        private List<TerrenoPosicao> tps;

        public Mapa(int linhas, int colunas, List<Premio> premios, Saida saida, List<TerrenoPosicao> tps) { 
            this.linhas = linhas; 
            this.colunas = colunas;
            this.premios = premios;
            this.saida = saida;
            this.tps = tps;
        }

        public Premio ObterPremio(Posicao posicao) {
            Premio? premio = null;
            foreach(Premio p in this.premios) {
                if(p.terrenoPosicao != null && p.terrenoPosicao.posicao != null && p.terrenoPosicao.posicao == posicao)
                {
                    premio = p;
                }
            }

            if(premio == null) {
                throw new OberPremioExeption("Nenhum premio encontrado para a posicao: " + posicao.ToString() );
            }
            return premio;
        }

        public Saida obterSaida() {
            if(this.saida == null || this.saida.posicao == null) {
                throw new System.Exception("Saida inexistente no mapa");
            }
           return this.saida;
        }
    }
}
