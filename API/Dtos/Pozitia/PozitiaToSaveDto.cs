using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Pozitia
{
    public class PozitiaToSaveDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduceti numarul pozitiei")]
        public int Numar { get; set; }

        [Required(ErrorMessage = "Introduceti denumirea pozitiei")]
        [MaxLength(50, ErrorMessage = "Denumirea pozitiei poate contine maximum 50 caractere")]
        public string Den { get; set; }
        public int ClientId { get; set; }
    }
}
