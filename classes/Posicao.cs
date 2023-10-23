using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_busca.classes
{
    internal class Posicao
    {
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public int linha { get; set; }
        public int coluna {  get; set; }

        public override string ToString()
        {
            return "Linha: " +  linha + " - Coluna: " + coluna;
        }
    }
}
