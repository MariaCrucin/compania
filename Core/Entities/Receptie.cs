using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Receptie : BaseEntity
    {
        public int NrNir { get; set; }
        public DateTime DataNir { get; set; }
        public string NrDoc { get; set; }
        public DateTime DataDoc { get; set; }
        public string Obs { get; set; }
        public decimal BazaAch { get; set; }
        public decimal TvaAch { get; set; }
        public decimal ValAch { get; set; }
        public byte AdaosProc { get; set; }
        public decimal Baza { get; set; }
        public decimal Tva { get; set; }
        public decimal Val { get; set; }
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }
        public int FurnizorId { get; set; }
        public Furnizor Furnizor { get; set; }
        public int TipDocumentId { get; set; }
        public  TipDocument TipDocument { get; set; }
        public ICollection<Material> Materiale { get; set; }

    }
}
