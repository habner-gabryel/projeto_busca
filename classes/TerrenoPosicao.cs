using System.Windows.Media;
using System.Windows;
using System;

namespace projeto_busca.Classes
{
    class TerrenoPosicao
    {
        public Posicao posicao { get; set; }
        public Terreno terreno { get; protected set; }

        public String imagem { get; protected set; }

        public  TerrenoPosicao(Terreno terreno, Posicao posicao)
        {
            this.terreno = terreno;
            this.posicao = posicao;

            this.imagem = "";

            switch (this.terreno)
            {
                case Terreno.Solido:
                    this.imagem = "solido.jpg";
                    break;
                case Terreno.Arenoso:
                    this.imagem = "arenoso.jpg";
                    break;
                case Terreno.Pantano:
                    this.imagem = "pantano.jpg";
                    break;
                case Terreno.Rochoso:
                    this.imagem = "rochoso.jpg";
                    break;
                case Terreno.Parede:
                    this.imagem = "parede.jpg";
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
