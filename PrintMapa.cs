using projeto_busca.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_busca
{
    class PrintMapa
    {
        public static void imprimirMapa(Mapa mapa)
        {
            if (mapa == null) {
                return;
            }
            /* Random random = new Random();
            int posX = random.Next(0, 101);
            int posY = random.Next(0, 101); 
             ---- implementar essa randomizacao na Saida e nos Premios na hora da instanciacao do mapa. ---
            */

            for (int x = 0; x < mapa.linhas; x++) {
                for (int y = 0; y < mapa.colunas; y++) {

                    if(mapa.obterSaida(x,y).posicao == new Posicao(x,y)) {
                       // --- print da saida ---
                    }

                    if (mapa.ObterPremio(x, y).terrenoPosicao.posicao == new Posicao(x, y)) {
                        // --- print do premio ---
                    }

                }
            }
        }
    }
}
