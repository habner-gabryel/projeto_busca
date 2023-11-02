using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Linq;

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

        public TerrenoPosicao posicaoAtual() { return posicaoGato; }

        public void mudarPosicao(TerrenoPosicao pos) {  this.posicaoGato = pos; }

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

        public List<TerrenoPosicao> buscaProfundidade(Mapa mapa, TerrenoPosicao inicio, Saida saida, HashSet<TerrenoPosicao> visitados)
        {
            if (visitados.Contains(inicio))
            {
                return new List<TerrenoPosicao>();
            }

            visitados.Add(inicio);

            if (mapa.ObterPremio(inicio) != null)
            {
                coletaPremio(mapa.ObterPremio(inicio));
            }

            if (inicio == saida.terrenoPosicao)
            {
                return visitados.ToList<TerrenoPosicao>();
            }

            foreach (var vizinho in mapa.obterTerrenosVizinhos(inicio))
            {
                List<TerrenoPosicao> caminho= buscaProfundidade(mapa, vizinho, saida, visitados);
                
                if (caminho != null)
                {
                    caminho.Insert(0, inicio);
                    return caminho;
                }
            }

            return new List<TerrenoPosicao>();
        }
    }
}
