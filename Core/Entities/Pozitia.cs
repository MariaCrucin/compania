using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Pozitia : BaseEntity
    {
        public int Numar { get; set; }
        public string Den { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
