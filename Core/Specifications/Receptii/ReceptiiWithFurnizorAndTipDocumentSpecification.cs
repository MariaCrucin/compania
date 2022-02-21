using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiWithFurnizorAndTipDocumentSpecification : BaseSpecification<Receptie>
    {
        public ReceptiiWithFurnizorAndTipDocumentSpecification(ReceptieSpecParams receptieParams) : base (x =>
            (string.IsNullOrEmpty(receptieParams.NrDoc) || String.Equals(x.NrDoc, receptieParams.NrDoc)) &&
            (!receptieParams.FurnizorId.HasValue || x.FurnizorId == receptieParams.FurnizorId)
        )
        {
            AddInclude(x => x.Furnizor);
            AddInclude(x => x.TipDocument);

            AddOrderByDescending(x => x.NrNir);

            ApplyPaging(receptieParams.PageSize * (receptieParams.PageIndex - 1), receptieParams.PageSize);
        }
    }
}
