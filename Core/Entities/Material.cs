using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Material : BaseEntity
    {
        public byte NrPozDoc { get; set; }
        public string Den { get; set; }
        public decimal Cant { get; set; }
        public string Um { get; set; }
        public byte CotaTvaAch { get; set; }
        public decimal PretAch { get; set; }
        public decimal BazaAch { get; set; }
        public decimal TvaAch { get; set; }
        public decimal ValAch { get; set; }
        public byte CotaTva { get; set; }
        public byte AdaosProc { get; set; }
        public decimal Pret { get; set; }
        public decimal Baza { get; set; }
        public decimal Tva { get; set; }
        public decimal Val { get; set; }
        public decimal CantUtilizata { get; set; }
        public decimal CantRamasa { get; set; }
        public int ReceptieId { get; set; }
        public Receptie Receptie { get; set; }
    }
}
