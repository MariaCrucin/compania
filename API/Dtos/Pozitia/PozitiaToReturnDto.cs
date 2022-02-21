using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Pozitia
{
    public class PozitiaToReturnDto
    {
        public int Id { get; set; }
        public int Numar { get; set; }
        public string Den { get; set; }
        public int ClientId { get; set; }
    }
}
