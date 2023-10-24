namespace projeto_busca.classes
{
    class Mapa
    {
        public int linhas {  get; set; }
        public int colunas { get; set; }
        private Premio[,] premios;

        public Mapa(int linhas, int colunas) { 
            this.linhas = linhas; 
            this.colunas = colunas;
            premios = new Premio[linhas, colunas];
        }

    }
}
