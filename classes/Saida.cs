namespace projeto_busca.classes
{
    class Saida
    {
        public Posicao posicao {  get; set; }
        public int heuristica { get; set; }
        
        public Saida(Posicao posicao, int heuristica)
        {
            this.posicao = posicao;
            this.heuristica = heuristica;
        }
    }
}
