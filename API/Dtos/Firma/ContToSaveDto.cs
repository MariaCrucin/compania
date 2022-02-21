using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Firma
{
    public class ContToSaveDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduceti valuta")]
        [MaxLength(10, ErrorMessage = "Valuta poate contine maximum 10 caractere")]
        public string Valuta { get; set; }

        [Required(ErrorMessage = "Introduceti nr. cont")]
        [MaxLength(24, ErrorMessage = "Nr. cont. contine 24 caractere")]
        [MinLength(24, ErrorMessage = "Nr. cont. contine 24 caractere")]
        public string NrCont { get; set; }

        [Required(ErrorMessage = "Introduceti banca")]
        [MaxLength(50, ErrorMessage = "Banca poate contine maximum 50 caractere")]
        public string Banca { get; set; }

        public int FirmaId { get; set; }
    }
}
