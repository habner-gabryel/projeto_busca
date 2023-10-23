using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_busca.classes
{
    internal class TerrenoPosicao
    {
        public TerrenoPosicao(Terreno terreno, Posicao posicao) {
            this.Terreno = terreno;
            this.Posicao = posicao; 
        }

        Terreno Terreno { get; set; }

        public Posicao Posicao { get; set; }

        public override string ToString()
        {
            return Terreno.ToString() + " | " + Posicao.ToString();
        }
    }
}
