using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Clienti
{
    public class ClientiSpecification : BaseSpecification<Client>
    {
        public ClientiSpecification(int? firmaId, string beginDen) : base (x => 
            (!firmaId.HasValue || x.FirmaId == firmaId) &&
            (string.IsNullOrEmpty(beginDen) || x.Den.ToUpper().StartsWith(beginDen.ToUpper()))
        )
        {
        }
    }
}

