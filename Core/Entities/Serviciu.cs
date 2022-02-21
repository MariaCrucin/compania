using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Serviciu : BaseEntity
    {
        public string Cod { get; set; }
        public string Den { get; set; }
        public string Um { get; set; }

        public ICollection<Tarif> Tarife { get; set; }
    }
}
