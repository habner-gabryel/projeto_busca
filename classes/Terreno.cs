using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_busca.classes
{
    internal class Terreno
    {
        public Terreno(string tipoTerreno, int custoTerreno)
        {
            this.tipoTerreno = tipoTerreno;
            this.custoTerreno = custoTerreno;
        }

        string tipoTerreno {  get; set; }
        int custoTerreno { get; set; }

        public override string ToString()
        {
            return "Terreno: " + tipoTerreno + " - Custo: " + custoTerreno;
        }
    }
}
