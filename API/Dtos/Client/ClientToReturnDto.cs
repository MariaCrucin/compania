using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Client
{
    public class ClientToReturnDto
    {
        public int Id { get; set; }
        public string Den { get; set; }
        public string Sediu1 { get; set; }
        public string Sediu2 { get; set; }
        public string NrCont { get; set; }
        public string Banca { get; set; }
        public string CodJudJ { get; set; }
        public string NrOrdJ { get; set; }
        public string AnJ { get; set; }
        public string AtCif { get; set; }
        public string NrCif { get; set; }
        public string NumarContract { get; set; }
        public DateTime? DataContract { get; set; }
        public string Tara { get; set; }
        public string NrTva { get; set; }
        public int FirmaId { get; set; }

    }
}
