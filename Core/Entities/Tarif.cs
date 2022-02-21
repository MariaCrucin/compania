using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities 
{
    public class Tarif : BaseEntity
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiciuId { get; set; }
        public Serviciu Serviciu { get; set; }

        public decimal? Pret { get; set; }
        public byte? CoefKm { get; set; }
        public byte? ProcDisc { get; set; }

    }
}
