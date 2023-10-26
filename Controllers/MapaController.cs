using projeto_busca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projeto_busca.Controllers
{
    class MapaController
    {
        public static Mapa criarMapa(int linhas, int colunas)
        {
            Random random = new Random();
            int quantPremios = random.Next(1, 7);

            List<TerrenoPosicao> posicoes = new List<TerrenoPosicao>();
            List<Premio> premios = new List<Premio>();
            Array terrenosDisp = Enum.GetValues(typeof(Terreno));


            for (int x = 0; x <= linhas; x++)
            {
                for (int y = 0; y <= colunas; y++)
                {
                    posicoes.Add(new TerrenoPosicao((Terreno)terrenosDisp.GetValue(random.Next(terrenosDisp.Length)), new Posicao(x, y)));
                }
            }

            for (int x = 0; x <= quantPremios; x++)
            {
                premios.Add(new Premio((TerrenoPosicao)posicoes.ElementAt(random.Next(posicoes.Count)), random.Next(5, 10)));
            }

            List<TerrenoPosicao> posPremios = new List<TerrenoPosicao>();

            foreach (Premio premio in premios)
            {
                posPremios.Add(premio.terrenoPosicao);
            }

            Saida saida = new Saida(((TerrenoPosicao)posicoes.ElementAt(random.Next(posicoes.Count))).posicao);

            return new Mapa(linhas, colunas, premios, saida, posicoes);
        }

    }
}
