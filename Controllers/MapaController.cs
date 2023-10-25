using projeto_busca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace projeto_busca.Controllers
{
    class MapaController
    {
        public static void imprimirMapa(Mapa mapa) {

            if (mapa == null)
            {
                throw new System.ArgumentNullException("mapa");
            }

            for (int x = 0; x <= mapa.linhas; x++) {
                for (int y = 0; y <= mapa.colunas; y++) {

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
        }

        public Mapa criarMapa(int linhas, int colunas, int heuristica) { 
            Random random = new Random();
            int quantPremios = random.Next(1, 7);

            List<TerrenoPosicao> posicoes = new List<TerrenoPosicao>();
            List<Premio> premios = new List<Premio>();
            Array terrenosDisp = Enum.GetValues(typeof(Terreno));


            for (int x = 0; x <= linhas; x++) {
                for (int y = 0; y <= colunas; y++) {
                    posicoes.Add(new TerrenoPosicao((Terreno)terrenosDisp.GetValue(random.Next(terrenosDisp.Length)), new Posicao(x, y)));
                }
            }

            for (int x = 0; x <= quantPremios; x++) {
                premios.Add( new Premio((TerrenoPosicao)posicoes.ElementAt(random.Next(posicoes.Count)), random.Next(5,10)));
            }

            List<TerrenoPosicao> posPremios = new List<TerrenoPosicao>(); 

            foreach(Premio premio in premios) {
                posPremios.Add(premio.terrenoPosicao);
            }

            Saida saida = new Saida(((TerrenoPosicao)posicoes.ElementAt(random.Next(posicoes.Count))).posicao, heuristica);

            return new Mapa(linhas, colunas, premios, saida, posicoes);
        }

    }
}
