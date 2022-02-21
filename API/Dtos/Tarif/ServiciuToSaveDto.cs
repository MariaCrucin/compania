using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Tarif
{
    public class ServiciuToSaveDto
    {
        [Required(ErrorMessage = "Competati codul")]
        [MaxLength(3, ErrorMessage = "Codul contine maxim 3 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Codul trebuie sa contina numai cifre")]
        public string Cod { get; set; }

        [Required(ErrorMessage = "Competati denumirea")]
        [MaxLength(50, ErrorMessage = "Denumirea contine maxim 50 caractere")]
        public string Den { get; set; }

        [MaxLength(3, ErrorMessage = "Um contine maxim 3 caractere")]
        public string Um { get; set; }
    }
}
