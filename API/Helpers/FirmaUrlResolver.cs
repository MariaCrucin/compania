using API.Dtos.Firma;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class FirmaUrlResolver : IValueResolver<Firma, FirmaToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public FirmaUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Firma source, FirmaToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.SiglaUrl))
            {
                return _config["ApiUrl"] + source.SiglaUrl;
            }

            return null;
        }
    }
}
