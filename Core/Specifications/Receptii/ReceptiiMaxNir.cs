using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiMaxNir : BaseSpecification<Receptie>
    {
        public ReceptiiMaxNir() : base()
        {
            AddOrderByDescending(r => r.NrNir);
        }
    }
}
