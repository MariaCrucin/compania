using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.UnitateDeMasura
{
    public class UnitateDeMasuraToSaveDto
    {   
        [Required(ErrorMessage = "Introduceti unitatea de masura")]
        [MaxLength(3, ErrorMessage = "UM poate contine maxim 3 caractere")]
        public string Um { get; set; }
    }
}
