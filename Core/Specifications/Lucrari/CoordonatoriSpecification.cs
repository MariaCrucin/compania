using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Lucrari
{
    public class CoordonatoriSpecification : BaseSpecification<Coordonator>
    {
        public CoordonatoriSpecification(int? clientId) : base(x => 
            !clientId.HasValue || x.ClientId == clientId
        )
        {
        }
    }
}
