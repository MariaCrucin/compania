using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Magazine
{
    public class MagazineSpecification : BaseSpecification<Magazin>
    {
        public MagazineSpecification(int? clientID, int? numar) :
            base (x =>
                (!clientID.HasValue || x.ClientId == clientID) &&
                (!numar.HasValue || x.Numar == numar)
            )
        {
        }

        public MagazineSpecification(MagazinSpecParams magazinParams) : base(x =>
            (string.IsNullOrEmpty(magazinParams.SearchDen) || x.Den.ToLower().Contains(magazinParams.SearchDen)) &&
            (!magazinParams.SearchNr.HasValue || x.Numar == magazinParams.SearchNr) &&
            (!magazinParams.ClientId.HasValue || x.ClientId == magazinParams.ClientId)
        )
        {
            
            if (!string.IsNullOrEmpty(magazinParams.Sort))
            {
                switch (magazinParams.Sort)
                {
                    case "numar":
                        AddOrderBy(x => x.Numar);
                        break;
                    case "den":
                        AddOrderBy(x => x.Den);
                        break;
                    default:
                        AddOrderBy(x => x.Den);
                        break;
                }
            }
            else {
                AddOrderBy(x => x.Den);
            }

            ApplyPaging(magazinParams.PageSize * (magazinParams.PageIndex - 1), magazinParams.PageSize);
        }
    }
}
