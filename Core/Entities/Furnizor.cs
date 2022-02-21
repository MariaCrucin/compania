using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Furnizor : BaseEntity
    {
        public string AtCif { get; set; }
        public string NrCif { get; set; }
        public string PrefixDen { get; set; }
        public string Den { get; set; }
        public ICollection<Receptie> Receptii { get; set; }

    }
}
