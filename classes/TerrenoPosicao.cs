namespace projeto_busca.classes
{
    class TerrenoPosicao
    {
        public Posicao posicao {  get; set; }
        public Terreno terreno {  get; protected set; }
        public Mapa mapa { get; protected set; }

        public TerrenoPosicao(Posicao posicao, Terreno terreno, Mapa mapa)
        {
            this.posicao = posicao;
            this.terreno = terreno;
            this.mapa = mapa;
        }
    }
}
