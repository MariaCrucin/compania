using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Firma
{
    public class FirmaToReturnDto
    {
        public int Id { get; set; }
        public string Den { get; set; }
        public string Sediu1 { get; set; }
        public string Sediu2 { get; set; }
        public uint Capital { get; set; }
        public string CodJudJ { get; set; }
        public string NrOrdJ { get; set; }
        public string AnJ { get; set; }
        public string AtCif { get; set; }
        public string NrCif { get; set; }
        public byte CotaTva { get; set; }
        public string SeriaFact { get; set; }
        public string NumeOperator { get; set; }
        public string Telefon { get; set; }
        public string SiglaUrl { get; set; }

        // public ICollection<ContToReturnDto> Conturi { get; set; }
        
    }
}
