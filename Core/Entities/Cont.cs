using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cont : BaseEntity
    {
        public string Valuta { get; set; }
        public string NrCont { get; set; }
        public string Banca { get; set; }
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }
    }
}
