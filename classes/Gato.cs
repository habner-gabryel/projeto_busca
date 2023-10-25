namespace projeto_busca.Classes
{
    class Gato
    {

        int custoAcumulado {  get; set; }
        int premiosColetados { get; set; }

        Posicao posicao { get; set; }

        public Gato(int custoAcumulado, int premiosColetados, Posicao posicao) {
            this.custoAcumulado = custoAcumulado;
            this.premiosColetados = premiosColetados;
            this.posicao = posicao;
        }
    }
}
