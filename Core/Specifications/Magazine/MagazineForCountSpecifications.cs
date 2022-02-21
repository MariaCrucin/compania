using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Magazine
{
    public class MagazineForCountSpecifications : BaseSpecification<Magazin>
    {
        public MagazineForCountSpecifications(MagazinSpecParams magazinParams) : base(x =>
             (string.IsNullOrEmpty(magazinParams.SearchDen) || x.Den.ToLower().Contains(magazinParams.SearchDen)) &&
             (!magazinParams.SearchNr.HasValue || x.Numar == magazinParams.SearchNr) &&
             (!magazinParams.ClientId.HasValue || x.ClientId == magazinParams.ClientId)
        )
        {
        }
    }
}
