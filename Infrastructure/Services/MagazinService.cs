using Core.Entities;
using Core.Entities.Helpers;
using Core.Interfaces;
using Core.Specifications.Magazine;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MagazinService : IMagazinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MagazinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        private async Task<string> ReadFromFileAsync(IFormFile file) {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<int> ImportaComenziCadruDinFisier(IFormFile file, int clientId)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(clientId);

            if (client == null)
                return -1;

            if (!Path.GetExtension(file.FileName).Equals(".json", StringComparison.OrdinalIgnoreCase))
                return -1;

            if (file == null || file.Length == 0)
                return -1;

            //var magazineText = File.ReadAllText("D:/Cc/2021/cc2021.json");
            var magazineText = await this.ReadFromFileAsync(file);

            //Debug.WriteLine(magazineText);

            var magazine = JsonSerializer.Deserialize<List<LinieMagazinFromFile>>(magazineText);

            foreach (var item in magazine)
            {
                //Debug.WriteLine(item);
                //Debug.WriteLine(item.Denloc);

                var numarMagazin = Int32.Parse(item.Loc.Substring(1, 4));
                //Debug.WriteLine(numarMagazin);
                
                var spec = new MagazineSpecification(clientId, numarMagazin);
                var magazin = await _unitOfWork.Repository<Magazin>().GetEntityWithSpec(spec);

                if (magazin == null)
                {
                    var magazinNou = new Magazin(numarMagazin, item.Denloc, item.Cc, clientId);
                    _unitOfWork.Repository<Magazin>().Add(magazinNou);
                }
                else
                {
                    magazin.Den = item.Denloc.Substring(11);
                    magazin.ComandaCadru = item.Cc;
                }
            }

            return await _unitOfWork.Complete();
        }

        public async Task<int> GetNumberOfMagazine(MagazinSpecParams magazinParams)
        {
            var countSpec = new MagazineForCountSpecifications(magazinParams);
            return await _unitOfWork.Repository<Magazin>().CountAsync(countSpec);
        }

        public async Task<IReadOnlyList<Magazin>> GetMagazine(MagazinSpecParams magazinParams)
        {
            var spec = new MagazineSpecification(magazinParams);

            return await _unitOfWork.Repository<Magazin>().ListAsync(spec);
        }

        public async Task<Magazin> GetMagazin(int id)
        {
            return await _unitOfWork.Repository<Magazin>().GetByIdAsync(id);
        }

        public async Task<Magazin> CreateMagazin(Magazin magazin)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(magazin.ClientId);
            if (client == null) return null;

            var spec = new MagazineSpecification(magazin.ClientId, magazin.Numar);
            var magazinCuNr = await _unitOfWork.Repository<Magazin>().GetEntityWithSpec(spec);
            if (magazinCuNr != null) return null;
            
            _unitOfWork.Repository<Magazin>().Add(magazin);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return magazin;
        }

        public async Task<Magazin> UpdateMagazin(Magazin magazin)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(magazin.ClientId);
            if (client == null) return null;

            var spec = new MagazineSpecification(magazin.ClientId, magazin.Numar);
            var magazinCuNr = await _unitOfWork.Repository<Magazin>().GetEntityWithSpec(spec);
            if (magazinCuNr != null && magazinCuNr.Id != magazin.Id) return null;
            
            // _unitOfWork.Repository<Magazin>().Update(magazin);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return magazin;
        }
    }
}
