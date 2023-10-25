using projeto_busca.Classes;

namespace projeto_busca.Controllers
{
    class MapaController
    {
        public static void imprimirMapa(Mapa mapa) {

            if (mapa == null)
            {
                throw new System.ArgumentNullException("Mapa nao pode ser nulo ou vazio");
            }
            /* Random random = new Random();
            int posX = random.Next(0, 101);
            int posY = random.Next(0, 101); 
             ---- implementar essa randomizacao na Saida e nos Premios na hora da instanciacao do mapa. ---
            */

            for (int x = 0; x < mapa.linhas; x++)
            {
                for (int y = 0; y < mapa.colunas; y++)
                {

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

        public Mapa criarMapa(int linhas, int colunas) {
            Mapa map = null;



            return map;
        }

    }
}
