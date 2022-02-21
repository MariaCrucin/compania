using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Furnizor
{
    public class FurnizorToSaveDto
    {
        [MaxLength(2, ErrorMessage = "Atributul CIF poate contine maximum 2 caractere")]
        public string AtCif { get; set; }

        [Required(ErrorMessage = "Introduceti CIF sau CNP")]
        [MaxLength(13, ErrorMessage = "Nr CIF poate contine maximum 13 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NrCif trebuie sa contina numai cifre")]
        public string NrCif { get; set; }

        [MaxLength(3, ErrorMessage = "Denumirea furnizorului poate contine maximum 3 caractere")]
        public string PrefixDen { get; set; }

        [Required(ErrorMessage = "Introduceti denumirea furnizorului")]
        [MaxLength(50, ErrorMessage = "Denumirea furnizorului poate contine maximum 50 caractere")]
        public string Den { get; set; }
    }
}
