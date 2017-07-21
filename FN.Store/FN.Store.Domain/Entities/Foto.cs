using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Entities
{
    public class Foto : EntidadeBase
    {
        public Foto()
        {

        }

        public string Caminho { get; set; }
        public string Descricao { get; set; }
    }
}
