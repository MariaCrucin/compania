using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Firma
{
    public class FirmaToSaveDto
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

        public uint Capital { get; set; }

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

        public byte CotaTva { get; set; }

        [MaxLength(5, ErrorMessage = "Seria facturii poate contine maximum 5 caractere")]
        public string SeriaFact { get; set; }

        [MaxLength(30, ErrorMessage = "Numele operatorului poate contine maximum 30 caractere")]
        public string NumeOperator { get; set; }

        [MaxLength(12, ErrorMessage = "Telefonul poate contine maximum 12 caractere")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa contina numai cifre")]
        public string Telefon { get; set; }

        [MaxLength(25, ErrorMessage = "Sigla poate contine maximum 25 caractere")]
        public string SiglaUrl { get; set; }

        public ICollection<ContToSaveDto> Conturi { get; set; }
    }
}

