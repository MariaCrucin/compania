using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiInStocSpecification : BaseSpecification<Receptie>
    {
        public ReceptiiInStocSpecification(ReceptieSpecParams receptieParams) : base(x =>
           (!receptieParams.FurnizorId.HasValue || x.FurnizorId == receptieParams.FurnizorId) &&
           (x.Materiale.Any(m => m.CantRamasa != 0))
        )
        {
            AddInclude(x => x.TipDocument);
            AddOrderByDescending(x => x.DataDoc);
        }
    }
}
