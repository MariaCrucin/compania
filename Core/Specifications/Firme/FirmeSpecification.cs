using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Firme
{
    public class FirmeSpecification : BaseSpecification<Firma>
    {
        public FirmeSpecification(string nrCif) : base(x => string.IsNullOrEmpty(nrCif) || String.Equals(x.NrCif, nrCif))
        {
        }
    }
}
