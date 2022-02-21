using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Magazin
{
    public class MagazinToReturnDto
    {
        public int Id { get; set; }
        public int Numar { get; set; }
        public string Den { get; set; }
        public string ComandaCadru { get; set; }
        public int ClientId { get; set; }
    }
}
