using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.TipDoc
{
    public class TipDocToSaveDto
    {
        [Required(ErrorMessage = "Introduceti felul")]
        [MaxLength(25, ErrorMessage = "Den document poate contine maximum 25 caractere")]
        public string Den { get; set; }

        [Required(ErrorMessage = "Introduceti codul")]
        [MaxLength(22, ErrorMessage = "Cod document poate contine maximum 2 caractere")]
        public string Cod { get; set; }
    }
}
