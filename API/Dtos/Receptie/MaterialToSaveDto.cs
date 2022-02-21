using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Receptie
{
    public class MaterialToSaveDto
    {
        [Required(ErrorMessage = "Competati numarul pozitiei")]
        public byte NrPozDoc { get; set; }

        [Required(ErrorMessage = "Competati denumirea")]
        [MaxLength(50, ErrorMessage = "Denumirea contine maxim 50 de caractere")]
        public string Den { get; set; }

        [Required(ErrorMessage = "Competati cantitatea")]
        public decimal Cant { get; set; }

        [Required(ErrorMessage = "Competati Unitatea de Masura")]
        public string Um { get; set; }

        [Required(ErrorMessage = "Competati cota TVA la achizitie")]
        public byte CotaTvaAch { get; set; }

        [Required(ErrorMessage = "Competati pretul la achizitie")]
        public decimal PretAch { get; set; }

        [Required(ErrorMessage = "Competati baza la achizitie")]
        public decimal BazaAch { get; set; }

        [Required(ErrorMessage = "Competati tva-ul la achizitie")]
        public decimal TvaAch { get; set; }

        [Required(ErrorMessage = "Competati baza la achizitie")]
        public decimal ValAch { get; set; }

        [Required(ErrorMessage = "Competati cota tva la vanzare")]
        public byte CotaTva { get; set; }

        [Required(ErrorMessage = "Competati adaos-ul procentual la vanzare")]
        public byte AdaosProc { get; set; }

        [Required(ErrorMessage = "Competati pretul la vanzare")]
        public decimal Pret { get; set; }

        [Required(ErrorMessage = "Competati baza la vanzare")]
        public decimal Baza { get; set; }

        [Required(ErrorMessage = "Competati tva la vanzare")]
        public decimal Tva { get; set; }

        [Required(ErrorMessage = "Competati val la vanzare")]
        public decimal Val { get; set; }

        public decimal CantUtilizata { get; set; }

        public decimal CantRamasa { get; set; }

        public int ReceptieId { get; set; }
    }
}
