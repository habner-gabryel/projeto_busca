namespace projeto_busca.Classes
{
    class Saida
    {
        public TerrenoPosicao terrenoPosicao { get; set; }
        public int heuristica { get; set; }

        public Saida(TerrenoPosicao terrenoPosicao)
        {
            this.terrenoPosicao = terrenoPosicao;
        }

    }
}
