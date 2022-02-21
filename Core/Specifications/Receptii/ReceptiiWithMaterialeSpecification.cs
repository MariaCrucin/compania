using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiWithMaterialeSpecification : BaseSpecification<Receptie>
    {
        public ReceptiiWithMaterialeSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Materiale);
        }
    }
}
