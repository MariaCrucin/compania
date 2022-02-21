using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Client
{
    public class ClientToSaveDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduceti denumirea firmei")]
        [MaxLength(50, ErrorMessage = "Denumirea firmei poate contine maximum 50 caractere")]
        public string Den { get; set; }

        [Required(ErrorMessage = "Introduceti sediul firmei")]
        [MaxLength(50, ErrorMessage = "Sediul firmei poate contine maximum 50 caractere")]
        public string Sediu1 { get; set; }

        [MaxLength(50, ErrorMessage = "Sediul firmei poate contine maximum 50 caractere")]
        public string Sediu2 { get; set; }

        [Required(ErrorMessage = "Introduceti nr. cont")]
        [MaxLength(24, ErrorMessage = "Nr. cont. contine 24 caractere")]
        [MinLength(24, ErrorMessage = "Nr. cont. contine 24 caractere")]
        public string NrCont { get; set; }

        [Required(ErrorMessage = "Introduceti banca")]
        [MaxLength(50, ErrorMessage = "Banca poate contine maximum 50 caractere")]
        public string Banca { get; set; }

        [Range(1, 52, ErrorMessage = "Valoarea pentru {0} trebuie sa fie intre {1} and {2}.")]
        [MaxLength(2, ErrorMessage = "Cod Jud J poate contine maximum 2 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CodJudJ trebuie sa contina numai cifre")]
        public string CodJudJ { get; set; }

        [MaxLength(5, ErrorMessage = "Nr Ord J poate contine maximum 5 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NrOrdJ trebuie sa contina numai cifre")]
        public string NrOrdJ { get; set; }

        [MaxLength(4, ErrorMessage = "An J poate contine maximum 4 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "AnJ trebuie sa contina numai cifre")]
        public string AnJ { get; set; }

        [MaxLength(2, ErrorMessage = "At CIF poate contine maximum 2 caractere")]
        public string AtCif { get; set; }

        [Required(ErrorMessage = "Introduceti CIF sau CNP")]
        [MaxLength(13, ErrorMessage = "Nr CIF poate contine maximum 13 caractere")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "NrCif trebuie sa contina numai cifre")]
        public string NrCif { get; set; }

        [MaxLength(10, ErrorMessage = "At Numar Contract poate contine maximum 10 caractere")]
        public string NumarContract { get; set; }

        public DateTime? DataContract { get; set; }

        [MaxLength(50, ErrorMessage = "Tara poate contine maximum 50 caractere")]
        public string Tara { get; set; }

        [MaxLength(10, ErrorMessage = "NrTva poate contine maximum 10 caractere")]
        public string NrTva { get; set; }

        public int FirmaId { get; set; }
    }
}
