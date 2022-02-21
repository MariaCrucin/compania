using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Furnizori
{
    public class FurnizoriSpecification : BaseSpecification<Furnizor>
    {
        public FurnizoriSpecification(string nrCif) : base(x => string.IsNullOrEmpty(nrCif) || String.Equals(x.NrCif, nrCif))
        {
        }

        public FurnizoriSpecification(FurnizoriSpecParams furnizoriParams) : base(x =>
             string.IsNullOrEmpty(furnizoriParams.SearchDen) || x.Den.ToLower().StartsWith(furnizoriParams.SearchDen.ToLower())
        )
        {
            AddOrderBy(x => x.Den);
            ApplyPaging(furnizoriParams.PageSize * (furnizoriParams.PageIndex - 1), furnizoriParams.PageSize);
        }
    }
}
