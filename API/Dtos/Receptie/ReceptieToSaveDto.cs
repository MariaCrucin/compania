using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Receptie
{
    public class ReceptieToSaveDto
    {
        [Required(ErrorMessage = "Introduceti numarul receptiei")]
        public int NrNir { get; set; }

        [Required(ErrorMessage = "Introduceti data receptiei")]
        public DateTime DataNir { get; set; }

        [Required(ErrorMessage = "Introduceti tipul documentului receptionat")]
        public int TipDocumentId { get; set; }

        [Required(ErrorMessage = "Introduceti numarul documentului receptionat")]
        [MaxLength(15, ErrorMessage = "NrDoc contine maxim 15 caractere")]
        public string NrDoc { get; set; }

        [Required(ErrorMessage = "Introduceti data documentului receptionat")]
        public DateTime DataDoc { get; set; }

        [MaxLength(10, ErrorMessage = "Obs contine maxim 10 caractere")]
        public string Obs { get; set; }

        [Required(ErrorMessage = "Introduceti baza la achiziti")]
        public decimal BazaAch { get; set; }

        [Required(ErrorMessage = "Introduceti tva la achizitie")]
        public decimal TvaAch { get; set; }

        [Required(ErrorMessage = "Introduceti val la achizitie")]
        public decimal ValAch { get; set; }
        public byte AdaosProc { get; set; }

        [Required(ErrorMessage = "Introduceti baza la vanzare")]
        public decimal Baza { get; set; }

        [Required(ErrorMessage = "Introduceti tva la vanzare")]
        public decimal Tva { get; set; }

        [Required(ErrorMessage = "Introduceti val la vanzare")]
        public decimal Val { get; set; }

        [Required(ErrorMessage = "Introduceti firma pt care se face receptia")]
        public int FirmaId { get; set; }

        [Required(ErrorMessage = "Introduceti furnizorul receptiei")]
        public int FurnizorId { get; set; }
        public ICollection<MaterialToSaveDto> Materiale { get; set; }
    }
}
