using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Furnizor
{
    public class FurnizorToReturnDto
    {
        public int Id { get; set; }
        public string AtCif { get; set; }
        public string NrCif { get; set; }
        public string PrefixDen { get; set; }
        public string Den { get; set; }
    }
}
