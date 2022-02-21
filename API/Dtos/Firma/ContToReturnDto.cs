using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Firma
{
    public class ContToReturnDto
    {
        public int Id { get; set; }
        public string Valuta { get; set; }
        public string NrCont { get; set; }
        public string Banca { get; set; }
        public int FirmaId { get; set; }
    }
}
