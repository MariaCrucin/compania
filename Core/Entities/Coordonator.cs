using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Coordonator : BaseEntity
    {
        public string Nume { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
