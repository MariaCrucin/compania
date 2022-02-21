using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Receptie
{
    public class ReceptieInStocDto
    {
        public int Id { get; set; }
        public string NrDoc { get; set; }
        public DateTime DataDoc { get; set; }
        public string TipDocument { get; set; }
    }
}
