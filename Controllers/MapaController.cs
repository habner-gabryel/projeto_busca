using projeto_busca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projeto_busca.Controllers
{
    class MapaController
    {
#pragma warning disable CS8605 // Executando a conversão unboxing de um valor possivelmente nulo.
        public static Mapa criarMapa(int linhas, int colunas)
        {

            int quantPremios = new Random().Next(1, 7);

            List<TerrenoPosicao> posicoes = new();
            List<Premio> premios = new();
            Array terrenosDisp = Enum.GetValues(typeof(Terreno));

            Terreno terreno = new Terreno();

            for (int x = 0; x < linhas; x++)
            {
                for (int y = 0; y < colunas; y++)
                {
                    
                    terreno = (Terreno) terrenosDisp.GetValue(new Random().Next(terrenosDisp.Length));
                    
                    posicoes.Add(new TerrenoPosicao(terreno, new Posicao(x, y)));
                }
            }

            for (int x = 0; x <= quantPremios; x++)
            {
                premios.Add(new ((TerrenoPosicao)posicoes.ElementAt(new Random().Next(posicoes.Count)), new Random().Next(1, 10)));
            }

            List<TerrenoPosicao> posPremios = new();

            foreach (Premio premio in premios)
            {
                posPremios.Add(premio.terrenoPosicao);
            }

            Saida saida = new (((TerrenoPosicao)posicoes.ElementAt(new Random().Next(posicoes.Count))));

            return new Mapa(linhas, colunas, premios, saida, posicoes);
        }

    }
#pragma warning restore CS8605 // Executando a conversão unboxing de um valor possivelmente nulo.
}
