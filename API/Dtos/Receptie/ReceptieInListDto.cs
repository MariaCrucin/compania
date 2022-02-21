using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Receptie
{
    public class ReceptieInListDto
    {
        public int Id { get; set; }
        public int NrNir { get; set; }
        public DateTime DataNir { get; set; }
        public string Furnizor { get; set; }
        public string TipDocument { get; set; }
        public string NrDoc { get; set; }
        public DateTime DataDoc { get; set; }
        public decimal BazaAch { get; set; }
        public decimal TvaAch { get; set; }
        public decimal ValAch { get; set; }
    }
}
