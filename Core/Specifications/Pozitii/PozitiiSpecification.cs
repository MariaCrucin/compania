using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Pozitii
{
    public class PozitiiSpecification : BaseSpecification<Pozitia>
    {
        public PozitiiSpecification(int? clientId) : base (x=> !clientId.HasValue || x.ClientId == clientId)
        {
        }
    }
}
