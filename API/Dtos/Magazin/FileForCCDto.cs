using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Magazin
{
    public class FileForCCDto
    {
        public IFormFile File { get; set; }
        public int ClientId { get; set; }
    }
}
