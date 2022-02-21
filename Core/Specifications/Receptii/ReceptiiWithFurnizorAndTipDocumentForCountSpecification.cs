using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiWithFurnizorAndTipDocumentForCountSpecification : BaseSpecification<Receptie>
    {
        public ReceptiiWithFurnizorAndTipDocumentForCountSpecification(ReceptieSpecParams receptieParams) : base(x =>
           (string.IsNullOrEmpty(receptieParams.NrDoc) || String.Equals(x.NrDoc, receptieParams.NrDoc)) &&
           (!receptieParams.FurnizorId.HasValue || x.FurnizorId == receptieParams.FurnizorId)
        )
        {
        }
    }
}
