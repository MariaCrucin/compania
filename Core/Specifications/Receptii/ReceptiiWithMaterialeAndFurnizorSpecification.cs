using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Receptii
{
    public class ReceptiiWithMaterialeAndFurnizorSpecification : BaseSpecification<Receptie>
    {
        public ReceptiiWithMaterialeAndFurnizorSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Materiale);
            AddInclude(x => x.Furnizor);
        }
    }
}
