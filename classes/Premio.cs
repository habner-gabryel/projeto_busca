namespace projeto_busca.classes
{
    class Premio
    {
        public TerrenoPosicao terrenoPosicao {  get; private set; }
        public int valor {  get; set; }
        public Premio(TerrenoPosicao terrenoPosicao, int valor)
        {
            this.terrenoPosicao = terrenoPosicao;
            this.valor = valor;
        }
    }
}
