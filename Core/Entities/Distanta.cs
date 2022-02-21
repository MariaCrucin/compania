using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Distanta : BaseEntity
    {
        public int PlecareId { get; set; }
        public Oras Plecare { get; set; }
        public int SosireId { get; set; }
        public Oras Sosire { get; set; }
        public int Km { get; set; }
    }
}
