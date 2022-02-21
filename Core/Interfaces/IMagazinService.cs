using Core.Entities;
using Core.Specifications.Magazine;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMagazinService
    {
        Task<int> ImportaComenziCadruDinFisier(IFormFile file, int ClientId);
        Task<IReadOnlyList<Magazin>> GetMagazine(MagazinSpecParams magazinParams);
        Task<int> GetNumberOfMagazine(MagazinSpecParams magazinParams);
        Task<Magazin> GetMagazin(int id);
        Task<Magazin> CreateMagazin(Magazin magazin);
        Task<Magazin> UpdateMagazin(Magazin magazin);
    }
}
