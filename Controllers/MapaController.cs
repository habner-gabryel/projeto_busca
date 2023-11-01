using projeto_busca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace projeto_busca.Controllers
{
    class MapaController
    {
#pragma warning disable CS8605 // Executando a conversão unboxing de um valor possivelmente nulo.
        public static Mapa CriarMapa(int linhas, int colunas)
        {

            int quantPremios = new Random().Next(1, 7);

            List<TerrenoPosicao> posicoes = new();
            List<TerrenoPosicao> posicoesExclud;
            List<Premio> premios = new();
            Array terrenosDisp = Enum.GetValues(typeof(Terreno));

            for (int x = 0; x < linhas; x++)
            {
                for (int y = 0; y < colunas; y++)
                {
                    posicoes.Add(new TerrenoPosicao((Terreno)terrenosDisp.GetValue(new Random().Next(terrenosDisp.Length)), new Posicao(x, y)));
                }
            }

            posicoesExclud = new(posicoes);
            TerrenoPosicao pos;

            for (int x = 0; x <= quantPremios; x++)
            {
                pos = posicoesExclud.ElementAt(new Random().Next(posicoesExclud.Count));
                premios.Add(new (pos, new Random().Next(1, 10)));
                posicoesExclud.Remove(pos);
            }

            pos = posicoesExclud.ElementAt(new Random().Next(posicoesExclud.Count));
            Inicio inicio = new(pos);
            posicoesExclud.Remove(pos);

            pos = posicoesExclud.ElementAt(new Random().Next(posicoesExclud.Count));
            Saida saida = new (pos);

            return new Mapa(linhas, colunas, premios, inicio, saida, posicoes);
        }

        public static List<TerrenoPosicao> RenderCenario(Mapa mapa)
        {

            List<TerrenoPosicao> terrenos = mapa.obterTerrenos();

            foreach (TerrenoPosicao terreno in terrenos)
            {
                Inicio inicio = mapa.obterInicio(terreno);
                Saida saida = mapa.obterSaida(terreno);
                Premio premio = mapa.ObterPremio(terreno);

                if (inicio != null) {
                    terreno.mudarImagem("inicio.png");
                } else if (saida != null) {
                    terreno.mudarImagem("saida.png");
                } else if (premio != null) {
                    terreno.mudarImagem("premio.png");
                }
            }

            return terrenos;
        }

    }
#pragma warning restore CS8605 // Executando a conversão unboxing de um valor possivelmente nulo.
}
