using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Runtime.CompilerServices;

namespace projeto_busca.Classes
{
    class Gato
    {

        int custoAcumulado { get; set; }
        int premiosColetados { get; set; }

        TerrenoPosicao posicaoGato { get; set; }

        public Gato(TerrenoPosicao posicaoGato)
        {
            this.posicaoGato = posicaoGato;
        }

        public int getCustoAcumulado() {  return custoAcumulado; }

        public int getPremiosColetados() {  return premiosColetados; }

        public void coletaPremio(Premio premio) { this.premiosColetados += premio.valor; }

        public List<TerrenoPosicao> buscaLargura(Mapa mapa, Saida saida)
        {
            Queue<Tuple<TerrenoPosicao, List<TerrenoPosicao>>> queue = new();
            HashSet<TerrenoPosicao> visitados = new();

            queue.Enqueue(new Tuple<TerrenoPosicao, List<TerrenoPosicao>>(posicaoGato, new(){ posicaoGato }));
            visitados.Add(posicaoGato);

            while (queue.Count > 0)
            {
                var posicaoFila = queue.Dequeue();
                TerrenoPosicao terrenoAtual = posicaoFila.Item1;
                List<TerrenoPosicao> caminhoPercorrido = posicaoFila.Item2;

                if(terrenoAtual.terreno == Terreno.Parede)
                {
                    continue;
                }

                if(mapa.ObterPremio(terrenoAtual) != null) {
                    coletaPremio(mapa.ObterPremio(terrenoAtual));
                }

                if (terrenoAtual == saida.terrenoPosicao) {
                    return caminhoPercorrido;
                }

                foreach (TerrenoPosicao vizinho in mapa.obterTerrenosVizinhos(terrenoAtual))
                {
                    if (!visitados.Contains(vizinho))
                    {
                        List<TerrenoPosicao> novoLocal = new(caminhoPercorrido) { vizinho };
                        queue.Enqueue(new Tuple<TerrenoPosicao, List<TerrenoPosicao>>(vizinho, novoLocal));
                        visitados.Add(vizinho);
                    }
                }
            }

            return new List<TerrenoPosicao>();
        }
    }
}
