using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Tarif
{
    public class TarifToSaveDto
    {
        [Required(ErrorMessage = "Competati id-ul clientului")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Competati id-ul serviciului")]
        public int ServiciuId { get; set; }
        public decimal? Pret { get; set; }
        public byte? CoefKm { get; set; }
        public byte? ProcDisc { get; set; }

    }
}
