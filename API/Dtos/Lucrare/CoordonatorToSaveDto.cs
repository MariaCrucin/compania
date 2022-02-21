using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Lucrare
{
    public class CoordonatorToSaveDto
    {
        [Required(ErrorMessage = "Competati numele")]
        [MaxLength(25, ErrorMessage = "Numele contine maxim 25 de caractere")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Competati numele")]
        public int ClientId { get; set; }
       
    }
}
