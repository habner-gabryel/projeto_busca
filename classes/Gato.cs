using System.Collections.Generic;
using System.Xml.Linq;
using System;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections;

namespace projeto_busca.Classes
{
    class Gato
    {

        Double custoAcumulado { get; set; }
        int premiosColetados { get; set; }

        TerrenoPosicao posicaoGato { get; set; }

        public Gato(TerrenoPosicao posicaoGato)
        {
            this.posicaoGato = posicaoGato;
        }

        public Double getCustoAcumulado() {  return custoAcumulado; }

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
                        this.custoAcumulado += (int)vizinho.terreno;
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
            this.custoAcumulado += (int)inicio.terreno;

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
                if (vizinho.terreno == Terreno.Parede)
                {
                    continue;
                }

                List<TerrenoPosicao> caminho= buscaProfundidade(mapa, vizinho, saida, visitados);
                
                if (caminho != null)
                {
                    caminho.Insert(0, inicio);
                    return caminho;
                }
            }

            return new List<TerrenoPosicao>();
        }

        public List<TerrenoPosicao> buscaGulosa(Mapa mapa, TerrenoPosicao inicio, Saida saida)
        {
            HashSet<TerrenoPosicao> visitados = new();
            List<TerrenoPosicao> caminho = new();
            TerrenoPosicao posAtual = inicio;

            this.custoAcumulado = 0;
            int custoAtual = (int)inicio.terreno;

            while (posAtual != saida.terrenoPosicao)
            {
                caminho.Add(posAtual);
                visitados.Add(posAtual);

                if (posAtual.terreno == Terreno.Parede)
                {
                    continue;
                }

                if (mapa.ObterPremio(posAtual) != null)
                {
                    coletaPremio(mapa.ObterPremio(posAtual));
                }

                TerrenoPosicao? proxPos = null;
                double distanciaMin = double.MaxValue;

                foreach (TerrenoPosicao vizinho in mapa.obterTerrenosVizinhos(posAtual))
                {
                    if(vizinho.terreno == Terreno.Parede)
                    {
                        continue;
                    }

                    if (!visitados.Contains(vizinho))
                    {
                        double distancia = vizinho.CalcularHeuristica(saida);
                        if (distancia < distanciaMin)
                        {
                            distanciaMin = distancia;
                            proxPos = vizinho;
                        }
                        this.custoAcumulado += (int)vizinho.terreno + distancia;
                    }
                }

                if (proxPos == null)
                {
                    Console.WriteLine("Caminho não encontrado.");
                    return new List<TerrenoPosicao>();
                }

                posAtual = proxPos;
            }

            caminho.Add(posAtual);
            return caminho;
        }


        public List<TerrenoPosicao> BuscaAEstrela(Mapa mapa, TerrenoPosicao inicio, Saida saida)
        {
            var openSet = new HashSet<TerrenoPosicao>();
            var cameFrom = new Dictionary<TerrenoPosicao, TerrenoPosicao>();
            var gScore = new Dictionary<TerrenoPosicao, double>();
            var fScore = new Dictionary<TerrenoPosicao, double>();

            openSet.Add(inicio);
            gScore[inicio] = 0;
            fScore[inicio] = gScore[inicio] + inicio.CalcularHeuristica(saida);

            while (openSet.Count > 0)
            {
                TerrenoPosicao posAtual = null;
                double lowestFScore = double.MaxValue;

                foreach (TerrenoPosicao posicao in openSet)
                {
                    if (fScore[posicao] < lowestFScore)
                    {
                        posAtual = posicao;
                        lowestFScore = fScore[posicao];
                    }
                }

                if (posAtual.terreno == Terreno.Parede)
                {
                    continue;
                }

                if (mapa.ObterPremio(posAtual) != null)
                {
                    coletaPremio(mapa.ObterPremio(posAtual));
                }

                if (posAtual == saida.terrenoPosicao)
                {
                    return ReconstruirCaminho(cameFrom, posAtual);
                }

                openSet.Remove(posAtual);

                foreach (TerrenoPosicao vizinho in mapa.obterTerrenosVizinhos(posAtual))
                {
                    if (vizinho.terreno == Terreno.Parede)
                    {
                        continue;
                    }

                    double tentativeGScore = gScore[posAtual] + posAtual.CalcularHeuristica(saida);
                    if (tentativeGScore < gScore.GetValueOrDefault(vizinho, int.MaxValue))
                    {
                        cameFrom[vizinho] = posAtual;
                        gScore[vizinho] = tentativeGScore;
                        fScore[vizinho] = gScore[vizinho] + vizinho.CalcularHeuristica(saida);
                        if (!openSet.Contains(vizinho))
                        {
                            openSet.Add(vizinho);
                        }
                    }

                    this.custoAcumulado += (int)posAtual.terreno + fScore[posAtual];
                }
            }

            return new List<TerrenoPosicao>();
        }
        
        static List<TerrenoPosicao> ReconstruirCaminho(Dictionary<TerrenoPosicao, TerrenoPosicao> posInicial, TerrenoPosicao posFinal)
        {
            List<TerrenoPosicao> caminho = new();
            while (posInicial.ContainsKey(posFinal))
            {
                caminho.Insert(0, posFinal);
                posFinal = posInicial[posFinal];
            }
            caminho.Insert(0, posFinal);
            return caminho;
        }

    }
}
