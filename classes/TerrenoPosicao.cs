using System.Windows.Media;
using System.Windows;
using System;

namespace projeto_busca.Classes
{
    class TerrenoPosicao
    {
        public Posicao posicao { get; set; }
        public Terreno terreno { get; protected set; }

        public int indexItem { get; set; }

        public int heuristica {  get; set; }

        public String imagem { get; protected set; }

        public  TerrenoPosicao(Terreno terreno, Posicao posicao)
        {
            this.terreno = terreno;
            this.posicao = posicao;

            this.imagem = "";

            switch (this.terreno)
            {
                case Terreno.Solido:
                    this.imagem = "solido.png";
                    break;
                case Terreno.Arenoso:
                    this.imagem = "arenoso.png";
                    break;
                case Terreno.Pantano:
                    this.imagem = "pantano.png";
                    break;
                case Terreno.Rochoso:
                    this.imagem = "rochoso.png";
                    break;
                case Terreno.Parede:
                    this.imagem = "parede.png";
                    break;
                default:
                    this.imagem = "inexistente.jpeg";
                    break;
            }
        }

        public void mudarImagem(String imagem) { 
            this.imagem = imagem;
        }
    }
}
