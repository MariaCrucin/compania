using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Tarif
{
    public class TarifToReturnDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiciuId { get; set; }
        public string Cod { get; set; }
        public string Den { get; set; }
        public string Um { get; set; }
        public decimal? Pret { get; set; }
        public byte? CoefKm { get; set; }
        public byte? ProcDisc { get; set; }
    }
}
