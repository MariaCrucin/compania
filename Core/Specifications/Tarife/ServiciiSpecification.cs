using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Tarife
{
    public class ServiciiSpecification : BaseSpecification<Serviciu>
    {
        public ServiciiSpecification(string cod) : base (x =>
            string.IsNullOrEmpty(cod) || x.Cod.StartsWith(cod)
        )
        {
        }
    }
}