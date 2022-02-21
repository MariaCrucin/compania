using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Tarife
{
    public class TarifeSpecification : BaseSpecification<Tarif>
    {
        public TarifeSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Serviciu);
        }

        public TarifeSpecification(int? clientId, int? serviciuId) : base(x =>
          (!clientId.HasValue || x.ClientId == clientId) &&
          (!serviciuId.HasValue || x.ServiciuId == serviciuId)
        )
        {
            AddInclude(x => x.Serviciu);
        }

        public TarifeSpecification(int? clientId, string cod) : base (x =>
            (!clientId.HasValue || x.ClientId == clientId) &&
            (string.IsNullOrEmpty(cod) || x.Serviciu.Cod.StartsWith(cod))
        )
        {
            AddInclude(x => x.Serviciu);
            AddOrderBy(x => x.Serviciu.Cod);
        }
    }
}
