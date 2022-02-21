using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Furnizori
{
    public class FurnizoriWithStocSpecification : BaseSpecification<Furnizor>
    {
        public FurnizoriWithStocSpecification(FurnizoriSpecParams furnizoriParams) : base(x =>
            (string.IsNullOrEmpty(furnizoriParams.SearchDen) || x.Den.ToLower().StartsWith(furnizoriParams.SearchDen)) &&
            x.Receptii.Any(r => r.Materiale.Any(m => m.CantRamasa != 0))
        )
        {
            AddOrderBy(x => x.Den);
        }
    }
}
