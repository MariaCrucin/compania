using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Magazin
{
    public class MagazinToSaveDto
    {
        [Required(ErrorMessage = "Introduceti numarul magazinului")]
        public int Numar { get; set; }
      
        [Required(ErrorMessage = "Introduceti denumirea magazinului")]
        [MaxLength(50, ErrorMessage = "Denumirea magazinului poate contine maximum 50 caractere")]
        public string Den { get; set; }

        [MaxLength(10, ErrorMessage = "Comanda cadru contine 10 cifre")]
        [MinLength(10, ErrorMessage = "Comanda cadru contine 10 cifre")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Comanda cadru trebuie sa contina numai cifre")]
        public string ComandaCadru { get; set; }
        public int ClientId { get; set; }

    }
}
