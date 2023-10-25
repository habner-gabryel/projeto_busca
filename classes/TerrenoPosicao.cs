namespace projeto_busca.Classes
{
    class TerrenoPosicao
    {
        public Posicao posicao {  get; set; }
        public Terreno terreno {  get; protected set; }

        public TerrenoPosicao(Terreno terreno, Posicao posicao)
        {
            this.terreno = terreno;
            this.posicao = posicao;
        }
    }
}
